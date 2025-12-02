
---

# 🚀 Groovarr Setup Guide

Groovarr is an open‑source playlist manager with an **ASP.NET Core + EF Core backend** and a **React + Vite frontend**. This guide walks you through setting up both parts together.

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
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
  ```bash
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-8.0
  ```
- SQLite (optional SQL Server, PostgreSQL)
- EF Core CLI tools:
  ```bash
  dotnet tool install --global dotnet-ef --version 8.*
  ```
  Ensure the toEF Core CLI tools folder is in the PATH for the current session.
  ```
  export PATH="$PATH:~/.dotnet/tools"
  ```

### 2. Create Initial Schema
Run from `backend/Groovarr.Api/`:
```bash
dotnet ef migrations add InitialCreate \
  --context GroovarrDbContext \
  --output-dir Migrations/Groovarr
```
```bash
dotnet ef migrations add InitialCreate \
  --context AuthDbContext \
  --output-dir Migrations/Auth
```
```bash
dotnet ef database update --context GroovarrDbContext
```
```bash
dotnet ef database update --context AuthDbContext
```

### 3. Run API
Run from root of the project.
```bash
dotnet run --project backend/Groovarr.Api
```
Visit Swagger at `http://localhost:5000/swagger`.

or if using curl,

```
curl http://localhost:5000/swagger/v1/swagger.json
```
---

## 🎨 Frontend Setup (React + Vite)

### 1. Prerequisites
- [Node.js LTS](https://nodejs.org/) (includes npm). Use Node Version Manager (nvm) to install latest.
  ```bash
  curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.40.3/install.sh | bash
  source ~/.bashrc
  nvm install node
  ```
- Verify:
  ```bash
  node -v
  npm -v
  ```

### 2. Install Dependencies
From `frontend/web/`:
```bash
npm install
```

### 3. Run Dev Server
```bash
npm run dev -- --host 0.0.0.0
```
Visit `http://localhost:5173`.

### 4. Build for Production
```bash
npm run build
npm run preview -- --host 0.0.0.0
```

### 5. Environment Variables
Create `.env` in `frontend/web/`:
```env
VITE_API_BASE=http://localhost:5000/api
```

Use in code:
```ts
const api = axios.create({
  baseURL: import.meta.env.VITE_API_BASE,
});
```

### 6. Recommended VS Code Extensions
- **ESLint** → linting
- **Prettier** → formatting
- **React Query Devtools** → inspect queries
- **Path Intellisense** → import autocompletion
- **Thunder Client** → test API endpoints

---

## 🔗 Quickstart Script (Optional)

Add `scripts/dev.sh`:

```bash
#!/bin/bash
set -e

echo "🚀 Starting Groovarr backend..."
cd backend/Groovarr.Api
dotnet restore
dotnet run &
BACKEND_PID=$!

echo "🎨 Starting Groovarr frontend..."
cd ../../frontend/web
npm install
npm run dev &
FRONTEND_PID=$!

trap "echo '🛑 Stopping...'; kill $BACKEND_PID $FRONTEND_PID" SIGINT
wait
```

Run:
```bash
chmod +x scripts/dev.sh
./scripts/dev.sh
```

Backend → `http://localhost:5000`  
Frontend → `http://localhost:5173`

---

## ✅ Summary
- **Backend**: configure DB, run migrations, start API.  
- **Frontend**: install npm deps, run dev server, connect via `.env`.  
- **Quickstart**: one script launches both together.  

---
