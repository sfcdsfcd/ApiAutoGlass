using ApiGestaoProdutos.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApiGestaoProdutos.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        public required bool Status { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodFornecedor { get; set; }
        public string? DescricaoFornecedor { get; set; }
        public string? CnpjFornecedor { get; set; }
    }
}
