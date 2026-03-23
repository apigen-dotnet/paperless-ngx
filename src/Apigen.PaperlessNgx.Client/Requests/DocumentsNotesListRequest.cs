using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Request parameters for 
/// Operation: GET /api/documents/{id}/notes/
/// </summary>
public class DocumentsNotesListRequest : BaseRequest
{
  /// <summary>
  /// Note ID to delete (used only for DELETE requests)
  /// </summary>
  [JsonPropertyName("id")]
  public int? Id { get; set; }

  /// <summary>
  /// A page number within the paginated result set.
  /// </summary>
  [JsonPropertyName("page")]
  public int? Page { get; set; }

  /// <summary>
  /// Number of results to return per page.
  /// </summary>
  [JsonPropertyName("page_size")]
  public int? PageSize { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Id != null)
      queryParams["id"] = Id;
    if (Page != null)
      queryParams["page"] = Page;
    if (PageSize != null)
      queryParams["page_size"] = PageSize;

    return queryParams.ToQueryString();
  }
}
