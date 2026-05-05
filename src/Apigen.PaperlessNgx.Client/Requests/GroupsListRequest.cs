using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Request parameters for 
/// Operation: GET /api/groups/
/// </summary>
public partial class GroupsListRequest : BaseRequest
{
  /// <summary>
  /// name__icontains
  /// </summary>
  [JsonPropertyName("name__icontains")]
  public string? NameIcontains { get; set; }

  /// <summary>
  /// name__iendswith
  /// </summary>
  [JsonPropertyName("name__iendswith")]
  public string? NameIendswith { get; set; }

  /// <summary>
  /// name__iexact
  /// </summary>
  [JsonPropertyName("name__iexact")]
  public string? NameIexact { get; set; }

  /// <summary>
  /// name__istartswith
  /// </summary>
  [JsonPropertyName("name__istartswith")]
  public string? NameIstartswith { get; set; }

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

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (NameIcontains != null)
      queryParams["name__icontains"] = NameIcontains;
    if (NameIendswith != null)
      queryParams["name__iendswith"] = NameIendswith;
    if (NameIexact != null)
      queryParams["name__iexact"] = NameIexact;
    if (NameIstartswith != null)
      queryParams["name__istartswith"] = NameIstartswith;
    if (Ordering != null)
      queryParams["ordering"] = Ordering;
    if (Page != null)
      queryParams["page"] = Page;
    if (PageSize != null)
      queryParams["page_size"] = PageSize;

    return queryParams.ToQueryString();
  }
}
