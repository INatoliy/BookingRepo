using BookingService.Booking.Application.Contracts.Commands;
using BookingService.Booking.Application.Contracts.Models;
using BookingService.Booking.Application.Contracts.Queries;
using BookingService.Booking.Domain.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Booking.Application.Contracts.Interfaces
{
    public interface IBookingsService
    {
        Task<long> CreateBookingAsync(CreateBookingCommand command);
        Task<BookingDto> GetByIdAsync(GetBookingByIdQuery idQuery);
        Task CancelBookingAsync(CancelBookingCommand command);
        Task<BookingDto[]> GetByFilterAsync(GetBookingsByFilterQuery filterQuery);
        Task<BookingStatus> GetStatusByIdAsync(GetBookingStatusByIdQuery idQuery);

    }
}
