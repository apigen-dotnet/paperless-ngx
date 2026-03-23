using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for workflow_triggers operations
/// </summary>
public interface IWorkflowTriggersClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/workflow_triggers/
  /// </summary>
  Task<PaginatedWorkflowTriggerList> WorkflowTriggersListAsync(WorkflowTriggersListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /api/workflow_triggers/
  /// </summary>
  Task<WorkflowTrigger> WorkflowTriggersCreateAsync(Apigen.PaperlessNgx.Models.WorkflowTriggerRequest workflowTriggerRequest);

  /// <summary>
  /// 
  /// Operation: GET /api/workflow_triggers/{id}/
  /// </summary>
  Task<WorkflowTrigger> WorkflowTriggersRetrieveAsync(int id);

  /// <summary>
  /// 
  /// Operation: PUT /api/workflow_triggers/{id}/
  /// </summary>
  Task<WorkflowTrigger> WorkflowTriggersUpdateAsync(int id, Apigen.PaperlessNgx.Models.WorkflowTriggerRequest workflowTriggerRequest);

  /// <summary>
  /// 
  /// Operation: PATCH /api/workflow_triggers/{id}/
  /// </summary>
  Task<WorkflowTrigger> WorkflowTriggersPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedWorkflowTriggerRequest patchedWorkflowTriggerRequest);

  /// <summary>
  /// 
  /// Operation: DELETE /api/workflow_triggers/{id}/
  /// </summary>
  Task WorkflowTriggersDestroyAsync(int id);

}
