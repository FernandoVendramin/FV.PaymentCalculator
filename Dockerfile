FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS build-env
WORKDIR /app

# Copiar csproj e restaurar dependencias
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /build
COPY FV.PaymentCalculator.sln ./
COPY /src/FV.PaymentCalculator.Console/*.csproj ./src/FV.PaymentCalculator.Console/
COPY /src/FV.PaymentCalculator.Core/*.csproj ./src/FV.PaymentCalculator.Core/
COPY /src/FV.PaymentCalculator.Facade/*.csproj ./src/FV.PaymentCalculator.Facade/
COPY /src/FV.PaymentCalculator.Core.XUnitTest/*.csproj ./src/FV.PaymentCalculator.Core.XUnitTest/
RUN dotnet restore
COPY . .
WORKDIR /build/src/FV.PaymentCalculator.Core/
RUN dotnet build -c Release -o /app
WORKDIR /build/src/FV.PaymentCalculator.Facade/
RUN dotnet build -c Release -o /app
WORKDIR /build/src/FV.PaymentCalculator.Console/
RUN dotnet build -c Release -o /app
RUN dotnet publish -c Release -o out

# Build e restore da aplicacao
FROM build AS publish
RUN dotnet publish -c Release -o out

# Build da imagem
FROM publish AS final
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT ["dotnet", "FV.PaymentCalculator.Console.dll"]