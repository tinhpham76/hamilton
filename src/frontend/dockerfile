FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
EXPOSE 80
EXPOSE 443

WORKDIR /app

COPY ["./src/", "src/"]
COPY ["./shared/", "shared/"]
COPY ["./libs/*.nupkg", "libs/"]
COPY ["nuget.config", "nuget.config"]

RUN dotnet restore "src/Hamilton.csproj"

WORKDIR "/app/src"
RUN dotnet build "Hamilton.csproj" -c Release -o /app/build
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_16.x | bash - && \
    apt-get install -y build-essential nodejs

FROM build AS publish
RUN dotnet publish "Hamilton.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hamilton.dll"]