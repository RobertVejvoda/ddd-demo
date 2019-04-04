using System;
using System.Collections.Generic;
using System.Text;

namespace Inf.Booking.Infrastructure.Entities
{
    public class BookingEntity    
    {
        public int Id { get; set; }
        public string PhoneNo { get; set; }
        public DateTime BookedFrom { get; set; }
        public DateTime BookedTo { get; set; } 
        public int CourtId { get; set; }
        public int Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public CourtEntity Court { get; set; } 
    }
}
