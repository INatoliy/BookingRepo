#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/BookingService.Booking.Api/BookingService.Booking.Api.csproj", "src/BookingService.Booking.Api/"]
COPY ["src/BookingService.Booking.Api.Contracts/BookingService.Booking.Api.Contracts.csproj", "src/BookingService.Booking.Api.Contracts/"]
COPY ["src/BookingService.Booking.Application.Contracts/BookingService.Booking.Application.Contracts.csproj", "src/BookingService.Booking.Application.Contracts/"]
COPY ["src/BookingService.Booking.Application/BookingService.Booking.Application.csproj", "src/BookingService.Booking.Application/"]
COPY ["src/BookingService.Booking.Domain/BookingService.Booking.Domain.csproj", "src/BookingService.Booking.Domain/"]
COPY ["src/BookingService.Booking.Domain.Contracts/BookingService.Booking.Domain.Contracts.csproj", "src/BookingService.Booking.Domain.Contracts/"]
RUN dotnet restore "./src/BookingService.Booking.Api/BookingService.Booking.Api.csproj"
COPY . .
WORKDIR "/src/src/BookingService.Booking.Api"
RUN dotnet build "./BookingService.Booking.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BookingService.Booking.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingService.Booking.Api.dll"]