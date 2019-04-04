using Inf.Booking.Domain.Model;
using System;
using System.Runtime.Serialization;

namespace Inf.Booking.Api.Application.Commands
{
    [DataContract]
    public class CreateBookingCommand : ICommand
    {
        [DataMember]
        public string PhoneNo { get; }

        [DataMember]
        public int CourtId { get; }

        [DataMember]
        public DateTime BookedFrom { get; }

        public CreateBookingCommand(string phoneNo, int courtId, DateTime bookedFrom)
        {
            PhoneNo = phoneNo;
            CourtId = courtId;
            BookedFrom = bookedFrom;
        }
    }
}
