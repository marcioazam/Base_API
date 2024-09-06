using Domain.EnumTypes.SMMOficialReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ExternalAPI.SMMOficialReserva
{
    public class OfferedServiceDTO(string? service, string? name, string? type, string? rate, string? min, string? max, bool dripfeed, bool refill, bool cancel, string? category)
    {
        public string? Service { get; set; } = service;

        public string? Name { get; set; } = name;

        public string? Type { get; set; } = type;

        public string? Rate { get; set; } = rate;

        public string? Min { get; set; } = min;

        public string? Max { get; set; } = max;

        public bool Dripfeed { get; set; } = dripfeed;

        public bool Refill { get; set; } = refill;

        public bool Cancel { get; set; } = cancel;

        public string? Category { get; set; } = category;
    }
}
