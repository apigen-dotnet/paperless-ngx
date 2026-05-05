using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Request parameters for 
/// Operation: GET /api/users/
/// </summary>
public partial class UsersListRequest : BaseRequest
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
  /// username__icontains
  /// </summary>
  [JsonPropertyName("username__icontains")]
  public string? UsernameIcontains { get; set; }

  /// <summary>
  /// username__iendswith
  /// </summary>
  [JsonPropertyName("username__iendswith")]
  public string? UsernameIendswith { get; set; }

  /// <summary>
  /// username__iexact
  /// </summary>
  [JsonPropertyName("username__iexact")]
  public string? UsernameIexact { get; set; }

  /// <summary>
  /// username__istartswith
  /// </summary>
  [JsonPropertyName("username__istartswith")]
  public string? UsernameIstartswith { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Ordering != null)
      queryParams["ordering"] = Ordering;
    if (Page != null)
      queryParams["page"] = Page;
    if (PageSize != null)
      queryParams["page_size"] = PageSize;
    if (UsernameIcontains != null)
      queryParams["username__icontains"] = UsernameIcontains;
    if (UsernameIendswith != null)
      queryParams["username__iendswith"] = UsernameIendswith;
    if (UsernameIexact != null)
      queryParams["username__iexact"] = UsernameIexact;
    if (UsernameIstartswith != null)
      queryParams["username__istartswith"] = UsernameIstartswith;

    return queryParams.ToQueryString();
  }
}
