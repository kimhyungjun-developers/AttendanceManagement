FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
COPY backend/*.sln ./
COPY backend/WebAPI/*.csproj ./WebAPI/
COPY backend/Model/*.csproj ./Model/
COPY backend/Service/*.csproj ./Service/
COPY backend/UnitTest/*.csproj ./UnitTest/
RUN dotnet restore
COPY WebAPI/ ./
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]
