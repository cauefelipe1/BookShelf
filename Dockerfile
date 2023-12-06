#Database seeding
FROM postgres:15.1-alpine as book_shelf_database
WORKDIR /app
COPY ./Scripts/Database/init.sh /docker-entrypoint-initdb.d
COPY ./Scripts/Database/init_db.sql ./scripts/database/init_db.sql

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BookShelf.API/BookShelf.API.csproj", "BookShelf.API/"]
RUN dotnet restore "BookShelf.API/BookShelf.API.csproj"
COPY . .
WORKDIR "/src/BookShelf.API"
RUN dotnet build "BookShelf.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BookShelf.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS book_shelf_api
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookShelf.API.dll"]
