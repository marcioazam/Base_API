using Application.Interfaces.Filters;

namespace Application.DTOs.Filters
{
    public class ProdutoFilterDTO : IFilter
    {
        public string? Nome { get; set; }
    }
}