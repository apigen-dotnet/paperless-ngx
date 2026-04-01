using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi;
using Apigen.Generator;

/// <summary>
/// Remove NullEnum and BlankEnum schemas.
/// Django REST Framework generates these for nullable enum fields as:
///   oneOf: [RealEnum, BlankEnum, NullEnum]
/// In C# nullable enums handle this already.
/// Also strips references from oneOf lists throughout the spec.
/// </summary>
public class RemoveNullBlankEnums : ISpecPatch
{
  public string Name => "Remove NullEnum/BlankEnum schemas";

  private static readonly HashSet<string> SchemasToRemove = new() { "NullEnum", "BlankEnum" };

  public bool Apply(OpenApiDocument document)
  {
    if (document.Components?.Schemas == null) return false;

    bool changed = false;

    // Remove the schemas
    foreach (string name in SchemasToRemove)
    {
      if (document.Components.Schemas.Remove(name))
      {
        changed = true;
      }
    }

    if (!changed) return false;

    // Strip references from oneOf lists in all schemas
    foreach (var iSchema in document.Components.Schemas.Values)
    {
      StripFromISchema(iSchema);
    }

    // Strip references from paths
    if (document.Paths != null)
    {
      foreach (var path in document.Paths.Values)
      {
        if (path.Operations == null) continue;
        foreach (var op in path.Operations.Values)
        {
          if (op.RequestBody?.Content != null)
          {
            foreach (var content in op.RequestBody.Content.Values)
            {
              if (content.Schema != null) StripFromISchema(content.Schema);
            }
          }

          if (op.Responses == null) continue;
          foreach (var response in op.Responses.Values)
          {
            if (response.Content == null) continue;
            foreach (var content in response.Content.Values)
            {
              if (content.Schema != null) StripFromISchema(content.Schema);
            }
          }
        }
      }
    }

    return true;
  }

  private static void StripFromISchema(IOpenApiSchema iSchema)
  {
    // In 3.x, schemas in collections may be IOpenApiSchema (including OpenApiSchemaReference)
    // Only process concrete OpenApiSchema instances (references don't have mutable oneOf/properties)
    OpenApiSchema schema;
    if (iSchema is OpenApiSchema concrete)
      schema = concrete;
    else if (iSchema is OpenApiSchemaReference schemaRef)
      schema = schemaRef.RecursiveTarget;
    else
      return;

    if (schema == null) return;

    // Process properties recursively
    if (schema.Properties != null)
    {
      foreach (var prop in schema.Properties.Values)
      {
        StripFromISchema(prop);
      }
    }

    // Process items (arrays)
    if (schema.Items != null)
    {
      StripFromISchema(schema.Items);
    }

    // Strip from oneOf
    // In 3.x, OneOf contains IOpenApiSchema; references are OpenApiSchemaReference
    if (schema.OneOf?.Count > 0)
    {
      schema.OneOf = schema.OneOf
        .Where(s => !(s is OpenApiSchemaReference sRef && SchemasToRemove.Contains(sRef.Reference?.Id ?? "")))
        .ToList();

      // If oneOf has only one item left, unwrap it
      if (schema.OneOf.Count == 1)
      {
        IOpenApiSchema single = schema.OneOf[0];
        schema.OneOf.Clear();

        // Copy the single item's reference into this schema via allOf
        if (single is OpenApiSchemaReference)
        {
          schema.AllOf = new List<IOpenApiSchema> { single };
        }
      }
    }

    // Process additionalProperties
    if (schema.AdditionalProperties != null)
    {
      StripFromISchema(schema.AdditionalProperties);
    }
  }
}
