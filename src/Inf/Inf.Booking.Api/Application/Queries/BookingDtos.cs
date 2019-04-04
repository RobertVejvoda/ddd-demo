using Inf.Booking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inf.Booking.Api.Application.Queries
{
    public class BookingSummaryDto
    {
        public int BookingId { get; set; }
        public string PhoneNo { get; set; }
        public DateTime BookedFrom { get; set; }
        public DateTime BookedTo { get; set; }
        public int CourtId { get; set; }
        public CourtType CourtType { get; set; } 
        public BookingStatus Status { get; set; }
    }

    public class BookingDetailDto
    {
        public int BookingId { get; set; }
        public string PhoneNo { get; set; }
        public DateTime BookedFrom { get; set; }
        public DateTime BookedTo { get; set; }
        public int CourtId { get; set; }
        public CourtType CourtType { get; set; }
        public BookingStatus Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
