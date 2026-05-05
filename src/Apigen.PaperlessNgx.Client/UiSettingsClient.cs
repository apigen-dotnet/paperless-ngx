using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Client for ui_settings operations
/// </summary>
public partial class UiSettingsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal UiSettingsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// 
  /// Operation: GET /api/ui_settings/
  /// </summary>
  public async Task<UiSettingsView> UiSettingsRetrieveAsync()
  {
    string url = "ui_settings/";

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    UiSettingsView? result = JsonSerializer.Deserialize<UiSettingsView>(responseContent, JsonConfig.Default);
    return result ?? new UiSettingsView();
  }


  /// <summary>
  /// 
  /// Operation: POST /api/ui_settings/
  /// </summary>
  public async Task<UiSettingsView> UiSettingsCreateAsync(Apigen.PaperlessNgx.Models.UiSettingsViewRequest uiSettingsViewRequest)
  {
    string url = "ui_settings/";

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(uiSettingsViewRequest, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    UiSettingsView? result = JsonSerializer.Deserialize<UiSettingsView>(responseContent, JsonConfig.Default);
    return result ?? new UiSettingsView();
  }


}
