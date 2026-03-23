using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for token operations
/// </summary>
public interface ITokenClient
{
  /// <summary>
  /// 
  /// Operation: POST /api/token/
  /// </summary>
  Task<PaperlessAuthToken> TokenCreateAsync(Apigen.PaperlessNgx.Models.PaperlessAuthTokenRequest paperlessAuthTokenRequest);

}
