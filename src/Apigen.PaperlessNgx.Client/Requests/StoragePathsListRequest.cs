using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Request parameters for 
/// Operation: GET /api/storage_paths/
/// </summary>
public partial class StoragePathsListRequest : BaseRequest
{
  /// <summary>
  /// full_perms
  /// </summary>
  [JsonPropertyName("full_perms")]
  public bool? FullPerms { get; set; }

  /// <summary>
  /// id
  /// </summary>
  [JsonPropertyName("id")]
  public int? Id { get; set; }

  /// <summary>
  /// Multiple values may be separated by commas.
  /// </summary>
  [JsonPropertyName("id__in")]
  public string[]? IdIn { get; set; }

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

  /// <summary>
  /// path__icontains
  /// </summary>
  [JsonPropertyName("path__icontains")]
  public string? PathIcontains { get; set; }

  /// <summary>
  /// path__iendswith
  /// </summary>
  [JsonPropertyName("path__iendswith")]
  public string? PathIendswith { get; set; }

  /// <summary>
  /// path__iexact
  /// </summary>
  [JsonPropertyName("path__iexact")]
  public string? PathIexact { get; set; }

  /// <summary>
  /// path__istartswith
  /// </summary>
  [JsonPropertyName("path__istartswith")]
  public string? PathIstartswith { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (FullPerms != null)
      queryParams["full_perms"] = FullPerms;
    if (Id != null)
      queryParams["id"] = Id;
    if (IdIn != null)
      queryParams["id__in"] = IdIn;
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
    if (PathIcontains != null)
      queryParams["path__icontains"] = PathIcontains;
    if (PathIendswith != null)
      queryParams["path__iendswith"] = PathIendswith;
    if (PathIexact != null)
      queryParams["path__iexact"] = PathIexact;
    if (PathIstartswith != null)
      queryParams["path__istartswith"] = PathIstartswith;

    return queryParams.ToQueryString();
  }
}
