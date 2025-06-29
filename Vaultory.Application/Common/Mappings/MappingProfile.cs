using AutoMapper;
using Vaultory.Application.Categories;
using Vaultory.Application.Locations;
using Vaultory.Application.Products.Dtos;
using Vaultory.Domain.Entities;

namespace Vaultory.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<Location, LocationDto>();
    }
}