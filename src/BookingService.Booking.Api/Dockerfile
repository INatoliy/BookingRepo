FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80 
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BookingService.Booking.Api/BookingService.Booking.Api.csproj", "BookingService.Booking.Api/"]
COPY ["BookingService.Booking.Api.Contracts/BookingService.Booking.Api.Contracts.csproj", "BookingService.Booking.Api.Contracts/"]
COPY ["BookingService.Booking.Application.Contracts/BookingService.Booking.Application.Contracts.csproj", "BookingService.Booking.Application.Contracts/"]
COPY ["BookingService.Booking.Application/BookingService.Booking.Application.csproj", "BookingService.Booking.Application/"]
COPY ["BookingService.Booking.Domain/BookingService.Booking.Domain.csproj", "BookingService.Booking.Domain/"]
COPY ["BookingService.Booking.Domain.Contracts/BookingService.Booking.Domain.Contracts.csproj", "BookingService.Booking.Domain.Contracts/"]
COPY ["BookingService.Booking.Domain.Contracts/BookingService.Booking.Persistence.csproj", "BookingService.Booking.Persistence/"]
RUN dotnet restore "BookingService.Booking.Api/BookingService.Booking.Api.csproj"
COPY . .
WORKDIR "/src/BookingService.Booking.Api"
RUN dotnet build "BookingService.Booking.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BookingService.Booking.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingService.Booking.Api.dll"]