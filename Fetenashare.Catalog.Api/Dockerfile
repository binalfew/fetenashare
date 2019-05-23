FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Fetenashare.Catalog.Api/Fetenashare.Catalog.Api.csproj Fetenashare.Catalog.Api/
COPY Fetenashare.Flogger/Fetenashare.Flogger.csproj Fetenashare.Flogger/
COPY Fetenashare.Catalog.Persistence/Fetenashare.Catalog.Persistence.csproj Fetenashare.Catalog.Persistence/
COPY Fetenashare.Catalog.Domain/Fetenashare.Catalog.Domain.csproj Fetenashare.Catalog.Domain/
COPY Fetenashare.Kernel/Fetenashare.Kernel.csproj Fetenashare.Kernel/
RUN dotnet restore Fetenashare.Catalog.Api/Fetenashare.Catalog.Api.csproj
COPY . .
WORKDIR /src/Fetenashare.Catalog.Api
RUN dotnet build Fetenashare.Catalog.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Fetenashare.Catalog.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Fetenashare.Catalog.Api.dll"]
