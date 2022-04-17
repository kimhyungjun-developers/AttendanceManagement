FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src

COPY backend/*.sln .
COPY backend/WebAPI/*.csproj ./backend/WebAPI/
RUN dotnet restore

COPY backend/WebAPI/. ./backend/WebAPI/
WORKDIR /source/backend/WebAPI/
RUN dotnet publish -c release -o /app --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebAPI.dll"]
