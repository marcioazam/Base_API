using Application.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Filters
{
    public class SupplierFilterDTO() : IFilter
    {
        public string? ApiUrl { get; set; }

        public string? Nome { get; set; } 

        public string? ApiKey { get; set; } 
    }
}
