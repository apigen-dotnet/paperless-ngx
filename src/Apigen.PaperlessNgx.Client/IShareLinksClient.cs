using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for share_links operations
/// </summary>
public interface IShareLinksClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/share_links/
  /// </summary>
  Task<PaginatedShareLinkList> ShareLinksListAsync(ShareLinksListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /api/share_links/
  /// </summary>
  Task<ShareLink> ShareLinksCreateAsync(Apigen.PaperlessNgx.Models.ShareLinkRequest shareLinkRequest);

  /// <summary>
  /// 
  /// Operation: GET /api/share_links/{id}/
  /// </summary>
  Task<ShareLink> ShareLinksRetrieveAsync(int id);

  /// <summary>
  /// 
  /// Operation: PUT /api/share_links/{id}/
  /// </summary>
  Task<ShareLink> ShareLinksUpdateAsync(int id, Apigen.PaperlessNgx.Models.ShareLinkRequest shareLinkRequest);

  /// <summary>
  /// 
  /// Operation: PATCH /api/share_links/{id}/
  /// </summary>
  Task<ShareLink> ShareLinksPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedShareLinkRequest patchedShareLinkRequest);

  /// <summary>
  /// 
  /// Operation: DELETE /api/share_links/{id}/
  /// </summary>
  Task ShareLinksDestroyAsync(int id);

}
