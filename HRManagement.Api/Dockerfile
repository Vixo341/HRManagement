FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HRManagement.Api/HRManagement.Api.csproj", "HRManagement.Api/"]
COPY ["HRManagement.Application/HRManagement.Application.csproj", "HRManagement.Application/"]
COPY ["HRManagement.Domain/HRManagement.Domain.csproj", "HRManagement.Domain/"]
COPY ["HRManagement.Infrastructure/HRManagement.Infrastructure.csproj", "HRManagement.Infrastructure/"]
COPY ["HRManagement.Persistence/HRManagement.Persistence.csproj", "HRManagement.Persistence/"]
RUN dotnet restore "HRManagement.Api/HRManagement.Api.csproj"
COPY . .
WORKDIR "/src/HRManagement.Api"
RUN dotnet build "HRManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HRManagement.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HRManagement.Api.dll"]
