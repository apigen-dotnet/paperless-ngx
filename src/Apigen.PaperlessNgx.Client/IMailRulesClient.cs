using System.Text.Json;
using System.Threading.Tasks;
using Apigen.PaperlessNgx.Models;

#nullable enable

namespace Apigen.PaperlessNgx.Client;

/// <summary>
/// Interface for mail_rules operations
/// </summary>
public partial interface IMailRulesClient
{
  /// <summary>
  /// 
  /// Operation: GET /api/mail_rules/
  /// </summary>
  Task<PaginatedMailRuleList> MailRulesListAsync(MailRulesListRequest? request = null);

  /// <summary>
  /// 
  /// Operation: POST /api/mail_rules/
  /// </summary>
  Task<MailRule> MailRulesCreateAsync(Apigen.PaperlessNgx.Models.MailRuleRequest mailRuleRequest);

  /// <summary>
  /// 
  /// Operation: GET /api/mail_rules/{id}/
  /// </summary>
  Task<MailRule> MailRulesRetrieveAsync(int id);

  /// <summary>
  /// 
  /// Operation: PUT /api/mail_rules/{id}/
  /// </summary>
  Task<MailRule> MailRulesUpdateAsync(int id, Apigen.PaperlessNgx.Models.MailRuleRequest mailRuleRequest);

  /// <summary>
  /// 
  /// Operation: PATCH /api/mail_rules/{id}/
  /// </summary>
  Task<MailRule> MailRulesPartialUpdateAsync(int id, Apigen.PaperlessNgx.Models.PatchedMailRuleRequest patchedMailRuleRequest);

  /// <summary>
  /// 
  /// Operation: DELETE /api/mail_rules/{id}/
  /// </summary>
  Task MailRulesDestroyAsync(int id);

}
