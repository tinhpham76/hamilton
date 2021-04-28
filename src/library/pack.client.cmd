cd src/client

dotnet restore

cd ../..

dotnet pack -c Release -o antifacts/client src/client