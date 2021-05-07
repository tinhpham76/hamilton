cd src/service

dotnet restore

dotnet build

cd ../..

dotnet pack -c Release -o antifacts/service src/service