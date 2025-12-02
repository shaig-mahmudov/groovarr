#!/usr/bin/env bash
set -euo pipefail

# Variables
PROJECT="backend/Groovarr.Api/Groovarr.Api.csproj"
OUTPUT_DIR="publish"
PACKAGE_NAME="groovarr"
VERSION=$(date +%Y.%m.%d.%H%M)   # or pull from your csproj/AssemblyInfo

# Clean old builds
rm -rf "$OUTPUT_DIR"
mkdir -p "$OUTPUT_DIR"

echo "Building Groovarr backend..."
dotnet restore "$PROJECT"
dotnet publish "$PROJECT" -c Release -o "$OUTPUT_DIR" \
  --self-contained false \
  -p:PublishSingleFile=true \
  -p:PublishTrimmed=true

echo "Copying frontend..."
cd frontend/web
npm ci
npm run build
cd ../..

# Place frontend files into wwwroot
mkdir -p "$OUTPUT_DIR/wwwroot"
cp -r frontend/web/dist/* "$OUTPUT_DIR/wwwroot/"

# Package into tar.gz
TARBALL="${PACKAGE_NAME}-${VERSION}.tar.gz"
tar -czf "$TARBALL" -C "$OUTPUT_DIR" .

echo "Build complete: $TARBALL"
echo "To run: extract and execute 'dotnet Groovarr.Api.dll'"
