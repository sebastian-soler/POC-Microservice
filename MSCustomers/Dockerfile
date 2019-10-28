FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["MSCustomers/MSCustomers.csproj", "MSCustomers/"]
RUN dotnet restore "MSCustomers/MSCustomers.csproj"
COPY . .
WORKDIR "/src/MSCustomers"
RUN dotnet build "MSCustomers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MSCustomers.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MSCustomers.dll"]