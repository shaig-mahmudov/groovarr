# 🎶 Groovarr

Groovarr — your DJ for Plex playlists.

Groovarr is an open‑source playlist manager inspired by the *‑arr* ecosystem. It lets you create playlists, add tracks, generate share links, embed playlists, and audit activity — with a clean React frontend and ASP.NET Core backend.

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

1. **Install dependencies**
   ```bash
   dotnet restore
   ```

2. **Configure database**  
   Edit `backend/Groovarr.Api/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "GroovarrDb": "Server=localhost;Database=Groovarr;Trusted_Connection=True;"
     }
   }
   ```

3. **Apply migrations**
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Run API**
   ```bash
   dotnet run --project backend/Groovarr.Api
   ```
   Visit Swagger at `http://localhost:5000/swagger`.

---

## 🎨 Frontend Setup (React + Vite)

1. **Install dependencies**
   ```bash
   cd frontend/web
   npm install
   ```

2. **Run dev server**
   ```bash
   npm run dev
   ```
   Visit `http://localhost:5173`.

3. **Key components**
   - `PlaylistForm` → create playlists
   - `PlaylistList` → view/delete playlists
   - `PlaylistSelector` → switch active playlist
   - `TrackSearch` → add tracks
   - `ShareLinkManager` → generate share links
   - `EmbedCodeGenerator` → copy iframe embed code
   - `EmbedViewer` → render playlist JSON
   - `AuditLogDashboard` → view audit logs

---

## 🔗 Endpoints Overview
- `GET /api/playlists` → list playlists  
- `POST /api/playlists` → create playlist  
- `DELETE /api/playlists/{id}` → delete playlist  
- `POST /api/tracks/{playlistId}` → add track  
- `POST /api/share/{playlistId}` → generate share link  
- `GET /api/share/{token}` → fetch shared playlist  
- `GET /api/embed/{playlistId}` → JSON embed payload  
- `GET /api/audit` → recent audit logs  

---

## 🛠 Development Workflow
- **Backend changes** → update models, run `dotnet ef migrations add <Name>`, then `dotnet ef database update`.  
- **Frontend changes** → edit components in `src/components/`, hot‑reload via Vite.  
- **Testing** → use Swagger for backend, React Query Devtools for frontend.  

---

## ✅ Summary
Groovarr combines:
- **ASP.NET Core + EF Core** → backend API + schema.  
- **React + Vite + Axios + React Query** → frontend dashboard.  
- **Embed + Share features** → playlists can be shared or embedded anywhere.  
