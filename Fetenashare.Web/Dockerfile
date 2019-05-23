FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Fetenashare.Web/Fetenashare.Web.csproj Fetenashare.Web/
COPY Fetenashare.Flogger/Fetenashare.Flogger.csproj Fetenashare.Flogger/
COPY Fetenashare.Kernel/Fetenashare.Kernel.csproj Fetenashare.Kernel/
RUN dotnet restore Fetenashare.Web/Fetenashare.Web.csproj
COPY . .
WORKDIR /src/Fetenashare.Web
RUN dotnet build Fetenashare.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Fetenashare.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Fetenashare.Web.dll"]
