using System.Text.Json;
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
  Task<PaginatedProcessedMailList> ProcessedMailListAsync(ProcessedMailListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: GET /api/processed_mail/{id}/
  /// </summary>
  Task<ProcessedMail> ProcessedMailRetrieveAsync(int id);

  /// <summary>
  /// 
  /// Operation: POST /api/processed_mail/bulk_delete/
  /// </summary>
  Task<ProcessedMail> BulkAsync(Apigen.PaperlessNgx.Models.ProcessedMailRequest processedMailRequest);

}
