using BookingService.Booking.Application.Dates;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.Booking.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<ICurrentDateTimeProvider, DefaultCurrentDateTimeProvider>();
        return services;
    }
}