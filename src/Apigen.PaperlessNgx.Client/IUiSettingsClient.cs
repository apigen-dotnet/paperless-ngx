using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for ui_settings operations
/// </summary>
public partial interface IUiSettingsClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/ui_settings/
  /// </summary>
  Task<UiSettingsView> UiSettingsRetrieveAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: POST /api/ui_settings/
  /// </summary>
  Task<UiSettingsView> UiSettingsCreateAsync(Apigen.PaperlessNgx.Models.UiSettingsViewRequest uiSettingsViewRequest, CancellationToken cancellationToken = default);

}
