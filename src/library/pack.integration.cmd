cd src/integration/googlemap

dotnet restore

cd ../../..

dotnet pack -c Release -o antifacts/integration src/integration/googlemap