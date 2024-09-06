using AutoMapper;
using CleanArchitecture.Application.Features.Products.Create;
using CleanArchitecture.Application.Features.Products.Dto;
using CleanArchitecture.Application.Features.Products.Update;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application
{
    public class ProducMappingProfile : Profile
    {
        public ProducMappingProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();

            CreateMap<CreateProductRequest, Product>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));

            CreateMap<UpdateProductRequest, Product>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
        }
    }
}
