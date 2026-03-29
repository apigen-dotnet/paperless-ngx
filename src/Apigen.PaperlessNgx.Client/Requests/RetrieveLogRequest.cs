using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Request parameters for 
/// Operation: GET /api/logs/{id}/
/// </summary>
public class RetrieveLogRequest : BaseRequest
{
  /// <summary>
  /// Return only the last N entries from the log file
  /// </summary>
  [JsonPropertyName("limit")]
  public int? Limit { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Limit != null)
      queryParams["limit"] = Limit;

    return queryParams.ToQueryString();
  }
}
