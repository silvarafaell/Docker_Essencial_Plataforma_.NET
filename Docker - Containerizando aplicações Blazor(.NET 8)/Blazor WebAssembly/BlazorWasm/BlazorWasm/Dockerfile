FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
EXPOSE 8080
EXPOSE 8081
WORKDIR /src

COPY BlazorWasm.csproj .
RUN dotnet restore BlazorWasm.csproj

COPY . .
RUN dotnet build BlazorWasm.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish BlazorWasm.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf

