cd src/client

dotnet restore

dotnet build

cd ../..

dotnet pack -c Release -o antifacts/client src/client