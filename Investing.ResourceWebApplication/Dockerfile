#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Investing.ResourceWebApplication/Investing.ResourceWebApplication.csproj", "Investing.ResourceWebApplication/"]
COPY ["Investing.EntityFramework/Investing.EntityFramework.csproj", "Investing.EntityFramework/"]
COPY ["Investing.EntityFramework.Core/Investing.EntityFramework.Core.csproj", "Investing.EntityFramework.Core/"]
COPY ["Investing.Core/Investing.Core.csproj", "Investing.Core/"]
COPY ["Investing.HttpClients/Investing.HttpClients.csproj", "Investing.HttpClients/"]
COPY ["Investing.HttpClients.Core/Investing.HttpClients.Core.csproj", "Investing.HttpClients.Core/"]
RUN dotnet restore "Investing.ResourceWebApplication/Investing.ResourceWebApplication.csproj"
COPY . .
WORKDIR "/src/Investing.ResourceWebApplication"
RUN dotnet build "Investing.ResourceWebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Investing.ResourceWebApplication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Investing.ResourceWebApplication.dll"]