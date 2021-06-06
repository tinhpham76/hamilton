cd src/integration/googlemap

dotnet restore

dotnet build

cd ../../..

dotnet pack -c Release -o antifacts/integration src/integration/googlemap