using ApiGestaoProdutos.Application.DTOs;

namespace ApiGestaoProdutos.Application.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<PagedResultDTO<ProductDto>> GetAllProductsWithFilterAsync(ProductFilterDTO product);
        Task AddProductAsync(AddProductDTO productDto);
        Task UpdateProductAsync(ProductDto productDto);
        Task DeleteProductAsync(int id);
    }
}
