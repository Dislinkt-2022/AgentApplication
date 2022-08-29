#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["AgentApplication.WebAPI/AgentApplication.WebAPI.csproj", "AgentApplication.WebAPI/"]
RUN dotnet restore "AgentApplication.WebAPI/AgentApplication.WebAPI.csproj"
COPY . .
WORKDIR "/src/AgentApplication.WebAPI"
RUN dotnet build "AgentApplication.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AgentApplication.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgentApplication.WebAPI.dll"]