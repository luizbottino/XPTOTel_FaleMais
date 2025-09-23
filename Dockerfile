FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["XPTOTel_FaleMais.Api/XPTOTel_FaleMais.Api.csproj", "XPTOTel_FaleMais.Api/"]
COPY ["XPTOTel_FaleMais.Application/XPTOTel_FaleMais.Application.csproj", "XPTOTel_FaleMais.Application/"]
COPY ["XPTOTel_FaleMais.Domain/XPTOTel_FaleMais.Domain.csproj", "XPTOTel_FaleMais.Domain/"]
COPY ["XPTOTel_FaleMais.Infrastructure/XPTOTel_FaleMais.Infrastructure.csproj", "XPTOTel_FaleMais.Infrastructure/"]
COPY ["XPTOTel_FaleMais.Tests/XPTOTel_FaleMais.Tests.csproj", "XPTOTel_FaleMais.Tests/"]
COPY ["XPTOTel_FaleMais.sln", "."]

RUN dotnet restore "XPTOTel_FaleMais.sln"

COPY . .

WORKDIR "/src/XPTOTel_FaleMais.Api"
RUN dotnet publish "XPTOTel_FaleMais.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "XPTOTel_FaleMais.Api.dll"]