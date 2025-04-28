namespace BookingService.Booking.Application.Dates;
class DefaultCurrentDateTimeProvider : ICurrentDateTimeProvider
{
    public DateTimeOffset LocalNow => DateTimeOffset.Now.ToLocalTime();
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}