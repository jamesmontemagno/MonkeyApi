#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MonkeyApp1/MonkeyApp1.csproj", "MonkeyApp1/"]
RUN dotnet restore "MonkeyApp1/MonkeyApp1.csproj"
COPY . .
WORKDIR "/src/MonkeyApp1"
RUN dotnet build "MonkeyApp1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MonkeyApp1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MonkeyApp1.dll"]