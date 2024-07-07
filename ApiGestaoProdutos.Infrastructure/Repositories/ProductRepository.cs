using ApiGestaoProdutos.Domain.Entities;
using ApiGestaoProdutos.Domain.Interfaces;
using ApiGestaoProdutos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoProdutos.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Product>();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(Product entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
