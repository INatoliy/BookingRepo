using BookingService.Booking.Domain.Contracts.Models;

namespace BookingService.Booking.Domain.Bookings;

public interface IBookingsRepository
{
    void Create(BookingAggregate aggregate);
    ValueTask<BookingAggregate?> GetById(long id, CancellationToken cancellationToken = default);
    void Update(BookingAggregate aggregate);
    IQueryable<BookingAggregate> GetQueryable();
}