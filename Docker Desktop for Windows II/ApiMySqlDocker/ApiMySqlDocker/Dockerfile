#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ApiMySqlDocker/ApiMySqlDocker.csproj", "ApiMySqlDocker/"]
RUN dotnet restore "ApiMySqlDocker/ApiMySqlDocker.csproj"
COPY . .
WORKDIR "/src/ApiMySqlDocker"
RUN dotnet build "ApiMySqlDocker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiMySqlDocker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiMySqlDocker.dll"]
