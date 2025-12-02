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
