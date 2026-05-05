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
/// Client for storage_paths operations
/// </summary>
public partial class StoragePathsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal StoragePathsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// 
  /// Operation: GET /api/storage_paths/
  /// </summary>
  public async Task<PaginatedStoragePathList> StoragePathsListAsync(StoragePathsListRequest? request = null)
  {
    string url = "storage_paths/".BuildUrl(request: request);

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
    PaginatedStoragePathList? result = JsonSerializer.Deserialize<PaginatedStoragePathList>(responseContent, JsonConfig.Default);
    return result ?? new PaginatedStoragePathList();
  }


  /// <summary>
  /// 
  /// Operation: POST /api/storage_paths/
  /// </summary>
  public async Task<StoragePath> StoragePathsCreateAsync(Apigen.PaperlessNgx.Models.StoragePathRequest storagePathRequest)
  {
    string url = "storage_paths/";

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(storagePathRequest, JsonConfig.Default);
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
    StoragePath? result = JsonSerializer.Deserialize<StoragePath>(responseContent, JsonConfig.Default);
    return result ?? new StoragePath();
  }


  /// <summary>
  /// 
  /// Operation: GET /api/storage_paths/{id}/
  /// </summary>
  public async Task<StoragePath> StoragePathsRetrieveAsync(int id, StoragePathsRetrieveRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "storage_paths/{id}/".BuildUrl(pathParams, request);

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
    StoragePath? result = JsonSerializer.Deserialize<StoragePath>(responseContent, JsonConfig.Default);
    return result ?? new StoragePath();
  }


  /// <summary>
  /// 
  /// Operation: PUT /api/storage_paths/{id}/
  /// </summary>
  public async Task<StoragePath> StoragePathsUpdateAsync(int id, Apigen.PaperlessNgx.Models.StoragePathRequest storagePathRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "storage_paths/{id}/".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(storagePathRequest, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "PUT", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PutAsync(url, content);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "PUT", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "PUT", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    StoragePath? result = JsonSerializer.Deserialize<StoragePath>(responseContent, JsonConfig.Default);
    return result ?? new StoragePath();
  }


  /// <summary>
  /// 
  /// Operation: PATCH /api/storage_paths/{id}/
  /// </summary>
  public async Task<StoragePath> StoragePathsPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedStoragePathRequest patchedStoragePathRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "storage_paths/{id}/".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PATCH", url);
    string json = JsonSerializer.Serialize(patchedStoragePathRequest, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "PATCH", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PatchAsync(url, content);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "PATCH", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "PATCH", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    StoragePath? result = JsonSerializer.Deserialize<StoragePath>(responseContent, JsonConfig.Default);
    return result ?? new StoragePath();
  }


  /// <summary>
  /// 
  /// Operation: DELETE /api/storage_paths/{id}/
  /// </summary>
  public async Task StoragePathsDestroyAsync(int id)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "storage_paths/{id}/".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "DELETE", url);
    HttpResponseMessage response = await _httpClient.DeleteAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "DELETE", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "DELETE", url, responseContent, ex);
      throw;
    }
  }


  /// <summary>
  /// 
  /// Operation: POST /api/storage_paths/test/
  /// </summary>
  public async Task<StoragePath> StoragePathsTestCreateAsync(Apigen.PaperlessNgx.Models.StoragePathRequest storagePathRequest)
  {
    string url = "storage_paths/test/";

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(storagePathRequest, JsonConfig.Default);
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
    StoragePath? result = JsonSerializer.Deserialize<StoragePath>(responseContent, JsonConfig.Default);
    return result ?? new StoragePath();
  }


}
