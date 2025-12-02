# Groovarr Developer Guide (DEV.md)

This document is for contributors who want to build, test, and extend Groovarr.  
For installation and usage instructions, see [INSTALL.md](INSTALL.md) and [USAGE.md](USAGE.md).

---

## 🧩 Prerequisites

- **.NET 8.0 SDK** (for backend development)
- **Node.js 20+** (for frontend development)
- **npm** (bundled with Node.js)
- **SQLite** (default DB provider, bundled with Groovarr)
- GitHub account (for contributing)

---

## 🚀 Local Development Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/<owner>/groovarr.git
   cd groovarr
   ```

2. Build backend:
   ```bash
   dotnet restore backend/Groovarr.Api/Groovarr.Api.csproj
   dotnet build backend/Groovarr.Api/Groovarr.Api.csproj -c Debug
   ```

3. Build frontend:
   ```bash
   cd frontend/web
   npm ci
   npm run dev
   ```

4. Run backend with hot reload:
   ```bash
   dotnet watch run --project backend/Groovarr.Api/Groovarr.Api.csproj
   ```

5. Access UI at [http://localhost:5000](http://localhost:5000).

---

## 📦 Build Scripts

- **Linux/macOS**: `build.sh` → produces `groovarr-<version>.tar.gz`
- **Windows**: `build.ps1` → produces `groovarr-<version>.zip`

Both scripts bundle backend + frontend into a portable archive.

---

## 📑 API Documentation (Swagger)

Groovarr uses [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) for self‑documenting APIs.

### Add Package
```bash
dotnet add package Swashbuckle.AspNetCore
```

### Enable in `Program.cs`
```csharp
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Groovarr API v1");
        c.RoutePrefix = "docs";
    });
}
```

- Swagger JSON: `/swagger/v1/swagger.json`
- Swagger UI: `/docs`

---

## 🧪 Testing

- Unit tests are located in `tests/Groovarr.Tests/`.
- Run tests:
  ```bash
  dotnet test tests/Groovarr.Tests/Groovarr.Tests.csproj
  ```

---

## 🔄 CI/CD Workflows

- **build.yml** → matrix build/test for backend + frontend, uploads artifacts.
- **deploy.yml** → downloads artifacts, deploys backend + frontend.
- Artifacts:  
  - Backend binaries (`groovarr-backend-<os>`)  
  - Frontend static files (`groovarr-frontend-<os>`)

---

## 📂 Project Structure

```
groovarr/
├── backend/
│   └── Groovarr.Api/        # ASP.NET Core backend
├── frontend/
│   └── web/                 # React/Vite frontend
├── tests/
│   └── Groovarr.Tests/      # Unit tests
├── build.sh                 # Linux/macOS build script
├── build.ps1                # Windows build script
├── .github/workflows/       # CI/CD workflows
```

---

## 🛠 Contribution Guidelines

- Fork the repo and create feature branches (`feature/<name>`).
- Ensure tests pass before submitting PRs.
- Document new endpoints with XML comments so they appear in Swagger.
- Follow C# coding conventions and React best practices.
- Keep `/config` persistence logic consistent with other ‑arr projects.

---

## ✅ Next Steps

- Explore Swagger UI at `/docs` for live API testing.
- Add new endpoints by extending controllers in `backend/Groovarr.Api`.
- Update frontend components in `frontend/web` for new features.
- Submit PRs with clear commit messages and linked issues.

---

Happy contributing 🎶
