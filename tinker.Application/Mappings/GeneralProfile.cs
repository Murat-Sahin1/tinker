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

            CreateMap<Category, CategoryReadDto>()
                .ForMember(dest => dest.Products,
                            opts => opts.MapFrom(src =>
                                src.Products.ToList()));

            CreateMap<Image, ImageDto>();

            CreateMap<Seller, SellerReadDto>();

            CreateMap<Address, AddressDto>();
        }
    }
}
