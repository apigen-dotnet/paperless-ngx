using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for statistics operations
/// </summary>
public interface IStatisticsClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/statistics/
  /// </summary>
  Task<JsonElement> StatisticsRetrieveAsync();

}
