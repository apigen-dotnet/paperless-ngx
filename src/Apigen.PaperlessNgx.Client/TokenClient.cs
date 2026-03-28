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
/// Client for token operations
/// </summary>
public class TokenClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal TokenClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// 
  /// Operation: POST /api/token/
  /// </summary>
  public async Task<PaperlessAuthToken> TokenCreateAsync(Apigen.PaperlessNgx.Models.PaperlessAuthTokenRequest paperlessAuthTokenRequest)
  {
    string url = "token/";

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    FormUrlEncodedContent content = paperlessAuthTokenRequest.ToFormUrlEncodedContent();
    HttpClientLog.RequestBody(_logger, "POST", "[application/x-www-form-urlencoded]");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    PaperlessAuthToken? result = JsonSerializer.Deserialize<PaperlessAuthToken>(responseContent, JsonConfig.Default);
    return result ?? new PaperlessAuthToken();
  }


}
