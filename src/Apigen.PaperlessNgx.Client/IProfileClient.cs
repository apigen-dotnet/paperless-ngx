using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for profile operations
/// </summary>
public interface IProfileClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/profile/
  /// </summary>
  Task<Profile> ProfileRetrieveAsync();

  /// <summary>
  /// 
  /// Operation: PATCH /api/profile/
  /// </summary>
  Task<Profile> ProfilePartialUpdateAsync(Apigen.PaperlessNgx.Models.PatchedProfileRequest patchedProfileRequest);

  /// <summary>
  /// 
  /// Operation: POST /api/profile/disconnect_social_account/
  /// </summary>
  Task<JsonElement> ProfileDisconnectSocialAccountCreateAsync(Apigen.PaperlessNgx.Models.ProfileDisconnectSocialAccountCreateRequest profileDisconnectSocialAccountCreateRequest);

  /// <summary>
  /// 
  /// Operation: POST /api/profile/generate_auth_token/
  /// </summary>
  Task<JsonElement> ProfileGenerateAuthTokenCreateAsync();

  /// <summary>
  /// 
  /// Operation: GET /api/profile/social_account_providers/
  /// </summary>
  Task<JsonElement> ProfileSocialAccountProvidersRetrieveAsync();

  /// <summary>
  /// 
  /// Operation: GET /api/profile/totp/
  /// </summary>
  Task<JsonElement> ProfileTotpRetrieveAsync();

  /// <summary>
  /// 
  /// Operation: POST /api/profile/totp/
  /// </summary>
  Task<JsonElement> ProfileTotpCreateAsync(Apigen.PaperlessNgx.Models.ProfileTotpCreateRequest profileTotpCreateRequest);

  /// <summary>
  /// 
  /// Operation: DELETE /api/profile/totp/
  /// </summary>
  Task<JsonElement> ProfileTotpDestroyAsync();

}
