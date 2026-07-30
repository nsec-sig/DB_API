# --- build stage ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# csprojを先にコピーしてrestore（compose build時にNuGet復元）
COPY src/Api/Api.csproj src/Api/
RUN dotnet restore src/Api/Api.csproj

# 残りをコピーしてpublish
COPY . .
RUN dotnet publish src/Api/Api.csproj -c Release -o /app/out --no-restore

# --- runtime stage ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Api.dll"]
