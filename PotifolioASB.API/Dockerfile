#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# estagio 1
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:8000;http://+:80;
ENV ASPNETCORE_ENVIRONMENT=Developmet

# estagio 2
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PotifolioASB.API/PotifolioASB.API.csproj", "PotifolioASB.API/"]
COPY ["PotifolioASB.Domain/PotifolioASB.Domain.csproj", "PotifolioASB.Domain/"]
COPY ["PotifolioASB.Infra/PotifolioASB.Infra.csproj", "PotifolioASB.Infra/"]
COPY ["PotifolioASB.Service/PotifolioASB.Service.csproj", "PotifolioASB.Service/"]
RUN dotnet restore "PotifolioASB.API/PotifolioASB.API.csproj"
COPY . .
WORKDIR "/src/PotifolioASB.API"
RUN dotnet build "PotifolioASB.API.csproj" -c Release -o /app/build

# estagio 3
FROM build AS publish
RUN dotnet publish "PotifolioASB.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# estagio 4
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PotifolioASB.API.dll"]