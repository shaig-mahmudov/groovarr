# PowerShell build script for Groovarr (Windows)
# Produces a zip package with backend + frontend bundled

$project = "backend/Groovarr.Api/Groovarr.Api.csproj"
$outputDir = "publish"
$packageName = "groovarr"
$version = Get-Date -Format "yyyy.MM.dd.HHmm"

# Clean old builds
Remove-Item $outputDir -Recurse -Force -ErrorAction SilentlyContinue
New-Item -ItemType Directory -Path $outputDir | Out-Null

Write-Host "Building Groovarr backend..."
dotnet restore $project
dotnet publish $project -c Release -o $outputDir `
    --self-contained:$false `
    -p:PublishSingleFile=true `
    -p:PublishTrimmed=true

Write-Host "Building frontend..."
Push-Location frontend/web
npm ci
npm run build
Pop-Location

# Copy frontend files into wwwroot
New-Item -ItemType Directory -Path "$outputDir/wwwroot" -Force | Out-Null
Copy-Item -Recurse frontend/web/dist/* "$outputDir/wwwroot/"

# Package into zip
$zipFile = "$packageName-$version.zip"
if (Test-Path $zipFile) { Remove-Item $zipFile }
