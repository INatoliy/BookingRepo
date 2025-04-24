using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using BookingService.Booking.Application.Contracts.Interfaces;
using BookingService.Booking.Application.Dates;

namespace BookingService.Booking.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IBookingsService, BookingsService>();
            services.AddSingleton<ICurrentDateTimeProvider, DefaultCurrentDateTimeProvider>();
            return services;
        }
    }
}

