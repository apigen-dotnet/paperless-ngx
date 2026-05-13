using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for config operations
/// </summary>
public partial interface IConfigClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/config/
  /// </summary>
  Task<List<ApplicationConfiguration>> ConfigListAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/config/{id}/
  /// </summary>
  Task<ApplicationConfiguration> ConfigRetrieveAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /api/config/{id}/
  /// </summary>
  Task<ApplicationConfiguration> ConfigUpdateAsync(int id, Apigen.PaperlessNgx.Models.ApplicationConfigurationRequest applicationConfigurationRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PATCH /api/config/{id}/
  /// </summary>
  Task<ApplicationConfiguration> ConfigPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedApplicationConfigurationRequest patchedApplicationConfigurationRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: DELETE /api/config/{id}/
  /// </summary>
  Task ConfigDestroyAsync(int id, CancellationToken cancellationToken = default);

}
