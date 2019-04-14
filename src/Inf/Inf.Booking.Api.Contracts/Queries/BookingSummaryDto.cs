using System;
using System.Runtime.Serialization;

namespace Inf.Booking.Api.Contracts.Queries
{
    [DataContract]
    public class BookingSummaryDto
    {
        public int BookingId { get; set; }
        public string PhoneNo { get; set; }
        public DateTime BookedFrom { get; set; }
        public DateTime BookedTo { get; set; }
        public int CourtId { get; set; }
        public int CourtTypeId { get; set; }
        public string CourtType { get; set; }
        public int BookingStatusId { get; set; }
        public string BookingStatus { get; set; }
    }
}
