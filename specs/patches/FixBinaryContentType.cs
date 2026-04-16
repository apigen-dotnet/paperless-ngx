using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi;
using Apigen.Generator;

/// <summary>
/// Fix download/preview/thumb endpoints that incorrectly declare application/json
/// as content type for binary file responses. Changes them to application/octet-stream
/// so the generator produces Stream return types instead of JsonElement.
/// </summary>
public class FixBinaryContentType : ISpecPatch
{
  public string Name => "Fix binary content type on download endpoints";

  private static readonly List<(string Method, string Path)> Endpoints = new()
  {
    ("GET", "/api/documents/{id}/download/"),
    ("GET", "/api/documents/{id}/preview/"),
    ("GET", "/api/documents/{id}/thumb/"),
  };

  public bool Apply(OpenApiDocument document)
  {
    if (document.Paths == null) return false;

    int count = 0;
    foreach (var (methodStr, path) in Endpoints)
    {
      if (!document.Paths.TryGetValue(path, out IOpenApiPathItem? iPathItem)) continue;
      if (iPathItem is not OpenApiPathItem pathItem) continue;
      if (pathItem.Operations == null) continue;

      var httpMethod = new System.Net.Http.HttpMethod(methodStr);
      if (!pathItem.Operations.TryGetValue(httpMethod, out OpenApiOperation? operation)) continue;
      if (operation.Responses == null) continue;

      var successResponse = operation.Responses.FirstOrDefault(r => r.Key.StartsWith("2"));
      if (successResponse.Value == null) continue;
      if (successResponse.Value is not OpenApiResponse response) continue;
      if (response.Content == null) continue;

      // Replace application/json with application/octet-stream for binary responses
      if (response.Content.TryGetValue("application/json", out IOpenApiMediaType? mediaType))
      {
        response.Content.Remove("application/json");
        response.Content["application/octet-stream"] = mediaType;
        count++;
      }
    }

    return count > 0;
  }
}
