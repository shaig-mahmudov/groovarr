<#
dev.ps1 — start Groovarr backend and frontend together
Usage:
  ./scripts/dev.ps1
#>

# Stop on error
$ErrorActionPreference = "Stop"

Write-Host "🚀 Starting Groovarr backend..."
Set-Location backend/Groovarr.Api
dotnet restore
$backend = Start-Process dotnet -ArgumentList "run" -PassThru

Write-Host "🎨 Starting Groovarr frontend..."
Set-Location ../../frontend/web
npm install
$frontend = Start-Process npm -ArgumentList "run dev" -PassThru

# Handle Ctrl+C (SIGINT equivalent)
Register-EngineEvent PowerShell.Exiting -Action {
    Write-Host "🛑 Stopping..."
    if ($backend -and !$backend.HasExited) { $backend.Kill() }
    if ($frontend -and !$frontend.HasExited) { $frontend.Kill() }
}

# Wait for both processes
Wait-Process -Id $backend.Id, $frontend.Id
