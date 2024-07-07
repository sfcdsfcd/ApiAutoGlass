using ApiGestaoProdutos.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApiGestaoProdutos.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        public StatusProdutoEnum Status { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        [StringLength(14)]
        public string CnpjFornecedor { get; set; }
    }
}
