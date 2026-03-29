using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Request parameters for 
/// Operation: POST /api/documents/{id}/notes/
/// </summary>
public class DocumentsNotesCreateRequest : BaseRequest
{
  /// <summary>
  /// Note ID to delete (used only for DELETE requests)
  /// </summary>
  [JsonPropertyName("id")]
  public int? Id { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Id != null)
      queryParams["id"] = Id;

    return queryParams.ToQueryString();
  }
}
