using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for documents operations
/// </summary>
public interface IDocumentsClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/documents/
  /// </summary>
  Task<PaginatedDocumentList> DocumentsListAsync(DocumentsListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/
  /// </summary>
  Task<Document> DocumentsRetrieveAsync(int id, DocumentsRetrieveRequest? request = null);

  /// <summary>
  /// 
  /// Operation: PUT /api/documents/{id}/
  /// </summary>
  Task<Document> DocumentsUpdateAsync(int id, Apigen.PaperlessNgx.Models.DocumentRequest documentRequest);

  /// <summary>
  /// 
  /// Operation: PATCH /api/documents/{id}/
  /// </summary>
  Task<Document> DocumentsPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedDocumentRequest patchedDocumentRequest);

  /// <summary>
  /// 
  /// Operation: DELETE /api/documents/{id}/
  /// </summary>
  Task DocumentsDestroyAsync(int id);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/download/
  /// </summary>
  Task<Stream> DocumentsDownloadRetrieveAsync(int id, DocumentsDownloadRetrieveRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /api/documents/{id}/email/
  /// </summary>
  Task<EmailDocumentResponse> DocumentsEmailCreateAsync(int id, Apigen.PaperlessNgx.Models.EmailDocumentRequest emailDocumentRequest);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/history/
  /// </summary>
  Task<PaginatedLogEntryList> DocumentsHistoryListAsync(int id, DocumentsHistoryListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/metadata/
  /// </summary>
  Task<Metadata> DocumentsMetadataRetrieveAsync(int id);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/notes/
  /// </summary>
  Task<List<Notes>> DocumentsNotesListAsync(int id, DocumentsNotesListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /api/documents/{id}/notes/
  /// </summary>
  Task<List<Notes>> DocumentsNotesCreateAsync(int id, Apigen.PaperlessNgx.Models.NoteCreateRequestRequest noteCreateRequestRequest, DocumentsNotesCreateRequest? request = null);

  /// <summary>
  /// 
  /// Operation: DELETE /api/documents/{id}/notes/
  /// </summary>
  Task<List<Notes>> DocumentsNotesDestroyAsync(int id, DocumentsNotesDestroyRequest? request = null);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/preview/
  /// </summary>
  Task<Stream> DocumentsPreviewRetrieveAsync(int id);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/share_links/
  /// </summary>
  Task<JsonElement> DocumentShareLinksAsync(string id);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/suggestions/
  /// </summary>
  Task<Suggestions> DocumentsSuggestionsRetrieveAsync(int id);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/thumb/
  /// </summary>
  Task<Stream> DocumentsThumbRetrieveAsync(int id);

  /// <summary>
  /// 
  /// Operation: POST /api/documents/bulk_download/
  /// </summary>
  Task<BulkDownload> BulkAsync(Apigen.PaperlessNgx.Models.BulkDownloadRequest bulkDownloadRequest);

  /// <summary>
  /// 
  /// Operation: POST /api/documents/bulk_edit/
  /// </summary>
  Task<BulkEditDocumentsResult> BulkAsync(Apigen.PaperlessNgx.Models.BulkEditRequest bulkEditRequest);

  /// <summary>
  /// 
  /// Operation: POST /api/documents/email/
  /// </summary>
  Task<EmailDocumentResponse> EmailDocumentsAsync(Apigen.PaperlessNgx.Models.EmailRequest emailRequest);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/next_asn/
  /// </summary>
  Task<JsonElement> DocumentsNextAsnRetrieveAsync();

  /// <summary>
  /// 
  /// Operation: POST /api/documents/post_document/
  /// </summary>
  Task<JsonElement> DocumentsPostDocumentCreateAsync(Apigen.PaperlessNgx.Models.PostDocumentRequest postDocumentRequest);

  /// <summary>
  /// 
  /// Operation: POST /api/documents/selection_data/
  /// </summary>
  Task<SelectionData> DocumentsSelectionDataCreateAsync(Apigen.PaperlessNgx.Models.DocumentListRequest documentListRequest);

}
