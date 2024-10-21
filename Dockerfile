FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-reservation-service
WORKDIR /app
COPY ./ReservationService/*.csproj ./
RUN dotnet restore
COPY ./ReservationService ./
RUN dotnet publish -c Release -o /out/

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-payment-service
WORKDIR /app
COPY ./PaymentService/*.csproj ./
RUN dotnet restore
COPY ./PaymentService ./
RUN dotnet publish -c Release -o /out/

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-loyalty-service
WORKDIR /app
COPY ./LoyaltyService/*.csproj ./
RUN dotnet restore
COPY ./LoyaltyService ./
RUN dotnet publish -c Release -o /out/

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-gateway-service
WORKDIR /app
COPY ./GatewayService/*.csproj ./
RUN dotnet restore
COPY ./GatewayService ./
RUN dotnet publish -c Release -o /out/

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-tests
WORKDIR /tests
COPY ./DIPS_lab2.Tests/ ./
COPY --from=build-gateway-service /app/ ../GatewayService/
COPY --from=build-payment-service /app/ ../PaymentService/
COPY --from=build-loyalty-service /app/ ../LoyaltyService/
COPY --from=build-reservation-service /app/ ../ReservationService/
RUN dotnet restore
RUN dotnet build -c Release -o /out/tests

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime-GatewayService
WORKDIR /app
COPY --from=build-gateway-service /out/ .
ENV ASPNETCORE_HTTP_PORTS=8080
ENTRYPOINT ["dotnet", "GatewayService.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build-loyalty-service /out/ .
ENV ASPNETCORE_HTTP_PORTS=8050
ENTRYPOINT ["dotnet", "LoyaltyService.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime-PaymentService
WORKDIR /app
COPY --from=build-payment-service /out/ .
ENV ASPNETCORE_HTTP_PORTS=8060
ENTRYPOINT ["dotnet", "PaymentService.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime-ReservationService
WORKDIR /app
COPY --from=build-reservation-service /out/ .
ENV ASPNETCORE_HTTP_PORTS=8070
ENTRYPOINT ["dotnet", "ReservationService.dll"]