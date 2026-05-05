using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for remote_version operations
/// </summary>
public partial interface IRemoteVersionClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/remote_version/
  /// </summary>
  Task<JsonElement> RemoteVersionRetrieveAsync();

}
