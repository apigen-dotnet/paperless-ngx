# Changelog

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
