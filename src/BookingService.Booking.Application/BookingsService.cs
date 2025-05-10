using BookingService.Booking.Application.Contracts.Commands;
using BookingService.Booking.Application.Contracts.Exceptions;
using BookingService.Booking.Application.Contracts.Interfaces;
using BookingService.Booking.Application.Contracts.Models;
using BookingService.Booking.Application.Contracts.Queries;
using BookingService.Booking.Application.Dates;
using BookingService.Booking.Domain;
using BookingService.Booking.Domain.Bookings;
using BookingService.Booking.Domain.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Booking.Application;

internal class BookingsService : IBookingsService
{
    private readonly ICurrentDateTimeProvider _currentDateTimeProvider;
    private readonly IUnitOfWOrk _unitOfWOrk;

    public BookingsService(IUnitOfWOrk unitOfWOrk, ICurrentDateTimeProvider currentDateTimeProvider)
    {
        _unitOfWOrk = unitOfWOrk;
        _currentDateTimeProvider = currentDateTimeProvider;
    }
    public async Task<long> CreateBookingAsync(CreateBookingCommand command,
        CancellationToken cancellationToken = default)
    {
        var booking = BookingAggregate.Initialize(
            command.UserId,
            command.ResourceId,
            command.StartDate,
            command.EndDate,
            _currentDateTimeProvider.UtcNow);

        if (command.UserId <= 0) throw new ValidationException("UserId должен быть больше 0.");
        if (command.ResourceId <= 0) throw new ValidationException("ResourceId должен быть больше 0.");
        if (command.StartDate > command.EndDate) throw new ValidationException("Дата выезда не может быть раньше заезда");

        _unitOfWOrk.BookingRepository.Create(booking);
        await _unitOfWOrk.CommitAsync(cancellationToken);
        return booking.Id;
    }

    public async Task CancelBookingAsync(CancelBookingCommand command, CancellationToken cancellationToken = default)
    {
        var booking = await _unitOfWOrk.BookingRepository.GetById(command.BookingId);

        if (booking == null || booking.Id <= 0) throw new ValidationException("Не удалось найти бронирование.");

        _unitOfWOrk.BookingRepository.Update(booking);
        await _unitOfWOrk.CommitAsync(cancellationToken);
    }

    public async Task<BookingDto[]> GetByFilterAsync(GetBookingsByFilterQuery filterQuery, CancellationToken cancellationToken = default)
    {
        var query = _unitOfWOrk.BookingRepository.GetQueryable();

        if (filterQuery.Status.HasValue)
            query = query.Where(query => query.Status==filterQuery.Status);
        if(filterQuery.UserId.HasValue)
            query = query.Where(query => query.UserId == filterQuery.UserId);
        if(filterQuery.ResourceId.HasValue)
            query = query.Where(query => query.ResourceId == filterQuery.ResourceId);
        if(filterQuery.StartDate.HasValue)
            query = query.Where(query => query.StartDate >= filterQuery.StartDate);
        if(filterQuery.EndDate.HasValue)
            query = query.Where(query => query.EndDate <= filterQuery.EndDate);

        query = query.OrderBy(quary=>quary.Id).Skip(filterQuery.PageNumber).Take(filterQuery.PageSize);
        
        var booking = await query.ToListAsync();
        return booking.Select(booking => new BookingDto
            {
                Id = booking.Id,
                UserId = booking.UserId,
                ResourceId = booking.ResourceId,
                Status = booking.Status,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                CreatedAt = booking.CreatedAt
            }).ToArray();
    }

    public async Task<BookingStatus> GetStatusByIdAsync(GetBookingStatusByIdQuery idQuery, CancellationToken cancellationToken = default)
    {
        var booking = await _unitOfWOrk.BookingRepository.GetById(idQuery.BookingId) ?? throw new ValidationException("Бронирование не найдено.");
        return booking.Status;
    }
    public async Task<BookingDto> GetByIdAsync(GetBookingByIdQuery idQuery, CancellationToken cancellationToken = default)
    {
        var booking = await _unitOfWOrk.BookingRepository.GetById(idQuery.BookingId) ?? throw new ValidationException("Бронирование не найдено.");

        return new BookingDto
        {
            Id = booking.Id,
            Status = booking.Status,
            UserId = booking.UserId,
            ResourceId = booking.ResourceId,
            StartDate = booking.StartDate,
            EndDate = booking.EndDate,
            CreatedAt = booking.CreatedAt
        };
    }





}