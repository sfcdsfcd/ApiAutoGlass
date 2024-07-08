using ApiGestaoProdutos.Application.DTOs;
using ApiGestaoProdutos.Domain.Entities;
using AutoMapper;

namespace ApiGestaoProdutos.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, AddProductDTO>().ReverseMap();
        }
    }
}
