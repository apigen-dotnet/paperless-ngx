# Upstream snapshot

`paperless-ngx.yaml` was exported from the official Paperless-ngx **3.1.3** image
on 2026-09-09. The schema uses API version **10**, reported as `6.0.0 (10)` in
`info.version`; that is separate from the application's release version.

Image digest: `sha256:aa810a36942c63d4ee70d00eda7236cd3d6acfb7eb3f7987fb568ed14df8817a`.
The export passed `spectacular --fail-on-warn` with an empty, migrated SQLite
database. No running Paperless instance or account data was used.

Reproduce from this repository's root:

```bash
docker run --rm -i --network none --entrypoint python3 \
  --workdir /usr/src/paperless/src \
  --mount "type=bind,src=$PWD/specs,dst=/export" \
  -e PAPERLESS_DATA_DIR=/tmp/paperless-data \
  -e PAPERLESS_MEDIA_ROOT=/tmp/paperless-media \
  -e PAPERLESS_CACHE_BACKEND=django.core.cache.backends.locmem.LocMemCache \
  ghcr.io/paperless-ngx/paperless-ngx:3.1.3 - <<'PY'
import os, pathlib, secrets
os.environ["PAPERLESS_SECRET_KEY"] = secrets.token_urlsafe(64)
os.environ["DJANGO_SETTINGS_MODULE"] = "paperless.settings"
pathlib.Path("/tmp/paperless-data").mkdir()
pathlib.Path("/tmp/paperless-media").mkdir()
from django.core.management import execute_from_command_line
execute_from_command_line(["manage.py", "migrate", "--noinput", "--verbosity", "0"])
execute_from_command_line(["manage.py", "spectacular", "--api-version", "10",
                           "--file", "/export/paperless-ngx.yaml", "--fail-on-warn"])
PY
```

The Python runtime and management command belong to the upstream application
inside its container. SDK corrections remain C# `ISpecPatch` implementations in
`patches/`; do not edit the exported schema manually. Automatic URL downloads
remain disabled because the stable release does not publish a schema artifact.
