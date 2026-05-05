using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Request parameters for 
/// Operation: GET /api/documents/{id}/download/
/// </summary>
public partial class DocumentsDownloadRetrieveRequest : BaseRequest
{
  /// <summary>
  /// original
  /// </summary>
  [JsonPropertyName("original")]
  public bool? Original { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Original != null)
      queryParams["original"] = Original;

    return queryParams.ToQueryString();
  }
}
