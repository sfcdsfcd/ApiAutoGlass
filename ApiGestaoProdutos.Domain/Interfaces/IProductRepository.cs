using ApiGestaoProdutos.Domain.Entities;
namespace ApiGestaoProdutos.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<(IEnumerable<Product>,int)> GetAllWithFilterAsync(string Descricao, bool? Status,
         DateTime? InicioDataFabricacao,
         DateTime? FimDataFabricacao,
         DateTime? InicioDataValidade,
         DateTime? FimDataValidadeMax,
         int? CodFornecedor,
         int PageNumber,
         int PageSize);
        Task AddAsync(Product entity);
        Task UpdateAsync(Product entity);
        Task DeleteAsync(int id);
    }
}
