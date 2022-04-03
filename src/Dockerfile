#Publish Backend(.net core)
# Build Backend
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS dotnetbuild
WORKDIR /src/backend

COPY *.sln .
COPY WebAPI/*.csproj ./WebAPI
RUN dotnet restore -r linux-x64

COPY WebAPI/. ./WebAPI/

WORKDIR /src/backend/WebAPI
RUN dotnet publish -c Release -o /attendancemanagement --no-restore -r linux-x64 --self-contained false

# Build Frontend(Vue)
FROM node:lts-alpine as nodebuild
WORKDIR /src/frontend
COPY package*.json ./
RUN npm install
COPY . . 
RUN npm run build -- --prod

# Image File
FROM base AS final
WORKDIR /attendancemanagement
COPY --from=dotnetpublish /attendancemanagement ./
COPY --from=nodebuild /frontend/dist ./attendancemanagement/wwwroot 
ENTRYPOINT ["dotnet", "WebAPI.dll"]
