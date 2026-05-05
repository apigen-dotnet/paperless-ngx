using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for users operations
/// </summary>
public partial interface IUsersClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/users/
  /// </summary>
  Task<PaginatedUserList> UsersListAsync(UsersListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /api/users/
  /// </summary>
  Task<User> UsersCreateAsync(Apigen.PaperlessNgx.Models.UserRequest userRequest);

  /// <summary>
  /// 
  /// Operation: GET /api/users/{id}/
  /// </summary>
  Task<User> UsersRetrieveAsync(int id);

  /// <summary>
  /// 
  /// Operation: PUT /api/users/{id}/
  /// </summary>
  Task<User> UsersUpdateAsync(int id, Apigen.PaperlessNgx.Models.UserRequest userRequest);

  /// <summary>
  /// 
  /// Operation: PATCH /api/users/{id}/
  /// </summary>
  Task<User> UsersPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedUserRequest patchedUserRequest);

  /// <summary>
  /// 
  /// Operation: DELETE /api/users/{id}/
  /// </summary>
  Task UsersDestroyAsync(int id);

  /// <summary>
  /// 
  /// Operation: POST /api/users/{id}/deactivate_totp/
  /// </summary>
  Task<JsonElement> UsersDeactivateTotpCreateAsync(int id);

}
