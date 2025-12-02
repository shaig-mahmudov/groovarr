
# Groovarr Installation Guide

Groovarr is an open‑source playlist manager for Plex, designed in the style of other ‑arr projects.  
This document explains how to install, configure, and run Groovarr.

---

## 📦 Requirements

- **.NET 8.0 Runtime** (or SDK if building from source)
- **Node.js 20+** (for frontend builds, not required if using prebuilt packages)
- **SQLite** (bundled by default, no external DB required)
- Supported operating systems:
  - Linux (x64, arm64)
  - Windows (x64)
  - macOS (x64, arm64)

---

## 🚀 Installation Options

### Option 1: Prebuilt Tarball (Recommended)
1. Download the latest release tarball (`groovarr-<version>.tar.gz`) from GitHub Releases.
2. Extract it:
   ```bash
   tar -xzf groovarr-<version>.tar.gz
   cd publish
   ```
3. Run Groovarr:
   ```bash
   dotnet Groovarr.Api.dll
   ```
   or, if self‑contained binaries are provided:
   ```bash
   ./Groovarr
   ```

### Option 2: Build From Source
1. Clone the repository:
   ```bash
   git clone https://github.com/<owner>/groovarr.git
   cd groovarr
   ```
2. Build backend:
   ```bash
   dotnet publish backend/Groovarr.Api/Groovarr.Api.csproj -c Release -o publish
   ```
3. Build frontend:
   ```bash
   cd frontend/web
   npm ci && npm run build
   cd ../..
   cp -r frontend/web/dist/* publish/wwwroot/
   ```
4. Run Groovarr:
   ```bash
   dotnet publish/Groovarr.Api.dll
   ```

---

## ⚙️ Configuration

Groovarr stores all configuration and database files in `/config`.

- **Default SQLite DB**: `/config/groovarr.db`
- **Auth DB**: `/config/auth.db`
- **Logs**: `/config/logs/`

### Environment Variables
You can override defaults with environment variables:

```bash
# Database provider (sqlite, postgres, mysql)
DatabaseProvider__GroovarrDb=sqlite
DatabaseProvider__AuthDb=sqlite

# Connection strings
ConnectionStrings__GroovarrDb="Data Source=/config/groovarr.db"
ConnectionStrings__AuthDb="Data Source=/config/auth.db"
```

### appsettings.json
Groovarr ships with sensible defaults in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "GroovarrDb": "Data Source=/config/groovarr.db",
    "AuthDb": "Data Source=/config/auth.db"
  },
  "DatabaseProvider": {
    "GroovarrDb": "sqlite",
    "AuthDb": "sqlite"
  }
}
```

---

## 📂 Persistence

Always mount `/config` to a persistent location so your playlists and settings survive upgrades:

```bash
./Groovarr --config /path/to/config
```

or in Docker (if you choose to containerize later):

```bash
-v ./config:/config
```

---

## 🌐 Access

- **Frontend UI**: http://localhost:5000  
- **Backend API**: http://localhost:5000/api  

---

## 🛠 Troubleshooting

- Ensure `.NET 8.0` runtime is installed if using framework‑dependent builds.
- Check logs in `/config/logs/` for errors.
- Verify permissions on `/config` so Groovarr can read/write its database.

---

## ✅ Next Steps

- Configure Plex connection in the UI.
- Create your first playlist.
- Explore advanced settings in `/config/appsettings.json`.

---

Happy playlisting 🎶

