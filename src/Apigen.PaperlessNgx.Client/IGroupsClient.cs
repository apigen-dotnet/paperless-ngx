using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for groups operations
/// </summary>
public partial interface IGroupsClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/groups/
  /// </summary>
  Task<PaginatedGroupList> GroupsListAsync(GroupsListRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: POST /api/groups/
  /// </summary>
  Task<Group> GroupsCreateAsync(Apigen.PaperlessNgx.Models.GroupRequest groupRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/groups/{id}/
  /// </summary>
  Task<Group> GroupsRetrieveAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /api/groups/{id}/
  /// </summary>
  Task<Group> GroupsUpdateAsync(int id, Apigen.PaperlessNgx.Models.GroupRequest groupRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PATCH /api/groups/{id}/
  /// </summary>
  Task<Group> GroupsPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedGroupRequest patchedGroupRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: DELETE /api/groups/{id}/
  /// </summary>
  Task GroupsDestroyAsync(int id, CancellationToken cancellationToken = default);

}
