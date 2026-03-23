using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Request parameters for 
/// Operation: GET /api/share_links/
/// </summary>
public class ShareLinksListRequest : BaseRequest
{
  /// <summary>
  /// created__date__gt
  /// </summary>
  [JsonPropertyName("created__date__gt")]
  public string? CreatedDateGt { get; set; }

  /// <summary>
  /// created__date__gte
  /// </summary>
  [JsonPropertyName("created__date__gte")]
  public string? CreatedDateGte { get; set; }

  /// <summary>
  /// created__date__lt
  /// </summary>
  [JsonPropertyName("created__date__lt")]
  public string? CreatedDateLt { get; set; }

  /// <summary>
  /// created__date__lte
  /// </summary>
  [JsonPropertyName("created__date__lte")]
  public string? CreatedDateLte { get; set; }

  /// <summary>
  /// created__day
  /// </summary>
  [JsonPropertyName("created__day")]
  public decimal? CreatedDay { get; set; }

  /// <summary>
  /// created__gt
  /// </summary>
  [JsonPropertyName("created__gt")]
  public string? CreatedGt { get; set; }

  /// <summary>
  /// created__gte
  /// </summary>
  [JsonPropertyName("created__gte")]
  public string? CreatedGte { get; set; }

  /// <summary>
  /// created__lt
  /// </summary>
  [JsonPropertyName("created__lt")]
  public string? CreatedLt { get; set; }

  /// <summary>
  /// created__lte
  /// </summary>
  [JsonPropertyName("created__lte")]
  public string? CreatedLte { get; set; }

  /// <summary>
  /// created__month
  /// </summary>
  [JsonPropertyName("created__month")]
  public decimal? CreatedMonth { get; set; }

  /// <summary>
  /// created__year
  /// </summary>
  [JsonPropertyName("created__year")]
  public decimal? CreatedYear { get; set; }

  /// <summary>
  /// expiration__date__gt
  /// </summary>
  [JsonPropertyName("expiration__date__gt")]
  public string? ExpirationDateGt { get; set; }

  /// <summary>
  /// expiration__date__gte
  /// </summary>
  [JsonPropertyName("expiration__date__gte")]
  public string? ExpirationDateGte { get; set; }

  /// <summary>
  /// expiration__date__lt
  /// </summary>
  [JsonPropertyName("expiration__date__lt")]
  public string? ExpirationDateLt { get; set; }

  /// <summary>
  /// expiration__date__lte
  /// </summary>
  [JsonPropertyName("expiration__date__lte")]
  public string? ExpirationDateLte { get; set; }

  /// <summary>
  /// expiration__day
  /// </summary>
  [JsonPropertyName("expiration__day")]
  public decimal? ExpirationDay { get; set; }

  /// <summary>
  /// expiration__gt
  /// </summary>
  [JsonPropertyName("expiration__gt")]
  public string? ExpirationGt { get; set; }

  /// <summary>
  /// expiration__gte
  /// </summary>
  [JsonPropertyName("expiration__gte")]
  public string? ExpirationGte { get; set; }

  /// <summary>
  /// expiration__lt
  /// </summary>
  [JsonPropertyName("expiration__lt")]
  public string? ExpirationLt { get; set; }

  /// <summary>
  /// expiration__lte
  /// </summary>
  [JsonPropertyName("expiration__lte")]
  public string? ExpirationLte { get; set; }

  /// <summary>
  /// expiration__month
  /// </summary>
  [JsonPropertyName("expiration__month")]
  public decimal? ExpirationMonth { get; set; }

  /// <summary>
  /// expiration__year
  /// </summary>
  [JsonPropertyName("expiration__year")]
  public decimal? ExpirationYear { get; set; }

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

    if (CreatedDateGt != null)
      queryParams["created__date__gt"] = CreatedDateGt;
    if (CreatedDateGte != null)
      queryParams["created__date__gte"] = CreatedDateGte;
    if (CreatedDateLt != null)
      queryParams["created__date__lt"] = CreatedDateLt;
    if (CreatedDateLte != null)
      queryParams["created__date__lte"] = CreatedDateLte;
    if (CreatedDay != null)
      queryParams["created__day"] = CreatedDay;
    if (CreatedGt != null)
      queryParams["created__gt"] = CreatedGt;
    if (CreatedGte != null)
      queryParams["created__gte"] = CreatedGte;
    if (CreatedLt != null)
      queryParams["created__lt"] = CreatedLt;
    if (CreatedLte != null)
      queryParams["created__lte"] = CreatedLte;
    if (CreatedMonth != null)
      queryParams["created__month"] = CreatedMonth;
    if (CreatedYear != null)
      queryParams["created__year"] = CreatedYear;
    if (ExpirationDateGt != null)
      queryParams["expiration__date__gt"] = ExpirationDateGt;
    if (ExpirationDateGte != null)
      queryParams["expiration__date__gte"] = ExpirationDateGte;
    if (ExpirationDateLt != null)
      queryParams["expiration__date__lt"] = ExpirationDateLt;
    if (ExpirationDateLte != null)
      queryParams["expiration__date__lte"] = ExpirationDateLte;
    if (ExpirationDay != null)
      queryParams["expiration__day"] = ExpirationDay;
    if (ExpirationGt != null)
      queryParams["expiration__gt"] = ExpirationGt;
    if (ExpirationGte != null)
      queryParams["expiration__gte"] = ExpirationGte;
    if (ExpirationLt != null)
      queryParams["expiration__lt"] = ExpirationLt;
    if (ExpirationLte != null)
      queryParams["expiration__lte"] = ExpirationLte;
    if (ExpirationMonth != null)
      queryParams["expiration__month"] = ExpirationMonth;
    if (ExpirationYear != null)
      queryParams["expiration__year"] = ExpirationYear;
    if (Ordering != null)
      queryParams["ordering"] = Ordering;
    if (Page != null)
      queryParams["page"] = Page;
    if (PageSize != null)
      queryParams["page_size"] = PageSize;

    return queryParams.ToQueryString();
  }
}
