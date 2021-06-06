cd src/utils

dotnet restore

dotnet build

cd ../..

dotnet pack -c Release -o antifacts/utils src/utils