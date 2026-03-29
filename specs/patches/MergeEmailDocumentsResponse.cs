using Microsoft.OpenApi.Models;
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

    // Get the canonical schema to use as replacement
    if (!document.Components.Schemas.TryGetValue("EmailDocumentResponse", out OpenApiSchema? canonical))
      return false;

    // Rewrite all references in paths
    if (document.Paths != null)
    {
      RewriteRefs(document.Paths);
    }

    // Remove the duplicate
    document.Components.Schemas.Remove("EmailDocumentsResponse");
    return true;
  }

  private void RewriteRefs(OpenApiPaths paths)
  {
    foreach (var path in paths.Values)
    {
      foreach (var op in path.Operations.Values)
      {
        // Check response schemas
        foreach (var response in op.Responses.Values)
        {
          if (response.Content == null) continue;
          foreach (var content in response.Content.Values)
          {
            if (content.Schema?.Reference?.Id == "EmailDocumentsResponse")
            {
              content.Schema.Reference = new OpenApiReference
              {
                Type = ReferenceType.Schema,
                Id = "EmailDocumentResponse"
              };
            }
          }
        }
      }
    }
  }
}
