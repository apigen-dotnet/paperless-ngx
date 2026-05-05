using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Request parameters for 
/// Operation: GET /api/search/
/// </summary>
public partial class SearchRetrieveRequest : BaseRequest
{
  /// <summary>
  /// Search only the database
  /// </summary>
  [JsonPropertyName("db_only")]
  public bool? DbOnly { get; set; }

  /// <summary>
  /// Query to search for
  /// </summary>
  [JsonPropertyName("query")]
  public string? Query { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (DbOnly != null)
      queryParams["db_only"] = DbOnly;
    if (Query != null)
      queryParams["query"] = Query;

    return queryParams.ToQueryString();
  }
}
