using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inf.Booking.Api.Application.Commands
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
