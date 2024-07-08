using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGestaoProdutos.Application.DTOs
{
    public class ProductFilterDTO
    {
        public string? Descricao { get; set; }
        public bool? Status { get; set; }
        public DateTime? InicioDataFabricacao { get; set; }
        public DateTime? FimDataFabricacao { get; set; }
        public DateTime? InicioDataValidade { get; set; }
        public DateTime? FimDataValidadeMax { get; set; }
        public int? CodFornecedor { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
