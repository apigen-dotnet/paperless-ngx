using Microsoft.OpenApi;
using Apigen.Generator;

/// <summary>
/// Fix PostDocumentRequest.custom_fields missing type definition.
/// Upstream bug: field only has writeOnly, no type/items.
/// The actual API accepts an array of integers (custom field IDs).
/// </summary>
public class FixCustomFieldsType : ISpecPatch
{
  public string Name => "Fix PostDocumentRequest.custom_fields type";

  private static OpenApiSchema ResolveSchema(IOpenApiSchema schema)
  {
    if (schema is OpenApiSchema concrete) return concrete;
    if (schema is OpenApiSchemaReference reference)
      return reference.RecursiveTarget ?? throw new System.InvalidOperationException(
        $"Unresolved schema reference: {reference.Reference?.Id ?? "(unknown)"}");
    return (OpenApiSchema)schema;
  }

  public bool Apply(OpenApiDocument document)
  {
    if (document.Components?.Schemas == null) return false;
    if (!document.Components.Schemas.TryGetValue("PostDocumentRequest", out IOpenApiSchema? iSchema)) return false;
    OpenApiSchema schema = ResolveSchema(iSchema);
    if (schema.Properties == null) return false;
    if (!schema.Properties.TryGetValue("custom_fields", out IOpenApiSchema? cfI)) return false;
    OpenApiSchema cf = ResolveSchema(cfI);

    // Already has a type? Don't patch (idempotent)
    // In 3.x, Type is JsonSchemaType? (flags enum), not a string
    if (cf.Type != null && cf.Type != (JsonSchemaType)0) return false;

    cf.Type = JsonSchemaType.Array;
    cf.Items = new OpenApiSchema
    {
      Type = JsonSchemaType.Integer,
      WriteOnly = true,
      Title = "Custom fields"
    };
    return true;
  }
}
