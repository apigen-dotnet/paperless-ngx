using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for processed_mail operations
/// </summary>
public partial interface IProcessedMailClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/processed_mail/
  /// </summary>
  Task<PaginatedProcessedMailList> ProcessedMailListAsync(ProcessedMailListRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/processed_mail/{id}/
  /// </summary>
  Task<ProcessedMail> ProcessedMailRetrieveAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: POST /api/processed_mail/bulk_delete/
  /// </summary>
  Task<ProcessedMail> BulkAsync(Apigen.PaperlessNgx.Models.ProcessedMailRequest processedMailRequest, CancellationToken cancellationToken = default);

}
