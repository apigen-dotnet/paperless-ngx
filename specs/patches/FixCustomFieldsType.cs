using Microsoft.OpenApi.Models;
using Apigen.Generator;

/// <summary>
/// Fix PostDocumentRequest.custom_fields missing type definition.
/// Upstream bug: field only has writeOnly, no type/items.
/// The actual API accepts an array of integers (custom field IDs).
/// </summary>
public class FixCustomFieldsType : ISpecPatch
{
  public string Name => "Fix PostDocumentRequest.custom_fields type";

  public bool Apply(OpenApiDocument document)
  {
    if (document.Components?.Schemas == null) return false;
    if (!document.Components.Schemas.TryGetValue("PostDocumentRequest", out OpenApiSchema? schema)) return false;
    if (schema.Properties == null) return false;
    if (!schema.Properties.TryGetValue("custom_fields", out OpenApiSchema? cf)) return false;

    // Already has a type? Don't patch (idempotent)
    if (!string.IsNullOrEmpty(cf.Type)) return false;

    cf.Type = "array";
    cf.Items = new OpenApiSchema
    {
      Type = "integer",
      WriteOnly = true,
      Title = "Custom fields"
    };
    return true;
  }
}
