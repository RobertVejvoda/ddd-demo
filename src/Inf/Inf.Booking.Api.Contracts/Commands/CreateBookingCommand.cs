using Inf.Core.Commands;
using System;
using System.Runtime.Serialization;

namespace Inf.Booking.Api.Contracts.Commands
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
