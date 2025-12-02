# Groovarr Migrations Guide

Groovarr uses **two separate SQLite databases**:
- **GroovarrDbContext** → application data (playlists, tracks, sources, audit logs)
- **AuthDbContext** → authentication and user/session data

Each context has its own migration history and schema snapshot.

## 🧩 What is a Migration?

In **Entity Framework Core (EF Core)**, a *migration* is a versioned snapshot of your database schema. It’s how changes in your C# models (`Playlist`, `Track`, `ShareLink`, etc.) get translated into SQL changes for your SQLite database.

- **Initial migration** (`InitialCreate.cs`) → creates the first tables (`Playlists`, `Tracks`, etc.).
- **Subsequent migrations** → capture incremental changes, like adding a new column (`Genre`), creating a new table (`AuditLogs`), or modifying relationships.
- **Up() method** → defines how to apply the schema change.
- **Down() method** → defines how to roll back the change.

## Why migrations matter in Groovarr:
- They keep `/config/groovarr.db` and `/config/auth.db` in sync with your models.
- They allow contributors to evolve the schema safely without manually editing SQL.
- They provide a history of changes, so you can roll forward/backward as needed.

---

## 🧩 Generating Migrations

### GroovarrDbContext
```bash
dotnet ef migrations add <MigrationName> \
  --context GroovarrDbContext \
  --output-dir Migrations/Groovarr
```

### AuthDbContext
```bash
dotnet ef migrations add <MigrationName> \
  --context AuthDbContext \
  --output-dir Migrations/Auth
```

This ensures migrations are kept in separate folders:
```
Groovarr.Api/
 └── Migrations/
      ├── Groovarr/   # migrations for GroovarrDbContext
      └── Auth/       # migrations for AuthDbContext
```

---

## 🧩 Applying Migrations

Run updates separately for each context:

```bash
dotnet ef database update --context GroovarrDbContext
dotnet ef database update --context AuthDbContext
```

This creates or updates:
- `/config/groovarr.db`
- `/config/auth.db`

---

## 🧩 Best Practices

- **Always specify `--context`** when adding or updating migrations.
- **Use descriptive names** (e.g., `AddShareLinks`, `AddAuditLogs`).
- **Keep migrations small**: one schema change per migration.
- **Commit both migration files and snapshots** to version control.
- **Never mix contexts**: don’t add `AuthDbContext` migrations to `Groovarr/` or vice versa.

---

## 🧩 Common Pitfalls

- Forgetting `--context` → EF defaults to the first DbContext it finds.
- Running `dotnet ef database update` without context → may update the wrong DB.
- Editing migration files manually → avoid unless fixing a typo; regenerate instead.

---

## ✅ Contributor Workflow

1. Make model changes in `Models/`.
2. Run `dotnet ef migrations add <Name> --context <DbContext>`.
3. Apply with `dotnet ef database update --context <DbContext>`.
4. Verify schema in `/config/*.db`.
5. Commit migration files.

## 🧩 Notes for Contributors

- Always specify the correct **DbContext** when adding migrations:
  - `GroovarrDbContext` → playlists/tracks
  - `AuthDbContext` → tokens/share links
- Use descriptive migration names (e.g., `AddAuditLogs`, `AddGenreToTrack`).
- Run migrations via helper scripts (`scripts/migrate.sh` or `scripts/migrate.ps1`).

---

Happy migrating 🎶
```
