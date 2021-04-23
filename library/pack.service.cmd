cd src/service

dotnet restore

dotnet pack -c Release -o antifacts/service src/service