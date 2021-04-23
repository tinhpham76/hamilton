cd src/utils

dotnet restore

dotnet pack -c Release -o antifacts/utils src/utils