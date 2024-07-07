using ApiGestaoProdutos.Domain.Entities;

namespace ApiGestaoProdutos.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product entity);
        Task UpdateAsync(Product entity);
        Task DeleteAsync(int id);
    }
}
