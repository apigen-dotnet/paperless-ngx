using System.Collections.Generic;
using Microsoft.OpenApi;
using Apigen.Generator;

/// <summary>
/// Mark properties as nullable that the API actually returns as null but that upstream
/// declares as non-nullable. Without this the generated model uses a non-nullable value
/// type and deserialization throws for every response containing the field.
///
/// Document.root_document: paperless-ngx 3.0 returns null for every document that is not
/// a version of another document, i.e. nearly all of them. Verified against a live 3.0.5
/// instance: null in 100 out of 100 sampled documents.
/// </summary>
public class FixMissingNullable : ISpecPatch
{
  public string Name => "Add missing nullable on properties the API returns as null";

  private static readonly List<(string Schema, string Property)> Properties = new()
  {
    ("Document", "root_document"),
  };

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

    int count = 0;
    foreach (var (schemaName, propertyName) in Properties)
    {
      if (!document.Components.Schemas.TryGetValue(schemaName, out IOpenApiSchema? iSchema)) continue;
      OpenApiSchema schema = ResolveSchema(iSchema);
      if (schema.Properties == null) continue;
      if (!schema.Properties.TryGetValue(propertyName, out IOpenApiSchema? iProperty)) continue;
      OpenApiSchema property = ResolveSchema(iProperty);

      // Already nullable? Upstream fixed it, leave it alone (idempotent).
      if (property.Type != null && property.Type.Value.HasFlag(JsonSchemaType.Null)) continue;

      property.Type = (property.Type ?? (JsonSchemaType)0) | JsonSchemaType.Null;
      count++;
    }

    return count > 0;
  }
}
