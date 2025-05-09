using BookingService.Booking.Domain;
using BookingService.Booking.Domain.Bookings;

namespace BookingService.Booking.Persistence;

public class UnitOfWork : IUnitOfWOrk
{
    private readonly BookingsContext _dbContext;

    public UnitOfWork(BookingsContext dbContext, IBookingsRepository bookingRepository)
    {
        _dbContext = dbContext;
        BookingRepository = bookingRepository;
    }

    public IBookingsRepository BookingRepository { get; }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}