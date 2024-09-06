using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class DateRange(DateTime start, DateTime end)
    {
        public DateTime Start { get; } = start;

        public DateTime End { get; } = end;

        public bool Overlaps(DateRange other)
        {
            return Start < other.End && End > other.Start;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }
    }
}
