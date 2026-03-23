using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for storage_paths operations
/// </summary>
public interface IStoragePathsClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/storage_paths/
  /// </summary>
  Task<PaginatedStoragePathList> StoragePathsListAsync(StoragePathsListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /api/storage_paths/
  /// </summary>
  Task<StoragePath> StoragePathsCreateAsync(Apigen.PaperlessNgx.Models.StoragePathRequest storagePathRequest);

  /// <summary>
  /// 
  /// Operation: GET /api/storage_paths/{id}/
  /// </summary>
  Task<StoragePath> StoragePathsRetrieveAsync(int id, StoragePathsRetrieveRequest? request = null);

  /// <summary>
  /// 
  /// Operation: PUT /api/storage_paths/{id}/
  /// </summary>
  Task<StoragePath> StoragePathsUpdateAsync(int id, Apigen.PaperlessNgx.Models.StoragePathRequest storagePathRequest);

  /// <summary>
  /// 
  /// Operation: PATCH /api/storage_paths/{id}/
  /// </summary>
  Task<StoragePath> StoragePathsPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedStoragePathRequest patchedStoragePathRequest);

  /// <summary>
  /// 
  /// Operation: DELETE /api/storage_paths/{id}/
  /// </summary>
  Task StoragePathsDestroyAsync(int id);

  /// <summary>
  /// 
  /// Operation: POST /api/storage_paths/test/
  /// </summary>
  Task<StoragePath> StoragePathsTestCreateAsync(Apigen.PaperlessNgx.Models.StoragePathRequest storagePathRequest);

}
