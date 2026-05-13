using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for documents operations
/// </summary>
public partial interface IDocumentsClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/documents/
  /// </summary>
  Task<PaginatedDocumentList> DocumentsListAsync(DocumentsListRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/
  /// </summary>
  Task<Document> DocumentsRetrieveAsync(int id, DocumentsRetrieveRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /api/documents/{id}/
  /// </summary>
  Task<Document> DocumentsUpdateAsync(int id, Apigen.PaperlessNgx.Models.DocumentRequest documentRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PATCH /api/documents/{id}/
  /// </summary>
  Task<Document> DocumentsPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedDocumentRequest patchedDocumentRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: DELETE /api/documents/{id}/
  /// </summary>
  Task DocumentsDestroyAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/download/
  /// </summary>
  Task<Stream> DocumentsDownloadRetrieveAsync(int id, DocumentsDownloadRetrieveRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: POST /api/documents/{id}/email/
  /// </summary>
  Task<EmailDocumentResponse> DocumentsEmailCreateAsync(int id, Apigen.PaperlessNgx.Models.EmailDocumentRequest emailDocumentRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/history/
  /// </summary>
  Task<PaginatedLogEntryList> DocumentsHistoryListAsync(int id, DocumentsHistoryListRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/metadata/
  /// </summary>
  Task<Metadata> DocumentsMetadataRetrieveAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/notes/
  /// </summary>
  Task<List<Notes>> DocumentsNotesListAsync(int id, DocumentsNotesListRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: POST /api/documents/{id}/notes/
  /// </summary>
  Task<List<Notes>> DocumentsNotesCreateAsync(int id, Apigen.PaperlessNgx.Models.NoteCreateRequestRequest noteCreateRequestRequest, DocumentsNotesCreateRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: DELETE /api/documents/{id}/notes/
  /// </summary>
  Task<List<Notes>> DocumentsNotesDestroyAsync(int id, DocumentsNotesDestroyRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/preview/
  /// </summary>
  Task<Stream> DocumentsPreviewRetrieveAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/share_links/
  /// </summary>
  Task<JsonElement> DocumentShareLinksAsync(string id, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/suggestions/
  /// </summary>
  Task<Suggestions> DocumentsSuggestionsRetrieveAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/{id}/thumb/
  /// </summary>
  Task<Stream> DocumentsThumbRetrieveAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: POST /api/documents/bulk_download/
  /// </summary>
  Task<BulkDownload> BulkAsync(Apigen.PaperlessNgx.Models.BulkDownloadRequest bulkDownloadRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: POST /api/documents/bulk_edit/
  /// </summary>
  Task<BulkEditDocumentsResult> BulkAsync(Apigen.PaperlessNgx.Models.BulkEditRequest bulkEditRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: POST /api/documents/email/
  /// </summary>
  Task<EmailDocumentResponse> EmailDocumentsAsync(Apigen.PaperlessNgx.Models.EmailRequest emailRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/documents/next_asn/
  /// </summary>
  Task<JsonElement> DocumentsNextAsnRetrieveAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: POST /api/documents/post_document/
  /// </summary>
  Task<JsonElement> DocumentsPostDocumentCreateAsync(Apigen.PaperlessNgx.Models.PostDocumentRequest postDocumentRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: POST /api/documents/selection_data/
  /// </summary>
  Task<SelectionData> DocumentsSelectionDataCreateAsync(Apigen.PaperlessNgx.Models.DocumentListRequest documentListRequest, CancellationToken cancellationToken = default);

}
