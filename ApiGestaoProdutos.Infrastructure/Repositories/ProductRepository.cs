using ApiGestaoProdutos.Application.DTOs;
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
        public async Task<(IEnumerable<Product>,int)> GetAllWithFilterAsync(string Descricao, bool? Status,
         DateTime? InicioDataFabricacao,
         DateTime? FimDataFabricacao,
         DateTime? InicioDataValidade,
         DateTime? FimDataValidadeMax,
         int? CodFornecedor,
         int PageNumber,
         int PageSize)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(Descricao))
            {
                query = query.Where(p => p.Descricao.Contains(Descricao));
            }

            if (Status.HasValue)
            {
                query = query.Where(p => p.Status == Status.Value);
            }

            if (InicioDataFabricacao.HasValue)
            {
                query = query.Where(p => p.DataFabricacao >= InicioDataFabricacao.Value);
            }

            if (FimDataFabricacao.HasValue)
            {
                query = query.Where(p => p.DataFabricacao <= FimDataFabricacao.Value);
            }

            if (InicioDataValidade.HasValue)
            {
                query = query.Where(p => p.DataValidade >= InicioDataValidade.Value);
            }

            if (FimDataValidadeMax.HasValue)
            {
                query = query.Where(p => p.DataValidade <= FimDataValidadeMax.Value);
            }

            if (CodFornecedor.HasValue)
            {
                query = query.Where(p => p.CodFornecedor == CodFornecedor.Value);
            }
            var totalRecords = await query.CountAsync();

            var products = await query
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            return (products, totalRecords);
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
