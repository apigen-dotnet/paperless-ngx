using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for custom_fields operations
/// </summary>
public interface ICustomFieldsClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/custom_fields/
  /// </summary>
  Task<PaginatedCustomFieldList> CustomFieldsListAsync(CustomFieldsListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /api/custom_fields/
  /// </summary>
  Task<CustomField> CustomFieldsCreateAsync(Apigen.PaperlessNgx.Models.CustomFieldRequest customFieldRequest);

  /// <summary>
  /// 
  /// Operation: GET /api/custom_fields/{id}/
  /// </summary>
  Task<CustomField> CustomFieldsRetrieveAsync(int id);

  /// <summary>
  /// 
  /// Operation: PUT /api/custom_fields/{id}/
  /// </summary>
  Task<CustomField> CustomFieldsUpdateAsync(int id, Apigen.PaperlessNgx.Models.CustomFieldRequest customFieldRequest);

  /// <summary>
  /// 
  /// Operation: PATCH /api/custom_fields/{id}/
  /// </summary>
  Task<CustomField> CustomFieldsPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedCustomFieldRequest patchedCustomFieldRequest);

  /// <summary>
  /// 
  /// Operation: DELETE /api/custom_fields/{id}/
  /// </summary>
  Task CustomFieldsDestroyAsync(int id);

}
