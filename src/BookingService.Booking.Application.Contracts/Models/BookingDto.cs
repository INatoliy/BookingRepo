using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookingService.Booking.Application.Contracts.Models
{
    class BookingDto
    {
        public long Id { get; set; }
       // public BookingStatus Status { get; set; }
        public long UserId { get; set; }
        public long ResourceId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set;}
        public DateTimeOffset CreatedDate { get; set; }
    }
}
