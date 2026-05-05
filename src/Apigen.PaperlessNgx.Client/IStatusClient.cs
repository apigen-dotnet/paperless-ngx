using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for status operations
/// </summary>
public partial interface IStatusClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/status/
  /// </summary>
  Task<SystemStatus> StatusRetrieveAsync();

}
