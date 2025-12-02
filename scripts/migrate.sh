#!/usr/bin/env bash
# migrate.sh — helper for Groovarr EF Core migrations
# Usage:
#   ./scripts/migrate.sh add <MigrationName> <Context>
#   ./scripts/migrate.sh update <Context>
#
# Context options: groovarr, auth

set -e

PROJECT="backend/Groovarr.Api/groovarr.csproj"

case "$1" in
  add)
    NAME=$2
    CONTEXT=$3
    if [ "$CONTEXT" = "groovarr" ]; then
      dotnet ef migrations add "$NAME" \
        --context GroovarrDbContext \
        --project $PROJECT \
        --output-dir Migrations/Groovarr
    elif [ "$CONTEXT" = "auth" ]; then
      dotnet ef migrations add "$NAME" \
        --context AuthDbContext \
        --project $PROJECT \
        --output-dir Migrations/Auth
    else
      echo "Unknown context: $CONTEXT (use groovarr or auth)"
      exit 1
    fi
    ;;
  update)
    CONTEXT=$2
    if [ "$CONTEXT" = "groovarr" ]; then
      dotnet ef database update \
        --context GroovarrDbContext \
        --project $PROJECT
    elif [ "$CONTEXT" = "auth" ]; then
      dotnet ef database update \
        --context AuthDbContext \
        --project $PROJECT
    else
      echo "Unknown context: $CONTEXT (use groovarr or auth)"
      exit 1
    fi
    ;;
  *)
    echo "Usage:"
    echo "  ./scripts/migrate.sh add <MigrationName> <Context>"
    echo "  ./scripts/migrate.sh update <Context>"
    echo "Contexts: groovarr, auth"
    ;;
esac
```

---

