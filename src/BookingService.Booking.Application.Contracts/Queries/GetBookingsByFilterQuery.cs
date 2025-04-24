using BookingService.Booking.Domain.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Booking.Application.Contracts.Queries
{
    public class GetBookingsByFilterQuery
    {
        public BookingStatus? Status { get; set; }
        public long? UserId { get; set; }
        public long? ResourceId { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }


        public int? PageSize { get; set; } = 10;
        public int? PageNumber { get; set; } = 1;
    }
}
