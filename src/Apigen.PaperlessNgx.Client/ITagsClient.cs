using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for tags operations
/// </summary>
public partial interface ITagsClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/tags/
  /// </summary>
  Task<PaginatedTagList> TagsListAsync(TagsListRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: POST /api/tags/
  /// </summary>
  Task<Tag> TagsCreateAsync(Apigen.PaperlessNgx.Models.TagRequest tagRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: GET /api/tags/{id}/
  /// </summary>
  Task<Tag> TagsRetrieveAsync(int id, TagsRetrieveRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PUT /api/tags/{id}/
  /// </summary>
  Task<Tag> TagsUpdateAsync(int id, Apigen.PaperlessNgx.Models.TagRequest tagRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: PATCH /api/tags/{id}/
  /// </summary>
  Task<Tag> TagsPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedTagRequest patchedTagRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// 
  /// Operation: DELETE /api/tags/{id}/
  /// </summary>
  Task TagsDestroyAsync(int id, CancellationToken cancellationToken = default);

}
