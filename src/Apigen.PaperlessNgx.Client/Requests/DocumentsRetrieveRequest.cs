using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Request parameters for 
/// Operation: GET /api/documents/{id}/
/// </summary>
public partial class DocumentsRetrieveRequest : BaseRequest
{
  /// <summary>
  /// fields
  /// </summary>
  [JsonPropertyName("fields")]
  public string[]? Fields { get; set; }

  /// <summary>
  /// full_perms
  /// </summary>
  [JsonPropertyName("full_perms")]
  public bool? FullPerms { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Fields != null)
      queryParams["fields"] = Fields;
    if (FullPerms != null)
      queryParams["full_perms"] = FullPerms;

    return queryParams.ToQueryString();
  }
}
