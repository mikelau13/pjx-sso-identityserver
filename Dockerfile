#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to multistage  build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["IdentityServerAspNetIdentity.csproj", "sso/"]
RUN dotnet restore "sso/IdentityServerAspNetIdentity.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "IdentityServerAspNetIdentity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServerAspNetIdentity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY pjx-sso-identityserver.cert_rsa512.pfx .
COPY localhost.cert_rsa512.pfx .
ENTRYPOINT ["dotnet", "IdentityServerAspNetIdentity.dll"]
