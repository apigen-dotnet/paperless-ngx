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
/// Client for mail_rules operations
/// </summary>
public class MailRulesClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal MailRulesClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// 
  /// Operation: GET /api/mail_rules/
  /// </summary>
  public async Task<PaginatedMailRuleList> MailRulesListAsync(MailRulesListRequest? request = null)
  {
    string url = "mail_rules/".BuildUrl(request: request);

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
    PaginatedMailRuleList? result = JsonSerializer.Deserialize<PaginatedMailRuleList>(responseContent, JsonConfig.Default);
    return result ?? new PaginatedMailRuleList();
  }


  /// <summary>
  /// 
  /// Operation: POST /api/mail_rules/
  /// </summary>
  public async Task<MailRule> MailRulesCreateAsync(Apigen.PaperlessNgx.Models.MailRuleRequest mailRuleRequest)
  {
    string url = "mail_rules/";

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(mailRuleRequest, JsonConfig.Default);
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
    MailRule? result = JsonSerializer.Deserialize<MailRule>(responseContent, JsonConfig.Default);
    return result ?? new MailRule();
  }


  /// <summary>
  /// 
  /// Operation: GET /api/mail_rules/{id}/
  /// </summary>
  public async Task<MailRule> MailRulesRetrieveAsync(int id)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "mail_rules/{id}/".BuildUrl(pathParams);

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
    MailRule? result = JsonSerializer.Deserialize<MailRule>(responseContent, JsonConfig.Default);
    return result ?? new MailRule();
  }


  /// <summary>
  /// 
  /// Operation: PUT /api/mail_rules/{id}/
  /// </summary>
  public async Task<MailRule> MailRulesUpdateAsync(int id, Apigen.PaperlessNgx.Models.MailRuleRequest mailRuleRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "mail_rules/{id}/".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(mailRuleRequest, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "PUT", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PutAsync(url, content);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "PUT", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "PUT", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    MailRule? result = JsonSerializer.Deserialize<MailRule>(responseContent, JsonConfig.Default);
    return result ?? new MailRule();
  }


  /// <summary>
  /// 
  /// Operation: PATCH /api/mail_rules/{id}/
  /// </summary>
  public async Task<MailRule> MailRulesPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedMailRuleRequest patchedMailRuleRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "mail_rules/{id}/".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PATCH", url);
    string json = JsonSerializer.Serialize(patchedMailRuleRequest, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "PATCH", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PatchAsync(url, content);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "PATCH", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "PATCH", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    MailRule? result = JsonSerializer.Deserialize<MailRule>(responseContent, JsonConfig.Default);
    return result ?? new MailRule();
  }


  /// <summary>
  /// 
  /// Operation: DELETE /api/mail_rules/{id}/
  /// </summary>
  public async Task MailRulesDestroyAsync(int id)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "mail_rules/{id}/".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "DELETE", url);
    HttpResponseMessage response = await _httpClient.DeleteAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "DELETE", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "DELETE", url, responseContent, ex);
      throw;
    }
  }


}
