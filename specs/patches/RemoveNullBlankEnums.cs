using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
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
    foreach (var schema in document.Components.Schemas.Values)
    {
      StripFromSchema(schema);
    }

    // Strip references from paths
    if (document.Paths != null)
    {
      foreach (var path in document.Paths.Values)
      {
        foreach (var op in path.Operations.Values)
        {
          if (op.RequestBody?.Content != null)
          {
            foreach (var content in op.RequestBody.Content.Values)
            {
              if (content.Schema != null) StripFromSchema(content.Schema);
            }
          }

          foreach (var response in op.Responses.Values)
          {
            if (response.Content == null) continue;
            foreach (var content in response.Content.Values)
            {
              if (content.Schema != null) StripFromSchema(content.Schema);
            }
          }
        }
      }
    }

    return true;
  }

  private static void StripFromSchema(OpenApiSchema schema)
  {
    // Process properties recursively
    if (schema.Properties != null)
    {
      foreach (var prop in schema.Properties.Values)
      {
        StripFromSchema(prop);
      }
    }

    // Process items (arrays)
    if (schema.Items != null)
    {
      StripFromSchema(schema.Items);
    }

    // Strip from oneOf
    if (schema.OneOf?.Count > 0)
    {
      schema.OneOf = schema.OneOf
        .Where(s => s.Reference == null || !SchemasToRemove.Contains(s.Reference.Id))
        .ToList();

      // If oneOf has only one item left, unwrap it
      if (schema.OneOf.Count == 1)
      {
        OpenApiSchema single = schema.OneOf[0];
        schema.OneOf.Clear();

        // Copy the single item's reference into this schema
        if (single.Reference != null)
        {
          schema.AllOf = new List<OpenApiSchema> { single };
        }
      }
    }

    // Process additionalProperties
    if (schema.AdditionalProperties != null)
    {
      StripFromSchema(schema.AdditionalProperties);
    }
  }
}
