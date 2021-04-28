cd src/utils

dotnet restore

cd ../..

dotnet pack -c Release -o antifacts/utils src/utils