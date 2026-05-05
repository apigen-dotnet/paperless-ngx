using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for tasks operations
/// </summary>
public partial interface ITasksClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/tasks/
  /// </summary>
  Task<List<TasksView>> TasksListAsync(TasksListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: GET /api/tasks/{id}/
  /// </summary>
  Task<TasksView> TasksRetrieveAsync(int id, TasksRetrieveRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /api/tasks/acknowledge/
  /// </summary>
  Task<AcknowledgeTasks> AcknowledgeTasksAsync(Apigen.PaperlessNgx.Models.AcknowledgeTasksRequest acknowledgeTasksRequest, AcknowledgeTasksRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /api/tasks/run/
  /// </summary>
  Task<TasksView> TasksRunCreateAsync(Apigen.PaperlessNgx.Models.TasksViewRequest tasksViewRequest, TasksRunCreateRequest? request = null);

}
