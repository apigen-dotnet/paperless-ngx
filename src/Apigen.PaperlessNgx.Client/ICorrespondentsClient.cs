using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for correspondents operations
/// </summary>
public partial interface ICorrespondentsClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/correspondents/
  /// </summary>
  Task<PaginatedCorrespondentList> CorrespondentsListAsync(CorrespondentsListRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: POST /api/correspondents/
  /// </summary>
  Task<Correspondent> CorrespondentsCreateAsync(Apigen.PaperlessNgx.Models.CorrespondentRequest correspondentRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/correspondents/{id}/
  /// </summary>
  Task<Correspondent> CorrespondentsRetrieveAsync(int id, CorrespondentsRetrieveRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /api/correspondents/{id}/
  /// </summary>
  Task<Correspondent> CorrespondentsUpdateAsync(int id, Apigen.PaperlessNgx.Models.CorrespondentRequest correspondentRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PATCH /api/correspondents/{id}/
  /// </summary>
  Task<Correspondent> CorrespondentsPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedCorrespondentRequest patchedCorrespondentRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: DELETE /api/correspondents/{id}/
  /// </summary>
  Task CorrespondentsDestroyAsync(int id, CancellationToken cancellationToken = default);

}
