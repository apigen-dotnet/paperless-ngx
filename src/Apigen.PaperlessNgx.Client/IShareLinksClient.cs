using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for share_links operations
/// </summary>
public partial interface IShareLinksClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/share_links/
  /// </summary>
  Task<PaginatedShareLinkList> ShareLinksListAsync(ShareLinksListRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: POST /api/share_links/
  /// </summary>
  Task<ShareLink> ShareLinksCreateAsync(Apigen.PaperlessNgx.Models.ShareLinkRequest shareLinkRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/share_links/{id}/
  /// </summary>
  Task<ShareLink> ShareLinksRetrieveAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /api/share_links/{id}/
  /// </summary>
  Task<ShareLink> ShareLinksUpdateAsync(int id, Apigen.PaperlessNgx.Models.ShareLinkRequest shareLinkRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PATCH /api/share_links/{id}/
  /// </summary>
  Task<ShareLink> ShareLinksPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.ShareLinkRequest shareLinkRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: DELETE /api/share_links/{id}/
  /// </summary>
  Task ShareLinksDestroyAsync(int id, CancellationToken cancellationToken = default);

}
