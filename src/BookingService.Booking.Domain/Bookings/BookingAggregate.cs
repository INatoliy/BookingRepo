using BookingService.Booking.Domain.Contracts.Models;
using BookingService.Booking.Domain.Contracts.Exceptions;


namespace BookingService.Booking.Domain.Bookings;
public class BookingAggregate
{
    public long Id { get; }
    public BookingStatus Status { get; private set; }
    public long UserId { get; set; }
    public long ResourceId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    private BookingAggregate(long userId, long resourceId, DateOnly startDate, DateOnly endDate, DateTimeOffset now)
    {
        Status = BookingStatus.AwaitsConfirmation;
        UserId = userId;
        ResourceId = resourceId;
        StartDate = startDate;
        EndDate = endDate;
        CreatedAt = now;
    }

    public static BookingAggregate Initialize(long userId, long resourceId, DateOnly startDate, DateOnly endDate, DateTimeOffset now)
    {
        if (userId <= 0) throw new DomainException("Индетификатор пользовотеля должен быть больше 0.");
        if (resourceId <= 0) throw new DomainException("Индетификатор ресурса должен быть больше 0.");
        if (startDate >= endDate) throw new DomainException("Дата начала бронирования не может быть до даты конца.");
    
        return new BookingAggregate(userId, resourceId, startDate, endDate, now);
    }

    public void Confirm()
    {
        if (Status != BookingStatus.AwaitsConfirmation) throw new DomainException("Подтвердить можно только ожидающее бронирование.");
        Status = BookingStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status == BookingStatus.Cancelled) throw new DomainException("Бронирование уже отменено");
        Status = BookingStatus.Cancelled;
    }
}