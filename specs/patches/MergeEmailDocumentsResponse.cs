using Microsoft.OpenApi;
using Apigen.Generator;

/// <summary>
/// Merge EmailDocumentsResponse into EmailDocumentResponse.
/// Both schemas are identical (single 'message' string property).
/// Replaces all $refs and removes the duplicate schema.
/// </summary>
public class MergeEmailDocumentsResponse : ISpecPatch
{
  public string Name => "Merge EmailDocumentsResponse into EmailDocumentResponse";

  public bool Apply(OpenApiDocument document)
  {
    if (document.Components?.Schemas == null) return false;
    if (!document.Components.Schemas.ContainsKey("EmailDocumentsResponse")) return false;

    // Get the canonical schema to verify it exists
    if (!document.Components.Schemas.ContainsKey("EmailDocumentResponse"))
      return false;

    // Rewrite all references in paths
    if (document.Paths != null)
    {
      RewriteRefs(document, document.Paths);
    }

    // Remove the duplicate
    document.Components.Schemas.Remove("EmailDocumentsResponse");
    return true;
  }

  private void RewriteRefs(OpenApiDocument document, OpenApiPaths paths)
  {
    foreach (var path in paths.Values)
    {
      if (path.Operations == null) continue;
      foreach (var op in path.Operations.Values)
      {
        // Check response schemas
        if (op.Responses == null) continue;
        foreach (var response in op.Responses.Values)
        {
          if (response.Content == null) continue;
          foreach (var iContent in response.Content.Values)
          {
            if (iContent is not OpenApiMediaType content) continue;
            // In 3.x, content.Schema is IOpenApiSchema; check if it's an OpenApiSchemaReference
            if (content.Schema is OpenApiSchemaReference schemaRef &&
                schemaRef.Reference?.Id == "EmailDocumentsResponse")
            {
              content.Schema = new OpenApiSchemaReference("EmailDocumentResponse", document);
            }
          }
        }
      }
    }
  }
}
