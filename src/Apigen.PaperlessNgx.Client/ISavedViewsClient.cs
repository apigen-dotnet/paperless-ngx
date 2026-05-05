using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for saved_views operations
/// </summary>
public partial interface ISavedViewsClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/saved_views/
  /// </summary>
  Task<PaginatedSavedViewList> SavedViewsListAsync(SavedViewsListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /api/saved_views/
  /// </summary>
  Task<SavedView> SavedViewsCreateAsync(Apigen.PaperlessNgx.Models.SavedViewRequest savedViewRequest);

  /// <summary>
  /// 
  /// Operation: GET /api/saved_views/{id}/
  /// </summary>
  Task<SavedView> SavedViewsRetrieveAsync(int id);

  /// <summary>
  /// 
  /// Operation: PUT /api/saved_views/{id}/
  /// </summary>
  Task<SavedView> SavedViewsUpdateAsync(int id, Apigen.PaperlessNgx.Models.SavedViewRequest savedViewRequest);

  /// <summary>
  /// 
  /// Operation: PATCH /api/saved_views/{id}/
  /// </summary>
  Task<SavedView> SavedViewsPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedSavedViewRequest patchedSavedViewRequest);

  /// <summary>
  /// 
  /// Operation: DELETE /api/saved_views/{id}/
  /// </summary>
  Task SavedViewsDestroyAsync(int id);

}
