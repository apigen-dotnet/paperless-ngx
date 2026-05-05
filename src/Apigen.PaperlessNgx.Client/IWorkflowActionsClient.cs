using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for workflow_actions operations
/// </summary>
public partial interface IWorkflowActionsClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/workflow_actions/
  /// </summary>
  Task<PaginatedWorkflowActionList> WorkflowActionsListAsync(WorkflowActionsListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /api/workflow_actions/
  /// </summary>
  Task<WorkflowAction> WorkflowActionsCreateAsync(Apigen.PaperlessNgx.Models.WorkflowActionRequest workflowActionRequest);

  /// <summary>
  /// 
  /// Operation: GET /api/workflow_actions/{id}/
  /// </summary>
  Task<WorkflowAction> WorkflowActionsRetrieveAsync(int id);

  /// <summary>
  /// 
  /// Operation: PUT /api/workflow_actions/{id}/
  /// </summary>
  Task<WorkflowAction> WorkflowActionsUpdateAsync(int id, Apigen.PaperlessNgx.Models.WorkflowActionRequest workflowActionRequest);

  /// <summary>
  /// 
  /// Operation: PATCH /api/workflow_actions/{id}/
  /// </summary>
  Task<WorkflowAction> WorkflowActionsPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.WorkflowActionRequest workflowActionRequest);

  /// <summary>
  /// 
  /// Operation: DELETE /api/workflow_actions/{id}/
  /// </summary>
  Task WorkflowActionsDestroyAsync(int id);

}
