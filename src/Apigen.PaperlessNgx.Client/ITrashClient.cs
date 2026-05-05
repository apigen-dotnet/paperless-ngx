using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for trash operations
/// </summary>
public partial interface ITrashClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/trash/
  /// </summary>
  Task TrashListAsync(TrashListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /api/trash/
  /// </summary>
  Task TrashCreateAsync(Apigen.PaperlessNgx.Models.TrashRequest trashRequest);

}
