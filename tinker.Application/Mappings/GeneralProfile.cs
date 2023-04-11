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
            CreateMap<Product, ProductReadDto>()
                .ForMember(dest => dest.Category,
                            opts => opts.MapFrom(src => src.Category));

            CreateMap<ProductCreateDto, Product>()
                .ForMember(dest => dest.Images,
                            opts => opts.MapFrom(src => 
                                src.Images.ToList()))
                .ForMember(dest => dest.CategoryId,
                            opts => opts.MapFrom(src =>
                                src.CategoryID));

            CreateMap<Category, CategoryReadDto>()
                .ForMember(dest => dest.Products,
                            opts => opts.MapFrom(src =>
                                src.Products.ToList()));

            CreateMap<CategoryCreateDto, Category>();

            CreateMap<Product, Product>();

            CreateMap<Image, ImageDto>();

            CreateMap<ImageDto, Image>();

            CreateMap<Seller, SellerReadDto>();

            CreateMap<Address, AddressDto>();
        }
    }
}
