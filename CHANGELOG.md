# Changelog

## [3.0.0] - 2026-08-16

Built against Paperless-ngx 3.0 (API version `6.0.0 (10)`) and regenerated with Apigen.Generator 3.0.0. This release changes almost every signature. Read the migration notes before upgrading; there is no compatibility shim.

### New in the API

- **Share link bundles** — a complete `ShareLinkBundles` client (list, create, get, update, delete, rebuild).
- **Document versions** — `UpdateVersionAsync`, `UpdateVersionLabelAsync`, `DeleteVersionAsync`, `RootAsync`, plus `Versions` and `RootDocument` on `Document`.
- **PDF operations** — `MergeAsync`, `RotateAsync`, `EditPdfAsync`, `RemovePasswordAsync`, `ReprocessAsync`, `BulkDeleteAsync`.
- **AI** — `AiSuggestionsRetrieveAsync`, `ChatCreateAsync`, and LLM settings on `ApplicationConfiguration` (`AiEnabled`, `LlmBackend`, `LlmModel`, `LlmEmbeddingBackend`, and others).
- **Tasks** — `ActiveListAsync`, `SummaryListAsync`, `GetStatusCountsAsync`; `ListAsync` is now paginated and filterable by date, owner, type and trigger source.
- **Duplicate detection** — `DuplicateDocuments` on `Document`.

### Removed from the API

- `ShareLinksUpdateAsync` and `ShareLinksPartialUpdateAsync`: upstream dropped PUT and PATCH on share links. There is no replacement — delete and recreate the link.
- `All` on every `Paginated*List` model.
- `ApplicationConfiguration.SkipArchiveFile`, replaced by `ArchiveFileGeneration`.

### Breaking: dates

`format: date-time` now maps to `DateTimeOffset` instead of `DateTime` (35 properties across 26 models, plus query parameters). OpenAPI's `date-time` is RFC 3339 and carries a UTC offset; `System.Text.Json` turned that into a local-time `DateTime`, which discarded the offset and made the result depend on the time zone of the machine running the code. `format: date` maps to `DateOnly`.

### Breaking: return types

| was | is |
|---|---|
| `Task<BulkDownload>` on bulk download | `Task<Stream>` — the response is a zip and was previously read as text |
| `Task<JsonElement>` on 7 operations | `Task<int>`, `Task<bool>`, `Task<string>` as the spec declares |
| `Task<List<TasksView>>` on task list | `Task<PaginatedPaperlessTaskList>` |
| `Task<TasksView>` | `Task<PaperlessTask>` |
| `Task<ProcessedMail>` on bulk delete | `Task<BulkDeleteMailResponse>` |
| `Task<StoragePath>` on storage path test | `Task<string>` |

### Breaking: parameters

Path and query parameters now honour `format`: `uuid` becomes `Guid`, `int64` becomes `long`, `date-time` becomes `DateTimeOffset`, `date` becomes `DateOnly`, and array parameters become `List<T>` instead of `string[]`. Array query parameters are also serialized correctly for the first time — they used to go out as `?tags__id__in=System.String%5B%5D` — following each parameter's OpenAPI `style`/`explode`: `?id__in=1,2` for the `__in` filters, repeated keys for the rest. Booleans are now lowercase and dates ISO 8601.

### Breaking: method names

The resource is already in the call path, so it no longer appears in the method name, and Django REST framework's vocabulary is translated into .NET's.

| was | is |
|---|---|
| `CorrespondentsListAsync` | `Correspondents.ListAsync` |
| `DocumentsRetrieveAsync` | `Documents.GetAsync` |
| `DocumentsDestroyAsync` | `Documents.DeleteAsync` |
| `DocumentsDownloadRetrieveAsync` | `Documents.DownloadAsync` |
| `DocumentsThumbRetrieveAsync` | `Documents.ThumbnailAsync` |
| `DocumentsMetadataRetrieveAsync` | `Documents.GetMetadataAsync` |
| `DocumentsNotesDestroyAsync` | `Documents.DeleteNoteAsync` |
| `BulkAsync` (two overloads) | `Documents.BulkDownloadAsync` and `Documents.BulkEditAsync` |
| `DocumentsEmailCreateAsync` | `Documents.EmailDocumentAsync` |
| `TasksRunCreateAsync` | `Tasks.RunAsync` |
| `StoragePathsTestCreateAsync` | `StoragePaths.TestAsync` |

