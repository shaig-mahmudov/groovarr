<#
migrate.ps1 — helper for Groovarr EF Core migrations
Usage:
  ./scripts/migrate.ps1 add <MigrationName> <Context>
  ./scripts/migrate.ps1 update <Context>

Context options: groovarr, auth
#>

param(
    [Parameter(Mandatory=$true)]
    [string]$Action,

    [string]$Name,
    [string]$Context
)

$Project = "backend/Groovarr.Api/groovarr.csproj"

switch ($Action) {
    "add" {
        if ($Context -eq "groovarr") {
            dotnet ef migrations add $Name `
                --context GroovarrDbContext `
                --project $Project `
                --output-dir Migrations/Groovarr
        }
        elseif ($Context -eq "auth") {
            dotnet ef migrations add $Name `
                --context AuthDbContext `
                --project $Project `
                --output-dir Migrations/Auth
        }
        else {
            Write-Host "Unknown context: $Context (use groovarr or auth)"
        }
    }
    "update" {
        if ($Context -eq "groovarr") {
            dotnet ef database update `
                --context GroovarrDbContext `
                --project $Project
        }
        elseif ($Context -eq "auth") {
            dotnet ef database update `
                --context AuthDbContext `
                --project $Project
        }
        else {
            Write-Host "Unknown context: $Context (use groovarr or auth)"
        }
    }
    Default {
        Write-Host "Usage:"
        Write-Host "  ./scripts/migrate.ps1 add <MigrationName> <Context>"
        Write-Host "  ./scripts/migrate.ps1 update <Context>"
        Write-Host "Contexts: groovarr, auth"
    }
}
