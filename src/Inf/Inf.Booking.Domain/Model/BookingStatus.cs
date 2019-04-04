using System.Runtime.Serialization;

namespace Inf.Booking.Domain.Model
{
    [DataContract]
    public enum BookingStatus
    {
        [EnumMember]
        Active = 1,

        [EnumMember]
        Cancelled = 2
    }
}