### Breaking: type names

| was | is |
|---|---|
| `TasksView`, `TasksViewRequest` | `PaperlessTask`, `RunTaskRequest` |
| `TaskSerializerV10` (new upstream name) | `PaperlessTask` |
| `Notes`, `NotesRequest` | `Note`, `NoteRequest` |
| `NoteCreateRequestRequest` | `NoteCreateRequest` |
| `BulkDeleteMailRequestRequest` | `BulkDeleteMailRequest` |
| `Tasks` (the redis/celery block of `SystemStatus`) | `TaskQueueStatus` |
| `Index`, `Storage`, `Database` | `SearchIndexStatus`, `StorageStatus`, `DatabaseStatus` |
| `AcknowledgeTasks` | `AcknowledgeTasksResult` |
| `UiSettingsView`, `UiSettingsViewRequest` | `UiSettings`, `UiSettingsRequest` |

`Index` in particular was ambiguous with `System.Index` for any caller importing both namespaces.

### Other changes

- `set_permissions` and `permissions` are no longer `object`. They are typed as `PermissionsSet`, with `View` and `Change` of type `PermissionsMembers` (`List<int> Users`, `List<int> Groups`). The same type is shared by all 16 models that carry it.
- `Metadata.OriginalMetadata` and `Metadata.ArchiveMetadata` are now `List<OriginalMetadataEntry>` / `List<ArchiveMetadataEntry>` instead of `Dictionary<string, object?>`, and `ArchiveSize` is nullable.
- `MethodEnum` and `ModeEnum` gained and lost members upstream (`edit_pdf`, `remove_password`; `skip`/`skip_noarchive` became `auto`/`off`). Values serialize by name, so only code that casts these enums to `int` is affected.

## [2.20.8] - 2026-07-28

- Regenerated against Apigen.Generator 2.4.0.
- **Behavior change**: nullable properties on request models now carry `[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]`, so they are omitted from the request body when null instead of being serialized as `"prop": null`. This affects 9 properties across 8 models, including `ApplicationConfigurationRequest`, `PatchedApplicationConfigurationRequest`, `CustomFieldRequest`, `SavedViewRequest`, `WorkflowActionRequest` and `TasksViewRequest`. For the `Patched*` models used by PATCH endpoints this is a fix — sending an explicit null typically clears the field server-side — but callers relying on the previous output should verify. Caused by the Microsoft.OpenApi 3.9.0 upgrade in the generator.
- Project files now use `<TargetFrameworks>` instead of `<TargetFramework>`, guarded by a condition so a repo-level `src/Directory.Build.props` can override it. No functional change: the client still targets `net10.0` only and build output is unchanged. See the [target framework policy](https://github.com/apigen-dotnet/generator/blob/main/docs/target-framework-policy.md).

## [2.20.7] - 2026-05-13

- Regenerated against Apigen.Generator 2.3.0.
- All operations and interfaces now accept `CancellationToken cancellationToken = default` and propagate it through HTTP calls and content reads.
- Non-success responses now throw `ApiException` (inherits from `HttpRequestException`) exposing `StatusCode`, `Method`, `Url`, `ResponseBody`, `Headers`, and `ContentHeaders`. Existing `catch (HttpRequestException)` callers continue to work.
- Improved logging: distinct events for caller cancellation (Debug, 1004), `HttpClient.Timeout` (Error, 3002), transport failures (Error, 3003), and API errors (Error, 3001).

## [2.0.0] - 2026-03-23

- Initial open-source release
- Generated C# client for Paperless-ngx API
