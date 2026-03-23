using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for document_types operations
/// </summary>
public interface IDocumentTypesClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/document_types/
  /// </summary>
  Task<PaginatedDocumentTypeList> DocumentTypesListAsync(DocumentTypesListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /api/document_types/
  /// </summary>
  Task<DocumentType> DocumentTypesCreateAsync(Apigen.PaperlessNgx.Models.DocumentTypeRequest documentTypeRequest);

  /// <summary>
  /// 
  /// Operation: GET /api/document_types/{id}/
  /// </summary>
  Task<DocumentType> DocumentTypesRetrieveAsync(int id, DocumentTypesRetrieveRequest? request = null);

  /// <summary>
  /// 
  /// Operation: PUT /api/document_types/{id}/
  /// </summary>
  Task<DocumentType> DocumentTypesUpdateAsync(int id, Apigen.PaperlessNgx.Models.DocumentTypeRequest documentTypeRequest);

  /// <summary>
  /// 
  /// Operation: PATCH /api/document_types/{id}/
  /// </summary>
  Task<DocumentType> DocumentTypesPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedDocumentTypeRequest patchedDocumentTypeRequest);

  /// <summary>
  /// 
  /// Operation: DELETE /api/document_types/{id}/
  /// </summary>
  Task DocumentTypesDestroyAsync(int id);

}
