﻿using ApiGestaoProdutos.Application.DTOs;
using ApiGestaoProdutos.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestaoProdutos.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsWithFilter([FromQuery] ProductFilterDTO product)
        {
            var products = await _productService.GetAllProductsWithFilterAsync(product);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDTO productDto)
        {
            await _productService.AddProductAsync(productDto);
            return CreatedAtAction(nameof(AddProduct), productDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
        {
            if (id != productDto.Id) return BadRequest();

            await _productService.UpdateProductAsync(productDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
