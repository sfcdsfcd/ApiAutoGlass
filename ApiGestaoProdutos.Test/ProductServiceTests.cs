using ApiGestaoProdutos.Application.DTOs;
using ApiGestaoProdutos.Application.Services;
using ApiGestaoProdutos.Domain.Entities;
using ApiGestaoProdutos.Domain.Interfaces;
using ApiGestaoProdutos.Infrastructure.Data;
using ApiGestaoProdutos.Infrastructure.Repositories;
using AutoMapper;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System;

namespace ApiGestaoProdutos.Test
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ProductService _productService;
        private readonly DbContextOptions<ProductDbContext> _options;
        public ProductServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _mapperMock = new Mock<IMapper>();
            _productService = new ProductService(_productRepositoryMock.Object,_mapperMock.Object);
            _options = new DbContextOptionsBuilder<ProductDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        }
        [Fact]
        public async Task GetProductByIdAsync_RetornarProdutoSeExistir()
        {
            var expectedProduct = new Product { Id = 1, Descricao = "Teste primeira inclusão" };

            _productRepositoryMock.Setup(x => x.GetByIdAsync(expectedProduct.Id))
            .ReturnsAsync(expectedProduct);

            _mapperMock.Setup(x => x.Map<ProductDto>(expectedProduct)).Returns(new ProductDto
            {
                Id = expectedProduct.Id,
                Descricao = expectedProduct.Descricao,
                Status = expectedProduct.Status,
            });

            var _productService = new ProductService(_productRepositoryMock.Object, _mapperMock.Object);

            var result = await _productService.GetProductByIdAsync(expectedProduct.Id);

            Assert.NotNull(result);
            Assert.Equal(expectedProduct.Id, result.Id);
            Assert.Equal(expectedProduct.Descricao, result.Descricao);
        }

        [Fact]
        public async Task DeleteProductAsync_SetarStatusComoFalse()
        {
            var productId = 1;
            var expectedProduct = new Product { Id = productId, Descricao = "Produto para exclusão" };

            _productRepositoryMock.Setup(x => x.GetByIdAsync(productId))
                .ReturnsAsync(expectedProduct);

            _productRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Product>()))
            .Returns(Task.CompletedTask)
            .Verifiable();

            _mapperMock.Setup(x => x.Map<ProductDto>(expectedProduct)).Returns(new ProductDto
            {
                Id = expectedProduct.Id,
                Descricao = expectedProduct.Descricao,
                Status = expectedProduct.Status,
            });

            var productservice = new ProductService(_productRepositoryMock.Object, _mapperMock.Object);

            // Act
            await productservice.DeleteProductAsync(productId);

            // Assert
            Assert.False(expectedProduct.Status);
            _productRepositoryMock.Verify(x => x.UpdateAsync(expectedProduct), Times.Once);
        }

        [Fact]
        public async Task AddProductAsync_AdicionarUmProduto()
        {
            var productDto = new AddProductDTO
            {
                Descricao = "Novo Produto",
                DataFabricacao = DateTime.Now.AddDays(-1),
                DataValidade = DateTime.Now.AddDays(1),
                Status = true
            };
            using (var context = new ProductDbContext(_options))
            {
                _mapperMock.Setup(x => x.Map<Product>(productDto)).Returns(new Product
                {
                    Descricao = productDto.Descricao,
                    Status = productDto.Status,
                    DataFabricacao = productDto.DataFabricacao,
                    DataValidade = productDto.DataValidade
                });

                var productService = new ProductService(new ProductRepository(context), _mapperMock.Object);

                // Act
                await productService.AddProductAsync(productDto);
            }
            
            using (var context = new ProductDbContext(_options))
            {
                var productInDb = await context.Products.FirstOrDefaultAsync(p => p.Descricao == "Novo Produto");
                Assert.NotNull(productInDb);
            }
        }
    }
}
