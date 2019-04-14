using Inf.Core.Commands;
using System.Runtime.Serialization;

namespace Inf.Booking.Api.Contracts.Commands
{
    [DataContract]
    public class CancelBookingCommand : ICommand
    {
        [DataMember]
        public int BookingId { get; }

        public CancelBookingCommand(int bookingId)
        {
            BookingId = bookingId;
        }
    }
}
