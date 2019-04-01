using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inf.Booking.Api.Infrastructure
{
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

        public DateTime From { get; }
        public DateTime To { get; }

        public double Minutes => (To - From).TotalMinutes;
    }
}
