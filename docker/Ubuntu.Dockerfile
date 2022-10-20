FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build

WORKDIR /app

COPY src/KService.Web/KService.Web.csproj       src/KService.Web/

RUN dotnet restore src/KService.Web

COPY src/KService.Web       src/KService.Web

RUN dotnet publish src/KService.Web \
    -r linux-x64 \
    -c Release \
    -o /out

FROM mcr.microsoft.com/dotnet/runtime:6.0-jammy

RUN apt-get update
RUN apt-get install -y libc6-dev
RUN apt-get install -y libgdiplus

ENV TZ='Asia/Bangkok'
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

WORKDIR /app
COPY --from=build /out .
CMD dotnet KService.Web.dll
EXPOSE 80