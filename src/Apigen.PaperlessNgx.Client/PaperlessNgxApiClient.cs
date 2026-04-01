using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Apigen.PaperlessNgx.Models;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Main API client for accessing all resources
/// </summary>
public class PaperlessNgxApiClient
{
  private readonly HttpClient _httpClient;
  private readonly bool _disposeHttpClient;
  private readonly ILogger? _logger;

  /// <summary>
  /// Client for bulk_edit_objects operations
  /// </summary>
  public BulkEditObjectsClient BulkEditObjects { get; }

  /// <summary>
  /// Client for config operations
  /// </summary>
  public ConfigClient Config { get; }

  /// <summary>
  /// Client for correspondents operations
  /// </summary>
  public CorrespondentsClient Correspondents { get; }

  /// <summary>
  /// Client for custom_fields operations
  /// </summary>
  public CustomFieldsClient CustomFields { get; }

  /// <summary>
  /// Client for document_types operations
  /// </summary>
  public DocumentTypesClient DocumentTypes { get; }

  /// <summary>
  /// Client for documents operations
  /// </summary>
  public DocumentsClient Documents { get; }

  /// <summary>
  /// Client for groups operations
  /// </summary>
  public GroupsClient Groups { get; }

  /// <summary>
  /// Client for logs operations
  /// </summary>
  public LogsClient Logs { get; }

  /// <summary>
  /// Client for mail_accounts operations
  /// </summary>
  public MailAccountsClient MailAccounts { get; }

  /// <summary>
  /// Client for mail_rules operations
  /// </summary>
  public MailRulesClient MailRules { get; }

  /// <summary>
  /// Client for oauth operations
  /// </summary>
  public OAuthClient OAuth { get; }

  /// <summary>
  /// Client for processed_mail operations
  /// </summary>
  public ProcessedMailClient ProcessedMail { get; }

  /// <summary>
  /// Client for profile operations
  /// </summary>
  public ProfileClient Profile { get; }

  /// <summary>
  /// Client for remote_version operations
  /// </summary>
  public RemoteVersionClient RemoteVersion { get; }

  /// <summary>
  /// Client for saved_views operations
  /// </summary>
  public SavedViewsClient SavedViews { get; }

  /// <summary>
  /// Client for search operations
  /// </summary>
  public SearchClient Search { get; }

  /// <summary>
  /// Client for share_links operations
  /// </summary>
  public ShareLinksClient ShareLinks { get; }

  /// <summary>
  /// Client for statistics operations
  /// </summary>
  public StatisticsClient Statistics { get; }

  /// <summary>
  /// Client for status operations
  /// </summary>
  public StatusClient Status { get; }

  /// <summary>
  /// Client for storage_paths operations
  /// </summary>
  public StoragePathsClient StoragePaths { get; }

  /// <summary>
  /// Client for tags operations
  /// </summary>
  public TagsClient Tags { get; }

  /// <summary>
  /// Client for tasks operations
  /// </summary>
  public TasksClient Tasks { get; }

  /// <summary>
  /// Client for token operations
  /// </summary>
  public TokenClient Token { get; }

  /// <summary>
  /// Client for trash operations
  /// </summary>
  public TrashClient Trash { get; }

  /// <summary>
  /// Client for ui_settings operations
  /// </summary>
  public UiSettingsClient UiSettings { get; }

  /// <summary>
  /// Client for users operations
  /// </summary>
  public UsersClient Users { get; }

  /// <summary>
  /// Client for workflow_actions operations
  /// </summary>
  public WorkflowActionsClient WorkflowActions { get; }

  /// <summary>
  /// Client for workflow_triggers operations
  /// </summary>
  public WorkflowTriggersClient WorkflowTriggers { get; }

  /// <summary>
  /// Client for workflows operations
  /// </summary>
  public WorkflowsClient Workflows { get; }

  /// <summary>
  /// Initialize client with a pre-configured HttpClient
  /// </summary>
  /// <param name="httpClient">Pre-configured HttpClient with base address, auth headers, etc.</param>
  /// <param name="logger">Optional logger for request/response logging</param>
  public PaperlessNgxApiClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _disposeHttpClient = false;
    _logger = logger;

