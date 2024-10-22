using Application.Interfaces.Filters;

namespace Application.DTOs.Filters
{
    public class ClienteFilterDTO : IFilter
    {
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public char? Sexo { get; set; }

        public string? Endereço { get; set; }
    }
}
