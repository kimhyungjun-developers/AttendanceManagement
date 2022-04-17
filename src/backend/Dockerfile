FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src/backend

COPY backend/*.sln .
COPY backend/WebAPI/*.csproj ./backend/WebAPI/
COPY backend/Model/*.csproj ./backend/Model/
COPY backend/Service/*.csproj ./backend/Service/
COPY backend/UnitTest/*.csproj ./backend/UnitTest/
RUN dotnet restore

COPY backend/WebAPI/. ./backend/WebAPI/
WORKDIR /source/backend/WebAPI/
RUN dotnet publish -c release -o /app --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebAPI.dll"]
