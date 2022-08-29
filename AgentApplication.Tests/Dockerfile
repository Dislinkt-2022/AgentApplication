FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src

COPY ["AgentApplication.Tests/AgentApplication.Tests.csproj", "AgentApplication.Tests/"]
COPY ["AgentApplication.WebAPI/AgentApplication.WebAPI.csproj", "AgentApplication.WebAPI/"]

RUN dotnet restore "AgentApplication.Tests/AgentApplication.Tests.csproj"
COPY . .
WORKDIR "/src/AgentApplication.Tests"
RUN dotnet build "AgentApplication.Tests.csproj" -c Release -o /app/build


FROM build AS testrunner
WORKDIR /src/AgentApplication.Tests
CMD ["dotnet", "test", "--no-restore"]