FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /app

COPY ["AgentApplication.Migration/AgentApplication.Migration.csproj", "AgentApplication.Migration/"]

RUN dotnet restore "AgentApplication.Migration/AgentApplication.Migration.csproj"
COPY . .
RUN dotnet publish "AgentApplication.Migration/AgentApplication.Migration.csproj" -c Release -o /app/publish

WORKDIR /app/publish
ENTRYPOINT ["dotnet", "./AgentApplication.Migration.dll"]