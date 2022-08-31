FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine
WORKDIR /src

COPY ["AgentApplication.Tests/AgentApplication.Tests.csproj", "AgentApplication.Tests/"]
COPY ["AgentApplication.WebAPI/AgentApplication.WebAPI.csproj", "AgentApplication.WebAPI/"]

RUN dotnet restore "AgentApplication.Tests/AgentApplication.Tests.csproj"
COPY . .

WORKDIR /src/AgentApplication.Tests
CMD ["dotnet", "test", "--no-restore"]