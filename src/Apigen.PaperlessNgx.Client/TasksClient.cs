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
/// Client for tasks operations
/// </summary>
public class TasksClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal TasksClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// 
  /// Operation: GET /api/tasks/
  /// </summary>
  public async Task<List<TasksView>> TasksListAsync(TasksListRequest? request = null)
  {
    string url = "tasks/".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    List<TasksView>? result = JsonSerializer.Deserialize<List<TasksView>>(responseContent, JsonConfig.Default);
    return result ?? new List<TasksView>();
  }


  /// <summary>
  /// 
  /// Operation: GET /api/tasks/{id}/
  /// </summary>
  public async Task<TasksView> TasksRetrieveAsync(int id, TasksRetrieveRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "tasks/{id}/".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    TasksView? result = JsonSerializer.Deserialize<TasksView>(responseContent, JsonConfig.Default);
    return result ?? new TasksView();
  }


  /// <summary>
  /// 
  /// Operation: POST /api/tasks/acknowledge/
  /// </summary>
  public async Task<AcknowledgeTasks> AcknowledgeTasksAsync(Apigen.PaperlessNgx.Models.AcknowledgeTasksRequest acknowledgeTasksRequest, AcknowledgeTasksRequest? request = null)
  {
    string url = "tasks/acknowledge/".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(acknowledgeTasksRequest, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
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
    AcknowledgeTasks? result = JsonSerializer.Deserialize<AcknowledgeTasks>(responseContent, JsonConfig.Default);
    return result ?? new AcknowledgeTasks();
  }


  /// <summary>
  /// 
  /// Operation: POST /api/tasks/run/
  /// </summary>
  public async Task<TasksView> TasksRunCreateAsync(Apigen.PaperlessNgx.Models.TasksViewRequest tasksViewRequest, TasksRunCreateRequest? request = null)
  {
    string url = "tasks/run/".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(tasksViewRequest, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
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
    TasksView? result = JsonSerializer.Deserialize<TasksView>(responseContent, JsonConfig.Default);
    return result ?? new TasksView();
  }


}