    BulkEditObjects = new BulkEditObjectsClient(_httpClient, _logger);
    Config = new ConfigClient(_httpClient, _logger);
    Correspondents = new CorrespondentsClient(_httpClient, _logger);
    CustomFields = new CustomFieldsClient(_httpClient, _logger);
    DocumentTypes = new DocumentTypesClient(_httpClient, _logger);
    Documents = new DocumentsClient(_httpClient, _logger);
    Groups = new GroupsClient(_httpClient, _logger);
    Logs = new LogsClient(_httpClient, _logger);
    MailAccounts = new MailAccountsClient(_httpClient, _logger);
    MailRules = new MailRulesClient(_httpClient, _logger);
    OAuth = new OAuthClient(_httpClient, _logger);
    ProcessedMail = new ProcessedMailClient(_httpClient, _logger);
    Profile = new ProfileClient(_httpClient, _logger);
    RemoteVersion = new RemoteVersionClient(_httpClient, _logger);
    SavedViews = new SavedViewsClient(_httpClient, _logger);
    Search = new SearchClient(_httpClient, _logger);
    ShareLinks = new ShareLinksClient(_httpClient, _logger);
    Statistics = new StatisticsClient(_httpClient, _logger);
    Status = new StatusClient(_httpClient, _logger);
    StoragePaths = new StoragePathsClient(_httpClient, _logger);
    Tags = new TagsClient(_httpClient, _logger);
    Tasks = new TasksClient(_httpClient, _logger);
    Token = new TokenClient(_httpClient, _logger);
    Trash = new TrashClient(_httpClient, _logger);
    UiSettings = new UiSettingsClient(_httpClient, _logger);
    Users = new UsersClient(_httpClient, _logger);
    WorkflowActions = new WorkflowActionsClient(_httpClient, _logger);
    WorkflowTriggers = new WorkflowTriggersClient(_httpClient, _logger);
    Workflows = new WorkflowsClient(_httpClient, _logger);
  }

  private PaperlessNgxApiClient(HttpClient httpClient, bool disposeHttpClient, ILogger? logger)
  {
    _httpClient = httpClient;
    _disposeHttpClient = disposeHttpClient;
    _logger = logger;

    BulkEditObjects = new BulkEditObjectsClient(_httpClient, _logger);
    Config = new ConfigClient(_httpClient, _logger);
    Correspondents = new CorrespondentsClient(_httpClient, _logger);
    CustomFields = new CustomFieldsClient(_httpClient, _logger);
    DocumentTypes = new DocumentTypesClient(_httpClient, _logger);
    Documents = new DocumentsClient(_httpClient, _logger);
    Groups = new GroupsClient(_httpClient, _logger);
    Logs = new LogsClient(_httpClient, _logger);
    MailAccounts = new MailAccountsClient(_httpClient, _logger);
    MailRules = new MailRulesClient(_httpClient, _logger);
    OAuth = new OAuthClient(_httpClient, _logger);
    ProcessedMail = new ProcessedMailClient(_httpClient, _logger);
    Profile = new ProfileClient(_httpClient, _logger);
    RemoteVersion = new RemoteVersionClient(_httpClient, _logger);
    SavedViews = new SavedViewsClient(_httpClient, _logger);
    Search = new SearchClient(_httpClient, _logger);
    ShareLinks = new ShareLinksClient(_httpClient, _logger);
    Statistics = new StatisticsClient(_httpClient, _logger);
    Status = new StatusClient(_httpClient, _logger);
    StoragePaths = new StoragePathsClient(_httpClient, _logger);
    Tags = new TagsClient(_httpClient, _logger);
    Tasks = new TasksClient(_httpClient, _logger);
    Token = new TokenClient(_httpClient, _logger);
    Trash = new TrashClient(_httpClient, _logger);
    UiSettings = new UiSettingsClient(_httpClient, _logger);
    Users = new UsersClient(_httpClient, _logger);
    WorkflowActions = new WorkflowActionsClient(_httpClient, _logger);
    WorkflowTriggers = new WorkflowTriggersClient(_httpClient, _logger);
    Workflows = new WorkflowsClient(_httpClient, _logger);
  }

  /// <summary>
  /// Create client with Basic Authentication
  /// </summary>
  public static PaperlessNgxApiClient WithBasicAuth(string username, string password, string baseUrl = "https://localhost", ILogger? logger = null)
  {
    HttpClient httpClient = CreateBasicAuthHttpClient(username, password, baseUrl);
    return new PaperlessNgxApiClient(httpClient, true, logger);
  }

  /// <summary>
  /// Create client with cookie-based authentication
  /// </summary>
  public static PaperlessNgxApiClient WithCookie(string sessionToken, string baseUrl = "https://localhost", ILogger? logger = null)
  {
    HttpClient httpClient = CreateCookieAuthHttpClient(sessionToken, "sessionid", baseUrl);
    return new PaperlessNgxApiClient(httpClient, true, logger);
  }

  /// <summary>
  /// Create client with Authorization authentication
  /// </summary>
  public static PaperlessNgxApiClient WithApiKey(string apiKey, string baseUrl = "https://localhost", ILogger? logger = null)
  {
    HttpClient httpClient = CreateTokenAuthHttpClient(apiKey, baseUrl, "Authorization", false);
    return new PaperlessNgxApiClient(httpClient, true, logger);
  }

  private static HttpClient CreateTokenAuthHttpClient(string apiToken, string baseUrl, string headerName, bool useBearer)
  {
    // Ensure baseUrl ends with / for proper Uri combining with relative paths
    string normalizedBaseUrl = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";
    HttpClient client = new() { BaseAddress = new Uri(normalizedBaseUrl) };

    if (useBearer)
    {
      client.DefaultRequestHeaders.Add(headerName, $"Bearer {apiToken}");
    }
    else
    {
      client.DefaultRequestHeaders.Add(headerName, apiToken);
    }

    return client;
  }

  private static HttpClient CreateBasicAuthHttpClient(string username, string password, string baseUrl)
  {
    // Ensure baseUrl ends with / for proper Uri combining with relative paths
    string normalizedBaseUrl = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";
    HttpClient client = new() { BaseAddress = new Uri(normalizedBaseUrl) };

    string credentials = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{username}:{password}"));
    client.DefaultRequestHeaders.Add("Authorization", $"Basic {credentials}");

    return client;
  }

  private static HttpClient CreateCookieAuthHttpClient(string token, string cookieName, string baseUrl)
  {
    string normalizedBaseUrl = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";
    System.Net.CookieContainer cookies = new();
    cookies.Add(new Uri(normalizedBaseUrl), new System.Net.Cookie(cookieName, token));
    HttpClientHandler handler = new() { CookieContainer = cookies };
    HttpClient client = new(handler) { BaseAddress = new Uri(normalizedBaseUrl) };

    return client;
  }

  /// <summary>
  /// Dispose resources
  /// </summary>
  public void Dispose()
  {
    if (_disposeHttpClient)
    {
      _httpClient?.Dispose();
    }
  }
}
