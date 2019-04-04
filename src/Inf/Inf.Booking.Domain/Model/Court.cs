namespace Inf.Booking.Domain.Model
{
    public class Court : DomainObject
    {
        public Court(int id, CourtType courtType)
        {
            Id = id;
            CourtType = courtType;
        }

        public CourtType CourtType { get; }
    }
}
