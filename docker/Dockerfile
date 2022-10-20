FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build

WORKDIR /app

COPY src/KService.Web/KService.Web.csproj       src/KService.Web/

RUN dotnet restore src/KService.Web

COPY src/KService.Web       src/KService.Web

RUN dotnet publish src/KService.Web \
    -r linux-musl-x64 \
    -c Release \
    -o /out

# runtime
FROM mcr.microsoft.com/dotnet/runtime:6.0-alpine

RUN apk add --no-cache tzdata
RUN apk add --no-cache icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib
RUN apk add libgdiplus-dev --update-cache --repository http://dl-3.alpinelinux.org/alpine/edge/testing/ --allow-untrusted

ENV TZ='Asia/Bangkok'
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

WORKDIR /app
COPY --from=build /out .
CMD dotnet KService.Web.dll
EXPOSE 80