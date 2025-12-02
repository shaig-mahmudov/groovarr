Here’s a scaffolded **USAGE.md** you can add alongside your INSTALL.md. It focuses on how to actually run Groovarr, interact with it, and configure common scenarios — very much in the style of Sonarr/Radarr documentation.

---

```markdown
# Groovarr Usage Guide

Groovarr is a playlist manager for Plex, designed to run as a self‑contained service with a web UI.  
This document explains how to start Groovarr, access the interface, and configure common options.

---

## 🚀 Starting Groovarr

### From Prebuilt Package
1. Extract the archive (`groovarr-<version>.tar.gz` on Linux/macOS, `groovarr-<version>.zip` on Windows).
2. Navigate into the extracted folder (`publish/`).
3. Run Groovarr:
   - **Linux/macOS**:
     ```bash
     dotnet Groovarr.Api.dll
     ```
     or, if self‑contained binaries are provided:
     ```bash
     ./Groovarr
     ```
   - **Windows**:
     ```powershell
     Groovarr.exe
     ```

### From Source
See [INSTALL.md](INSTALL.md) for build instructions.

---

## 🌐 Accessing the UI

- **Frontend UI**: [http://localhost:5000](http://localhost:5000)  
- **Backend API**: [http://localhost:5000/api](http://localhost:5000/api)

---

## ⚙️ Configuration

Groovarr stores all configuration in `/config`.  
Always mount or point `/config` to a persistent location.

### Default Files
- `groovarr.db` → main SQLite database
- `auth.db` → authentication database
- `appsettings.json` → application settings
- `logs/` → runtime logs

### Environment Variables
You can override defaults at runtime:

```bash
# Database provider (sqlite, postgres, mysql)
DatabaseProvider__GroovarrDb=sqlite
DatabaseProvider__AuthDb=sqlite

# Connection strings
ConnectionStrings__GroovarrDb="Data Source=/config/groovarr.db"
ConnectionStrings__AuthDb="Data Source=/config/auth.db"

# Logging level
Logging__LogLevel__Default=Information
```

---

## 📂 Persistence

To ensure your playlists and settings survive upgrades, mount `/config`:

```bash
# Linux/macOS
./Groovarr --config /path/to/config

# Windows
Groovarr.exe --config C:\path\to\config
```

---

## 🔑 Authentication

- Groovarr uses the `AuthDb` SQLite database in `/config/auth.db`.  
- First run will prompt you to create an admin account.  
- Credentials are stored locally; you can reset them by deleting `auth.db`.

---

## 🛠 Common Tasks

- **View logs**: check `/config/logs/` for runtime logs.  
- **Reset database**: delete `groovarr.db` (playlists will be lost).  
- **Change port**: set environment variable:
  ```bash
  ASPNETCORE_URLS=http://+:8080
  ```
- **Switch database provider**: update `DatabaseProvider` and `ConnectionStrings` in `appsettings.json` or environment variables.

---

## 🧪 API Usage

Groovarr exposes a REST API at `/api`.  
Example request:

```bash
curl http://localhost:5000/api/playlists
```

Returns a JSON list of playlists.

---

## 🛠 Troubleshooting

- Ensure `.NET 8.0` runtime is installed if using framework‑dependent builds.
- Verify `/config` is writable by the Groovarr process.
- Check logs in `/config/logs/` for detailed error messages.
- If frontend doesn’t load, confirm `wwwroot` contains built files.

---

## ✅ Next Steps

- Connect Groovarr to Plex via the UI.
- Create and manage playlists.
- Explore advanced settings in `/config/appsettings.json`.

---

Happy playlisting 🎶
```

---
