using ApiGestaoProdutos.Application.DTOs;
using ApiGestaoProdutos.Domain.Entities;
using ApiGestaoProdutos.Domain.Enums;
using ApiGestaoProdutos.Domain.Interfaces;
using AutoMapper;


namespace ApiGestaoProdutos.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
        public async Task<PagedResultDTO<ProductDto>> GetAllProductsWithFilterAsync(ProductFilterDTO product)
        {

            var products = await _repository.GetAllWithFilterAsync(product.Descricao, product.Status, product.InicioDataFabricacao, product.FimDataFabricacao, product.InicioDataValidade, product.FimDataValidadeMax, product.CodFornecedor, product.PageNumber,product.PageSize);

            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products.Item1);
            return new PagedResultDTO<ProductDto>
            {
                Items = productDtos,
                PageSize = product.PageSize,
                PageNumber = product.PageNumber,
                TotalRecords = products.Item2
            };
        }

        public async Task AddProductAsync(AddProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            if (product.DataFabricacao >= product.DataValidade)
                throw new ArgumentException("A data de fabricação não pode ser maior ou igual à data de validade.");
            
            await _repository.AddAsync(product);
        }

        public async Task UpdateProductAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            if (await GetProductByIdAsync(product.Id) is null)
                throw new ArgumentException("Produto Não Encontrado");

            if (product.DataFabricacao >= product.DataValidade)
                throw new ArgumentException("A data de fabricação não pode ser maior ou igual à data de validade.");

            await _repository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) throw new KeyNotFoundException("Produto não encontrado.");

            product.Status = false;
            await _repository.UpdateAsync(product);
        }
    }
}
