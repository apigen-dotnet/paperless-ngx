using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for oauth operations
/// </summary>
public interface IOAuthClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/oauth/callback/
  /// </summary>
  Task OauthCallbackRetrieveAsync();

}
