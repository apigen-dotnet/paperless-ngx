using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Request parameters for 
/// Operation: POST /api/tasks/acknowledge/
/// </summary>
public partial class AcknowledgeTasksRequest : BaseRequest
{
  /// <summary>
  /// Filter tasks by Celery UUID
  /// </summary>
  [JsonPropertyName("task_id")]
  public string? TaskId { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (TaskId != null)
      queryParams["task_id"] = TaskId;

    return queryParams.ToQueryString();
  }
}
