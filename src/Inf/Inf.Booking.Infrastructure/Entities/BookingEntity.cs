using System;
using System.Collections.Generic;
using System.Text;

namespace Inf.Booking.Infrastructure.Entities
{
    public class BookingEntity    
    {
        public int Id { get; set; }
        public string PhoneNo { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int CourtId { get; set; }
        public string BookedBy { get; set; }
        public DateTime DateBooked { get; set; }

        public CourtEntity Court { get; set; } 
    }
}
