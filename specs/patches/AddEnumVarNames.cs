using Microsoft.OpenApi;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using Apigen.Generator;

/// <summary>
/// Add x-enum-varnames to integer enums that only have numeric values.
/// Names are derived from the description field in the spec.
/// </summary>
public class AddEnumVarNames : ISpecPatch
{
  public string Name => "Add x-enum-varnames to integer enums";

  private static readonly Dictionary<string, string[]> EnumVarNames = new()
  {
    ["AccountTypeEnum"] = new[] { "Imap", "GmailOAuth", "OutlookOAuth" },
    ["AttachmentTypeEnum"] = new[] { "OnlyAttachments", "AllFiles" },
    ["WorkflowActionTypeEnum"] = new[] { "Assignment", "Removal", "Email", "Webhook" },
    ["WorkflowTriggerTypeEnum"] = new[] { "ConsumptionStarted", "DocumentAdded", "DocumentUpdated", "Scheduled" },
    ["RuleTypeEnum"] = new[]
    {
      "TitleContains", "ContentContains", "AsnIs", "CorrespondentIs",
      "DocumentTypeIs", "IsInInbox", "HasTag", "HasAnyTag",
      "CreatedBefore", "CreatedAfter", "CreatedYearIs", "CreatedMonthIs",
      "CreatedDayIs", "AddedBefore", "AddedAfter", "ModifiedBefore",
      "ModifiedAfter", "DoesNotHaveTag", "DoesNotHaveAsn", "TitleOrContentContains",
      "FulltextQuery", "MoreLikeThis", "HasTagsIn", "AsnGreaterThan",
      "AsnLessThan", "StoragePathIs", "HasCorrespondentIn", "DoesNotHaveCorrespondentIn",
      "HasDocumentTypeIn", "DoesNotHaveDocumentTypeIn", "HasStoragePathIn", "DoesNotHaveStoragePathIn",
      "OwnerIs", "HasOwnerIn", "DoesNotHaveOwner", "DoesNotHaveOwnerIn",
      "HasCustomFieldValue", "IsSharedByMe", "HasCustomFields", "HasCustomFieldIn",
      "DoesNotHaveCustomFieldIn", "DoesNotHaveCustomField", "CustomFieldsQuery",
      "CreatedTo", "CreatedFrom", "AddedTo", "AddedFrom", "MimeTypeIs",
    },
  };

  public bool Apply(OpenApiDocument document)
  {
    if (document.Components?.Schemas == null) return false;

    int count = 0;
    foreach (var (enumName, varNames) in EnumVarNames)
    {
      if (!document.Components.Schemas.TryGetValue(enumName, out IOpenApiSchema? schemaInterface))
        continue;

      if (schemaInterface is not OpenApiSchema schema)
        continue;

      if (schema.Extensions != null && schema.Extensions.ContainsKey("x-enum-varnames"))
        continue;

      var jsonArray = new JsonArray();
      foreach (string name in varNames)
        jsonArray.Add(JsonValue.Create(name));

      schema.Extensions ??= new Dictionary<string, IOpenApiExtension>();
      schema.Extensions["x-enum-varnames"] = new JsonNodeExtension(jsonArray);
      count++;
    }

    return count > 0;
  }
}
