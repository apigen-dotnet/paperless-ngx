#!/usr/bin/env python3
"""
Patches the upstream Paperless-ngx OpenAPI spec with fixes needed for code generation.

This script is idempotent - safe to run multiple times.
Uses ruamel.yaml to preserve formatting, comments, and key order.

Patches applied:
  1. Fix PostDocumentRequest.custom_fields missing type definition
     (upstream bug: field only has writeOnly, no type/items)
  2. Merge EmailDocumentsResponse into EmailDocumentResponse
     (identical schemas, only differ in singular vs plural name)
  3. Remove NullEnum and BlankEnum schemas
     (Django REST Framework artifacts for nullable enums, useless in C#)
"""

import sys
from ruamel.yaml import YAML

yaml = YAML()
yaml.preserve_quotes = True
yaml.width = 4096  # Prevent line wrapping


def patch_post_document_custom_fields(spec) -> int:
    """Fix PostDocumentRequest.custom_fields missing type definition.

    The upstream spec defines custom_fields on PostDocumentRequest with only
    'writeOnly: true' but no type information. The actual API accepts an array
    of integers (custom field IDs). This patch restores the correct type.
    """
    schemas = spec.get("components", {}).get("schemas", {})
    schema = schemas.get("PostDocumentRequest")
    if not schema:
        return 0

    props = schema.get("properties", {})
    cf = props.get("custom_fields")
    if not cf:
        return 0

    # Already has a type? Don't patch (idempotent)
    if cf.get("type"):
        return 0

    cf["type"] = "array"
    cf["items"] = {"type": "integer", "writeOnly": True, "title": "Custom fields"}
    return 1


def patch_merge_email_documents_response(spec) -> int:
    """Merge EmailDocumentsResponse into EmailDocumentResponse.

    Both schemas are identical (single 'message' string property).
    Replace all $refs to EmailDocumentsResponse with EmailDocumentResponse
    and remove the duplicate schema.
    """
    schemas = spec.get("components", {}).get("schemas", {})

    if "EmailDocumentsResponse" not in schemas:
        return 0

    # Rewrite all $ref occurrences in paths
    count = _rewrite_refs(
        spec.get("paths", {}),
        "#/components/schemas/EmailDocumentsResponse",
        "#/components/schemas/EmailDocumentResponse",
    )

    # Remove the duplicate schema
    if count > 0 or "EmailDocumentsResponse" in schemas:
        del schemas["EmailDocumentsResponse"]

    return 1


def _rewrite_refs(obj, old_ref, new_ref):
    """Recursively replace $ref values in a nested structure."""
    count = 0
    if isinstance(obj, dict):
        for key, value in obj.items():
            if key == "$ref" and value == old_ref:
                obj[key] = new_ref
                count += 1
            else:
                count += _rewrite_refs(value, old_ref, new_ref)
    elif isinstance(obj, list):
        for item in obj:
            count += _rewrite_refs(item, old_ref, new_ref)
    return count


def patch_remove_null_blank_enums(spec) -> int:
    """Remove NullEnum and BlankEnum schemas.

    Django REST Framework generates these for nullable enum fields as:
      oneOf: [RealEnum, BlankEnum, NullEnum]
    In C# nullable enums (RealEnum?) handle this already.
    Removes the schemas and strips references from all oneOf lists.
    """
    schemas = spec.get("components", {}).get("schemas", {})
    removed = 0

    for name in ("NullEnum", "BlankEnum"):
        if name in schemas:
            del schemas[name]
            removed += 1

    # Strip $ref to NullEnum/BlankEnum from all oneOf lists
    if removed > 0:
        _strip_refs_from_oneof(
            spec.get("paths", {}),
            {"#/components/schemas/NullEnum", "#/components/schemas/BlankEnum"},
        )
        _strip_refs_from_oneof(
            schemas,
            {"#/components/schemas/NullEnum", "#/components/schemas/BlankEnum"},
        )

    return removed


def _strip_refs_from_oneof(obj, refs_to_remove):
    """Recursively remove specific $ref entries from oneOf lists."""
    if isinstance(obj, dict):
        if "oneOf" in obj and isinstance(obj["oneOf"], list):
            obj["oneOf"] = [
                item
                for item in obj["oneOf"]
                if not (isinstance(item, dict) and item.get("$ref") in refs_to_remove)
            ]
            # If oneOf has only one item left, unwrap it
            if len(obj["oneOf"]) == 1:
                single = obj["oneOf"][0]
                del obj["oneOf"]
                obj.update(single)
        for value in obj.values():
            _strip_refs_from_oneof(value, refs_to_remove)
    elif isinstance(obj, list):
        for item in obj:
            _strip_refs_from_oneof(item, refs_to_remove)


def main():
    spec_path = sys.argv[1] if len(sys.argv) > 1 else "specs/paperless-ngx.yaml"

    print(f"Patching {spec_path}...")

    with open(spec_path, "r") as f:
        spec = yaml.load(f)

    n = patch_post_document_custom_fields(spec)
    print(
        f"  PostDocumentRequest.custom_fields type: {'patched' if n else 'already correct'}"
    )

    n = patch_merge_email_documents_response(spec)
    print(
        f"  EmailDocumentsResponse → EmailDocumentResponse: {'merged' if n else 'already correct'}"
    )

    n = patch_remove_null_blank_enums(spec)
    print(f"  NullEnum/BlankEnum: {'removed' if n else 'already clean'}")

    with open(spec_path, "w") as f:
        yaml.dump(spec, f)

    print("Done.")


if __name__ == "__main__":
    main()
