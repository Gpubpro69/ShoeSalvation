using AutoMapper;
using ShoeSalvation.Domain.Entities;
using ShoeSalvation.Service.DTOs;

namespace ShoeSalvation.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.BrandName,
                opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : string.Empty))
            .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory != null ? src.SubCategory.Name : string.Empty))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty));
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>()
                .ForAllMembers(opt => opt.Condition((src, dest, val) => val != null));

            // Brand
            CreateMap<Brand, BrandDto>();
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<UpdateBrandDto, Brand>()
                .ForAllMembers(opt => opt.Condition((src, dest, val) => val != null));

            // Category
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>()
                .ForAllMembers(opt => opt.Condition((src, dest, val) => val != null));

            // SubCategory
            CreateMap<SubCategory, SubCategoryDto>().ForMember(dest=>dest.CategoryName,opt=>opt.MapFrom(src=>src.Category!=null?src.Category.Name:string.Empty));
            CreateMap<CreateSubCategoryDto, SubCategory>();
            CreateMap<UpdateSubCategoryDto, SubCategory>()
                .ForAllMembers(opt => opt.Condition((src, dest, val) => val != null));
        }
    }
}
