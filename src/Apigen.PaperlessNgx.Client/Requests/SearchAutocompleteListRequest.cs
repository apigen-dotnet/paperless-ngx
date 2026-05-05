using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Request parameters for 
/// Operation: GET /api/search/autocomplete/
/// </summary>
public partial class SearchAutocompleteListRequest : BaseRequest
{
  /// <summary>
  /// Number of completions to return
  /// </summary>
  [JsonPropertyName("limit")]
  public int? Limit { get; set; }

  /// <summary>
  /// Term to search for
  /// </summary>
  [JsonPropertyName("term")]
  public string? Term { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Limit != null)
      queryParams["limit"] = Limit;
    if (Term != null)
      queryParams["term"] = Term;

    return queryParams.ToQueryString();
  }
}
