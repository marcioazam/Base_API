using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Address(string street, string city, string state, string zipCode)
    {
        public string Street { get; } = street;

        public string City { get; } = city;

        public string State { get; } = state;

        public string ZipCode { get; } = zipCode;

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, City, State, ZipCode);
        }
    }
}
