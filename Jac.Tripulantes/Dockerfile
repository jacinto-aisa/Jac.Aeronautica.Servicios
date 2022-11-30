#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Jac.Tripulantes/Jac.Tripulantes.csproj", "Jac.Tripulantes/"]
RUN dotnet restore "Jac.Tripulantes/Jac.Tripulantes.csproj"
COPY . .
WORKDIR "/src/Jac.Tripulantes"
RUN dotnet build "Jac.Tripulantes.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jac.Tripulantes.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jac.Tripulantes.dll"]