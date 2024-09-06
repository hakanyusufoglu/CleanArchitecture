using AutoMapper;
using CleanArchitecture.Application.Features.Categories.Create;
using CleanArchitecture.Application.Features.Categories.Dto;
using CleanArchitecture.Application.Features.Categories.Update;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Categories
{
    public class CategoryProfileMapping : Profile
    {
        public CategoryProfileMapping()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();

            CreateMap<Category, CategoryWithProductsDto>().ReverseMap();

            CreateMap<CreateCategoryRequest, Category>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));

            CreateMap<UpdateCategoryRequest, Category>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
        }
    }
}
