#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PagoEfectivo.PromoCode.Api/PagoEfectivo.PromoCode.Api.csproj", "PagoEfectivo.PromoCode.Api/"]
COPY ["PagoEfectivo.PromoCode.Infrastucture.Ioc/PagoEfectivo.PromoCode.Infrastucture.Ioc.csproj", "PagoEfectivo.PromoCode.Infrastucture.Ioc/"]
COPY ["PagoEfectivo.PromoCode.Infrastructure/PagoEfectivo.PromoCode.Infrastructure.csproj", "PagoEfectivo.PromoCode.Infrastructure/"]
COPY ["PagoEfectivo.PromoCode.Model/PagoEfectivo.PromoCode.Model.csproj", "PagoEfectivo.PromoCode.Model/"]
COPY ["PagoEfectivo.PromoCode.Domain/PagoEfectivo.PromoCode.Domain.csproj", "PagoEfectivo.PromoCode.Domain/"]
COPY ["PagoEfectivo.PromoCode.CrossCuting/PagoEfectivo.PromoCode.CrossCuting.csproj", "PagoEfectivo.PromoCode.CrossCuting/"]
RUN dotnet restore "PagoEfectivo.PromoCode.Api/PagoEfectivo.PromoCode.Api.csproj"
COPY . .
WORKDIR "/src/PagoEfectivo.PromoCode.Api"
RUN dotnet build "PagoEfectivo.PromoCode.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PagoEfectivo.PromoCode.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PagoEfectivo.PromoCode.Api.dll"]