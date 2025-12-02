#!/bin/bash
set -e

#!/bin/bash

pushd "$(pwd)" > /dev/null   # save current directory

export ASPNETCORE_ENVIRONMENT=Development
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

popd > /dev/null             # restore original directory

trap "echo '🛑 Stopping...'; kill $BACKEND_PID $FRONTEND_PID" SIGINT
wait
