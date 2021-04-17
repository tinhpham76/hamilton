dotnet restore

dotnet pack -c Release -o antifacts/integration src/integration/googlemap

dotnet pack -c Release -o antifacts/integration src/integration/hamilton