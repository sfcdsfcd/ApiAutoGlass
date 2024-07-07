using ApiGestaoProdutos.Domain.Enums;

namespace ApiGestaoProdutos.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public StatusProdutoEnum Status { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
