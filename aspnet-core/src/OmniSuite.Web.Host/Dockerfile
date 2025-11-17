FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/OmniSuite.Web.Host/OmniSuite.Web.Host.csproj", "src/OmniSuite.Web.Host/"]
COPY ["src/OmniSuite.Web.Core/OmniSuite.Web.Core.csproj", "src/OmniSuite.Web.Core/"]
COPY ["src/OmniSuite.Application/OmniSuite.Application.csproj", "src/OmniSuite.Application/"]
COPY ["src/OmniSuite.Core/OmniSuite.Core.csproj", "src/OmniSuite.Core/"]
COPY ["src/OmniSuite.EntityFrameworkCore/OmniSuite.EntityFrameworkCore.csproj", "src/OmniSuite.EntityFrameworkCore/"]
WORKDIR "/src/src/OmniSuite.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/OmniSuite.Web.Host", "src/OmniSuite.Web.Host"]
COPY ["src/OmniSuite.Web.Core", "src/OmniSuite.Web.Core"]
COPY ["src/OmniSuite.Application", "src/OmniSuite.Application"]
COPY ["src/OmniSuite.Core", "src/OmniSuite.Core"]
COPY ["src/OmniSuite.EntityFrameworkCore", "src/OmniSuite.EntityFrameworkCore"]
WORKDIR "/src/src/OmniSuite.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "OmniSuite.Web.Host.dll"]
