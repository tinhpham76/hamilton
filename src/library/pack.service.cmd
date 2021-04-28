cd src/service

dotnet restore

cd ../..

dotnet pack -c Release -o antifacts/service src/service