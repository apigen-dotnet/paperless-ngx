using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for mail_accounts operations
/// </summary>
public partial interface IMailAccountsClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/mail_accounts/
  /// </summary>
  Task<PaginatedMailAccountList> MailAccountsListAsync(MailAccountsListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /api/mail_accounts/
  /// </summary>
  Task<MailAccount> MailAccountsCreateAsync(Apigen.PaperlessNgx.Models.MailAccountRequest mailAccountRequest);

  /// <summary>
  /// 
  /// Operation: GET /api/mail_accounts/{id}/
  /// </summary>
  Task<MailAccount> MailAccountsRetrieveAsync(int id);

  /// <summary>
  /// 
  /// Operation: PUT /api/mail_accounts/{id}/
  /// </summary>
  Task<MailAccount> MailAccountsUpdateAsync(int id, Apigen.PaperlessNgx.Models.MailAccountRequest mailAccountRequest);

  /// <summary>
  /// 
  /// Operation: PATCH /api/mail_accounts/{id}/
  /// </summary>
  Task<MailAccount> MailAccountsPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedMailAccountRequest patchedMailAccountRequest);

  /// <summary>
  /// 
  /// Operation: DELETE /api/mail_accounts/{id}/
  /// </summary>
  Task MailAccountsDestroyAsync(int id);

  /// <summary>
  /// 
  /// Operation: POST /api/mail_accounts/{id}/process/
  /// </summary>
  Task<MailAccountProcessResponse> MailAccountProcessAsync(int id, Apigen.PaperlessNgx.Models.MailAccountRequest mailAccountRequest);

  /// <summary>
  /// 
  /// Operation: POST /api/mail_accounts/test/
  /// </summary>
  Task<MailAccountTestResponse> MailAccountTestAsync(Apigen.PaperlessNgx.Models.MailAccountRequest mailAccountRequest);

}
