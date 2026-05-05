using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for workflows operations
/// </summary>
public partial interface IWorkflowsClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/workflows/
  /// </summary>
  Task<PaginatedWorkflowList> WorkflowsListAsync(WorkflowsListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /api/workflows/
  /// </summary>
  Task<Workflow> WorkflowsCreateAsync(Apigen.PaperlessNgx.Models.WorkflowRequest workflowRequest);

  /// <summary>
  /// 
  /// Operation: GET /api/workflows/{id}/
  /// </summary>
  Task<Workflow> WorkflowsRetrieveAsync(int id);

  /// <summary>
  /// 
  /// Operation: PUT /api/workflows/{id}/
  /// </summary>
  Task<Workflow> WorkflowsUpdateAsync(int id, Apigen.PaperlessNgx.Models.WorkflowRequest workflowRequest);

  /// <summary>
  /// 
  /// Operation: PATCH /api/workflows/{id}/
  /// </summary>
  Task<Workflow> WorkflowsPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedWorkflowRequest patchedWorkflowRequest);

  /// <summary>
  /// 
  /// Operation: DELETE /api/workflows/{id}/
  /// </summary>
  Task WorkflowsDestroyAsync(int id);

}
