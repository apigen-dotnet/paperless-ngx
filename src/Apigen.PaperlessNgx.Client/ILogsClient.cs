using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for logs operations
/// </summary>
public interface ILogsClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/logs/
  /// </summary>
  Task<JsonElement> LogsListAsync();

  /// <summary>
  /// 
  /// Operation: GET /api/logs/{id}/
  /// </summary>
  Task<JsonElement> RetrieveLogAsync(string id);

}
