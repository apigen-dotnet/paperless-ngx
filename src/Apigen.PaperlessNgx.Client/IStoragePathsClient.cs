using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for storage_paths operations
/// </summary>
public partial interface IStoragePathsClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/storage_paths/
  /// </summary>
  Task<PaginatedStoragePathList> StoragePathsListAsync(StoragePathsListRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: POST /api/storage_paths/
  /// </summary>
  Task<StoragePath> StoragePathsCreateAsync(Apigen.PaperlessNgx.Models.StoragePathRequest storagePathRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/storage_paths/{id}/
  /// </summary>
  Task<StoragePath> StoragePathsRetrieveAsync(int id, StoragePathsRetrieveRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /api/storage_paths/{id}/
  /// </summary>
  Task<StoragePath> StoragePathsUpdateAsync(int id, Apigen.PaperlessNgx.Models.StoragePathRequest storagePathRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PATCH /api/storage_paths/{id}/
  /// </summary>
  Task<StoragePath> StoragePathsPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedStoragePathRequest patchedStoragePathRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: DELETE /api/storage_paths/{id}/
  /// </summary>
  Task StoragePathsDestroyAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: POST /api/storage_paths/test/
  /// </summary>
  Task<StoragePath> StoragePathsTestCreateAsync(Apigen.PaperlessNgx.Models.StoragePathRequest storagePathRequest, CancellationToken cancellationToken = default);

}
