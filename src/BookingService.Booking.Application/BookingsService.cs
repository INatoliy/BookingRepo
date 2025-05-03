using BookingService.Booking.Application.Contracts.Commands;
using BookingService.Booking.Application.Contracts.Exceptions;
using BookingService.Booking.Application.Contracts.Interfaces;
using BookingService.Booking.Application.Contracts.Models;
using BookingService.Booking.Application.Contracts.Queries;
using BookingService.Booking.Application.Dates;
using BookingService.Booking.Domain.Bookings;
using BookingService.Booking.Domain.Contracts.Exceptions;
using BookingService.Booking.Domain.Contracts.Models;

namespace BookingService.Booking.Application;
 class BookingsService : IBookingsService
{
    private readonly ICurrentDateTimeProvider _currentDateTimeProvider;
    public Task<long> CreateBookingAsync(CreateBookingCommand command)
    {
        if (command.UserId <= 0 || command.ResourceId <= 0)
            throw new ValidationException("UserId и ResourceId должны быть больше 0.");

        var now = _currentDateTimeProvider.UtcNow;
        var bookingAggregate = BookingAggregate.Initialize(
            command.UserId, command.ResourceId, command.StartDate, command.EndDate, now);
        
        // Имитация работы
        var bookingId = new Random().NextInt64(1000);
        return Task.FromResult(bookingId);
    }

    public Task<BookingDto> GetByIdAsync(GetBookingByIdQuery idQuery)
    {
        throw new NotImplementedException();
    }

    public Task CancelBookingAsync(CancelBookingCommand command)
    {
        if (command.BookingId <= 0)
            throw new DomainException("Некорректный идентификатор бронирования");
        
        return null;
    }

    public Task<BookingDto[]> GetByFilterAsync(GetBookingsByFilterQuery filterQuery)
    {
        throw new NotImplementedException();
    }

    public Task<BookingStatus> GetStatusByIdAsync(GetBookingStatusByIdQuery idQuery)
    {
        throw new NotImplementedException();
    }
}