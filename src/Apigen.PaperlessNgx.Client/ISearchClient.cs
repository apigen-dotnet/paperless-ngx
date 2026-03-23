using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for search operations
/// </summary>
public interface ISearchClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/search/
  /// </summary>
  Task<SearchResult> SearchRetrieveAsync(SearchRetrieveRequest? request = null);

  /// <summary>
  /// 
  /// Operation: GET /api/search/autocomplete/
  /// </summary>
  Task<JsonElement> SearchAutocompleteListAsync(SearchAutocompleteListRequest? request = null);

}
