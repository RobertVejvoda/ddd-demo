using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Inf.Booking.Api.Infrastructure
{
    [DataContract]
    public class DateRange
    {
        public DateRange(DateTime from, DateTime to)
        {
            if (from >= to)
            {
                throw new ArgumentException("Neplatný rozsah datumů.");
            }

            From = from;
            To = to;
        }

        [DataMember]
        public DateTime From { get; private set; }

        [DataMember]
        public DateTime To { get; private set; }

        public double Minutes => (To - From).TotalMinutes;
    }
}
