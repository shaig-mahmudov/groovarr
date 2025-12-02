
---

# 🚀 Groovarr Setup Guide

Groovarr is an open‑source playlist manager with an **ASP.NET Core + EF Core backend** and a **React + Vite frontend**. This guide walks you through setting up both parts together.

It is recommended to use [Visual Studio Code](https://code.visualstudio.com/download) to use the IDE for development. This guide was prepared using vscode and the [Recommended VS Code Extensions](#5-recommended-vs-code-extensions).

---

## 📂 Project Structure

```
groovarr/
├── backend/
│   └── Groovarr.Api/        # ASP.NET Core Web API
│       ├── Controllers/     # REST endpoints
│       ├── Services/        # Business logic
│       ├── Models/          # EF Core models
│       ├── Data/            # DbContext + schema
│       └── Migrations/      # EF Core migrations
└── frontend/
    └── web/                 # React + Vite app
        ├── src/components/  # UI components
        ├── src/api.ts       # Axios instance
        └── vite.config.ts   # Vite config
```

---

## ⚙️ Backend Setup (ASP.NET Core + EF Core)

### 1. Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

  ```powershell
   .\scripts\dotnet-install.ps1 -Version 8.0.416
  ```

- EF Core CLI tools:
  
  ```powershell
  cd .\backend\Groovarr.Api\
  dotnet tool install --global dotnet-ef --version 8.*
  ```

### 2. Create Initial Schema

Run from `backend\Groovarr.Api\`:

```powershell
cd .\backend\Groovarr.Api\
dotnet ef migrations add InitialCreate --context GroovarrDbContext --output-dir Migrations\Groovarr
```

>[!NOTE]
>To undo this migration `dotnet ef migrations remove --context GroovarrDbContext`

```powershell
dotnet ef migrations add InitialCreate --context AuthDbContext --output-dir Migrations\Auth
```

>[!NOTE]
>To undo this migration `dotnet ef migrations remove --context AuthDbContext`

```powershell
dotnet ef database update --context GroovarrDbContext
```

```powershell
dotnet ef database update --context AuthDbContext
```

### 3. Run API

Run from root of the project.

```powershell
dotnet run
```

Visit Swagger at `http://localhost:5000/docs/index.html`.

or if using curl,

```powershell
curl http://localhost:5000/swagger/v1/swagger.json
```

---

## 🎨 Frontend Setup (React + Vite)

Run from `frontend\web\`:

### 1. Prerequisites

- [Node.js LTS](https://nodejs.org/en/about/previous-releases) (includes npm). Use [Node Version Manager (nvm) installer](https://github.com/coreybutler/nvm-windows/releases/latest) to install latest.

>[!NOTE]
>If using Visual Studio Code terminal, restart vscode before continuing after installing nvm.

  ```powershell
  nvm install lts
  ```

- Verify:

  ```powershell
  node -v
  npm -v
  ```

### 2. Install Dependencies

From `frontend/web/`:

```powershell
cd .\frontend\web\ 
npm install
```

### 3. Run Dev Server

```powershell
npm run dev -- --host 0.0.0.0
```

Visit `http://localhost:5173`.

>[!TIP]
>Using the --host 0.0.0.0 option allows viewing of the page outside of localhost.

### 4. Build for Production

```bash
npm run build
npm run preview -- --host 0.0.0.0
```

Visit `http://localhost:4173`.

>[!TIP]
>Using the --host 0.0.0.0 option allows viewing of the page outside of localhost.

### 5. Recommended VS Code Extensions

- **.NET Install Tool** → .NET SDK version management
- **C# Dev Kit** → code management
- **ESLint** → linting
- **Prettier** → formatting
- **React Query Devtools** → inspect queries
- **Path Intellisense** → import autocompletion
- **Thunder Client** → test API endpoints

---

## 🔗 Quickstart Script (Optional)

Execute `.\scripts\dev.ps1` from the project root to start the Groovar application.


## ✅ Summary

- **Backend**: configure DB, run migrations, start API.  
- **Frontend**: install npm deps, run dev server, connect via `.env`.  
- **Quickstart**: one script launches both together.  

---
