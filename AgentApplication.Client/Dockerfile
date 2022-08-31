FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src

ARG API_URL="\"http://localhost:8080/api/server\""

COPY ["AgentApplication.Client/AgentApplication.Client.csproj", "AgentApplication.Client/"]
RUN dotnet restore "AgentApplication.Client/AgentApplication.Client.csproj"
COPY . .
RUN sed -i -e "/\"ApiUrl\":/c\"ApiUrl\":\\${API_URL}" AgentApplication.Client/wwwroot/appsettings.json
RUN dotnet build "AgentApplication.Client/AgentApplication.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AgentApplication.Client/AgentApplication.Client.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
EXPOSE 8080

COPY --from=publish /app/publish/wwwroot .
COPY AgentApplication.Client/nginx.conf /etc/nginx/nginx.conf
