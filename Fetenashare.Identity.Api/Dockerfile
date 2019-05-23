FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Fetenashare.Identity.Api/Fetenashare.Identity.Api.csproj Fetenashare.Identity.Api/
RUN dotnet restore Fetenashare.Identity.Api/Fetenashare.Identity.Api.csproj
COPY . .
WORKDIR /src/Fetenashare.Identity.Api
RUN dotnet build Fetenashare.Identity.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Fetenashare.Identity.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Fetenashare.Identity.Api.dll"]
