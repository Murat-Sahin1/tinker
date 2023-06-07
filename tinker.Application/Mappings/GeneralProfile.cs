using AutoMapper;
using tinker.Application.DTOs.CategoryDtos;
using tinker.Application.DTOs.Common;
using tinker.Application.DTOs.ProductDtos;
using tinker.Application.DTOs.SellerDtos;
using tinker.Domain.Entities;

namespace tinker.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {
            //Source --> Target
            CreateMap<Product, ProductReadDto>();

            CreateMap<ProductCreateDto, Product>();

            CreateMap<Category, CategoryReadDto>();

            CreateMap<CategoryCreateDto, Category>();

            CreateMap<RefinedCategoryDto, Category>();
            CreateMap<Category, RefinedCategoryDto>();

            CreateMap<Product, Product>();

            CreateMap<Image, ImageDto>();

            CreateMap<ImageDto, Image>();

            CreateMap<Seller, SellerReadDto>();

            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
