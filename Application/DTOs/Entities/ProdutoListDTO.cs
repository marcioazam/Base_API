using Application.Interfaces.DTOs;

namespace Application.DTOs.Entities
{
    public class ProdutoListDTO(long id, string nome) : IEntityDTO
    {
        public long Id { get; set; } = id;

        public string Nome { get; set; } = nome;
    }
}
