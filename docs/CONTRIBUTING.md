# Contributing to Groovarr

Thank you for your interest in contributing to Groovarr!  
This document outlines guidelines and best practices for contributing code, documentation, and ideas.

---

## 🧩 How to Contribute

1. **Fork the repository** and create your branch from `main`.
   ```bash
   git checkout -b feature/my-feature
   ```
2. **Make your changes** (code, docs, tests).
3. **Run tests** to ensure everything passes:
   ```bash
   dotnet test tests/Groovarr.Tests/Groovarr.Tests.csproj
   ```
4. **Commit with clear messages**:
   ```bash
   git commit -m "Add playlist export endpoint"
   ```
5. **Push your branch** and open a Pull Request (PR).

---

## 🔄 Pull Request Guidelines

- Keep PRs focused: one feature or fix per PR.
- Ensure all builds and tests pass in CI.
- Include documentation updates if your change adds or modifies functionality.
- Reference related issues in your PR description (`Fixes #123`).
- Expect review feedback — collaborative iteration is encouraged.

---

## 🛠 Coding Standards

- **Backend (C#/.NET)**:
  - Follow .NET coding conventions.
  - Use async/await for I/O operations.
  - Add XML comments for public methods so they appear in Swagger docs.
  - Keep persistence logic consistent with other ‑arr projects (`/config` for data).

- **Frontend (React/Vite)**:
  - Use functional components and hooks.
  - Follow ESLint/Prettier formatting rules.
  - Keep UI consistent with Groovarr’s design system.

---

## 📂 Project Structure

```
groovarr/
├── backend/          # ASP.NET Core API
├── frontend/         # React/Vite UI
├── tests/            # Unit tests
├── build.sh          # Linux/macOS build script
├── build.ps1         # Windows build script
├── .github/workflows # CI/CD workflows
```

---

## 🧪 Testing

- Unit tests live in `tests/Groovarr.Tests/`.
- Add tests for new features and bug fixes.
- Ensure tests run successfully on all supported OSes (Linux, Windows, macOS).

---

## 📑 Documentation

- Update **INSTALL.md** and **USAGE.md** for user‑facing changes.
- Update **API.md** for new endpoints.
- Update **DEV.md** for developer workflows.
- Keep docs clear, concise, and consistent.

---

## 🐛 Issues

- Use GitHub Issues to report bugs, request features, or ask questions.
- Include steps to reproduce, expected behavior, and environment details.
- Tag issues appropriately (`bug`, `enhancement`, `documentation`).

---

## ✅ Community Values

- Be respectful and collaborative.
- Favor clarity and maintainability over clever hacks.
- Keep Groovarr consistent with the ‑arr ecosystem (simple archives, `/config` persistence, SQLite default).
- Encourage newcomers — Groovarr thrives on community contributions!

---

Happy contributing 🎶
