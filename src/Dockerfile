#Publish Backend(.net core)
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS base
WORKDIR /attendancemanagement
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src/
COPY ["backend/WebAPI/WebAPI.csproj", "."]
RUN dotnet restore "./WebAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "backend/WebAPI/WebAPI.csproj" -c Release -o /attendancemanagement/build

FROM build AS dotnetpublish
RUN dotnet publish "backend/WebAPI/WebAPI.csproj" -c Release -o /attendancemanagement/publish

# Build Frontend(Vue)
FROM node:lts-alpine as nodebase
WORKDIR /attendancemanagement

FROM node:lts-alpine as nodebuild
WORKDIR /src/frontend/
COPY package*.json ./
RUN npm install
COPY . . 
RUN npm run build -- --prod

# Image File
FROM base AS final
WORKDIR /attendancemanagement
COPY --from=dotnetpublish /attendancemanagement/publish .
COPY --from=nodebuild /frontend/dist ./attendancemanagement/publish/wwwroot 
ENTRYPOINT ["dotnet", "WebAPI.dll"]
