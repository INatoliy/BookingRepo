using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Booking.Domain.Contracts.Models
{
    public enum BookingStatus
    {
        AwaitsConfirmation,  // Ожидает подтверждения
        Confirmed,           // Подтверждено 
        Cancelled            // Отменено 
    }
}
