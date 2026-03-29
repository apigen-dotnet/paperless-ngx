using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Request parameters for 
/// Operation: GET /api/processed_mail/
/// </summary>
public class ProcessedMailListRequest : BaseRequest
{
  /// <summary>
  /// Which field to use when ordering the results.
  /// </summary>
  [JsonPropertyName("ordering")]
  public string? Ordering { get; set; }

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

  /// <summary>
  /// rule
  /// </summary>
  [JsonPropertyName("rule")]
  public int? Rule { get; set; }

  /// <summary>
  /// status
  /// </summary>
  [JsonPropertyName("status")]
  public string? Status { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Ordering != null)
      queryParams["ordering"] = Ordering;
    if (Page != null)
      queryParams["page"] = Page;
    if (PageSize != null)
      queryParams["page_size"] = PageSize;
    if (Rule != null)
      queryParams["rule"] = Rule;
    if (Status != null)
      queryParams["status"] = Status;

    return queryParams.ToQueryString();
  }
}
