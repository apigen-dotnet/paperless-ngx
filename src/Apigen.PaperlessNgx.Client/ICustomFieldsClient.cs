using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for custom_fields operations
/// </summary>
public partial interface ICustomFieldsClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/custom_fields/
  /// </summary>
  Task<PaginatedCustomFieldList> CustomFieldsListAsync(CustomFieldsListRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: POST /api/custom_fields/
  /// </summary>
  Task<CustomField> CustomFieldsCreateAsync(Apigen.PaperlessNgx.Models.CustomFieldRequest customFieldRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/custom_fields/{id}/
  /// </summary>
  Task<CustomField> CustomFieldsRetrieveAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /api/custom_fields/{id}/
  /// </summary>
  Task<CustomField> CustomFieldsUpdateAsync(int id, Apigen.PaperlessNgx.Models.CustomFieldRequest customFieldRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PATCH /api/custom_fields/{id}/
  /// </summary>
  Task<CustomField> CustomFieldsPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedCustomFieldRequest patchedCustomFieldRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: DELETE /api/custom_fields/{id}/
  /// </summary>
  Task CustomFieldsDestroyAsync(int id, CancellationToken cancellationToken = default);

}
