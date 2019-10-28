FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["MSRents/MSRents.csproj", "MSRents/"]
RUN dotnet restore "MSRents/MSRents.csproj"
COPY . .
WORKDIR "/src/MSRents"
RUN dotnet build "MSRents.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MSRents.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MSRents.dll"]