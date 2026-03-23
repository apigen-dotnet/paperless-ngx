using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Request parameters for 
/// Operation: GET /api/tasks/
/// </summary>
public class TasksListRequest : BaseRequest
{
  /// <summary>
  /// Acknowledged
  /// </summary>
  [JsonPropertyName("acknowledged")]
  public bool? Acknowledged { get; set; }

  /// <summary>
  /// Which field to use when ordering the results.
  /// </summary>
  [JsonPropertyName("ordering")]
  public string? Ordering { get; set; }

  /// <summary>
  /// Current state of the task being run
  /// 
  /// * `FAILURE` - FAILURE
  /// * `PENDING` - PENDING
  /// * `RECEIVED` - RECEIVED
  /// * `RETRY` - RETRY
  /// * `REVOKED` - REVOKED
  /// * `STARTED` - STARTED
  /// * `SUCCESS` - SUCCESS
  /// </summary>
  [JsonPropertyName("status")]
  public string? Status { get; set; }

  /// <summary>
  /// Filter tasks by Celery UUID
  /// </summary>
  [JsonPropertyName("task_id")]
  public string? TaskId { get; set; }

  /// <summary>
  /// Name of the task that was run
  /// 
  /// * `consume_file` - Consume File
  /// * `train_classifier` - Train Classifier
  /// * `check_sanity` - Check Sanity
  /// * `index_optimize` - Index Optimize
  /// </summary>
  [JsonPropertyName("task_name")]
  public string? TaskName { get; set; }

  /// <summary>
  /// The type of task that was run
  /// 
  /// * `auto_task` - Auto Task
  /// * `scheduled_task` - Scheduled Task
  /// * `manual_task` - Manual Task
  /// </summary>
  [JsonPropertyName("type")]
  public string? Type { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Acknowledged != null)
      queryParams["acknowledged"] = Acknowledged;
    if (Ordering != null)
      queryParams["ordering"] = Ordering;
    if (Status != null)
      queryParams["status"] = Status;
    if (TaskId != null)
      queryParams["task_id"] = TaskId;
    if (TaskName != null)
      queryParams["task_name"] = TaskName;
    if (Type != null)
      queryParams["type"] = Type;

    return queryParams.ToQueryString();
  }
}
