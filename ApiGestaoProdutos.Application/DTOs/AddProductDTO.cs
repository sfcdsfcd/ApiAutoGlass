using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGestaoProdutos.Application.DTOs
{
    public class AddProductDTO
    {
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
