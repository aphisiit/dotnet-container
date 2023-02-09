FROM mcr.microsoft.com/dotnet/sdk:6.0.405-alpine3.17 as builder
USER root

RUN mkdir -p /opt/dotnet/webapi
RUN mkdir -p /opt/dotnet/LogConfigure

WORKDIR /opt/dotnet

ADD webapi webapi
ADD LogConfigure LogConfigure

RUN dotnet restore webapi
RUN dotnet publish webapi -c Release 

FROM mcr.microsoft.com/dotnet/aspnet:6.0.13-alpine3.17
USER root

ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

RUN apk add --no-cache curl icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib tzdata

RUN mkdir -p /opt/app-root
WORKDIR /opt/app-root

EXPOSE 9090

COPY --from=builder /opt/dotnet/webapi/bin/Release/net6.0/publish .
ENTRYPOINT [ "dotnet", "webapi.dll" ]