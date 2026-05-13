using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for bulk_edit_objects operations
/// </summary>
public partial interface IBulkEditObjectsClient
{
  /// <summary>
  /// 
  /// Operation: POST /api/bulk_edit_objects/
  /// </summary>
  Task<BulkEditResult> BulkAsync(Apigen.PaperlessNgx.Models.BulkEditObjectsRequest bulkEditObjectsRequest, CancellationToken cancellationToken = default);

}
