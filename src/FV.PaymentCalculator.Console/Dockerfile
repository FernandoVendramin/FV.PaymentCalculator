
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
RUN dotnet publish "FV.PaymentCalculator.Console.csproj" -c Release
RUN dotnet build "FV.PaymentCalculator.Console.csproj" -c Release

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS build-container
COPY bin/Release/net5.0/publish/ PaymentCalculator/
WORKDIR /PaymentCalculator
ENTRYPOINT ["dotnet", "FV.PaymentCalculator.Console.dll"]