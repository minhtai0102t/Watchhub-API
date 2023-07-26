namespace Ecom_API.Helpers;
using AutoMapper;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using global::DTO.DTO.Models;
using global::DTO.DTO.Models.Request;
using global::DTO.DTO.Models.Response;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // RegisterRequest -> User
        CreateMap<UserRegisterReq, User>();
        CreateMap<CategoryCreateReq, Category>();
        CreateMap<SubCategoryCreateReq, SubCategory>();
        CreateMap<BrandCreateReq, Brand>();
        CreateMap<ProductAlbertCreateReq, ProductAlbert>();
        CreateMap<ProductCoreCreateReq, ProductCore>();
        CreateMap<ProductGlassCreateReq, ProductGlass>();
        CreateMap<ProductTypeCreateReq, ProductType>();
        CreateMap<ProductTypeUpdateReq, ProductType>();
        CreateMap<ProductCreateReq, Product>();
        CreateMap<PaymentMethodCreateReq, PaymentMethod>();
        CreateMap<PaymentResponse, VNPay>();
        CreateMap<OrderCreateReq, Order>();
        // GoogleUser -> User
        CreateMap<GoogleUser, User>().ReverseMap();
        // UpdateRequest -> User
        CreateMap<UserUpdateReq, User>()

            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
        #region ProductTypeFullRes mapper
        CreateMap<SubCategory, SubCategoryMapperShort>();
        CreateMap<Brand, BrandMapper>();
        CreateMap<ProductAlbert, AlbertMapper>();
        CreateMap<ProductCore, CoreMapper>();
        CreateMap<ProductGlass, GlassMapper>();
        CreateMap<Product, ProductMapper>();
        CreateMap<ProductSubCategory, ProductSubCategoryMapper>()
            .ForMember(opt => opt.sub_category_name, des => des.MapFrom(x => x.subCategory.sub_category_name))
            .ForMember(opt => opt.category_id, des => des.MapFrom(x => x.subCategory.category_id));
        CreateMap<ProductFeedback, ProductFeedbackMapper>()
            .ForMember(opt => opt.rating, des => des.MapFrom(x => x.rating));
        CreateMap<ProductType, ProductTypeFullRes>()
            .ForMember(opt => opt.products, des => des.MapFrom(x => x.products))
            .ForMember(opt => opt.productSubCategories, des => des.MapFrom(x => x.productSubCategories))
            .ForMember(opt => opt.productFeedbacks, des => des.MapFrom(x => x.productFeedbacks));

        CreateMap<User, UserMapper>();
        CreateMap<ProductFeedback, ProductFeedbackFullRes>()
            .ForMember(opt => opt.User, des => des.MapFrom(x => x.User));

        CreateMap<VNPay, VNPayMapper>();
        CreateMap<Order, OrderFullRes>()
            .ForMember(opt => opt.vnpay, des => des.MapFrom(x => x.vnpay));

        #endregion

        CreateMap<StoreVnPayCreateReq, VNPay>();
        CreateMap<Category, CategoryFullRes>()
            .ForMember(opt => opt.subCategories, des => des.MapFrom(x => x.subCategories));
        CreateMap<ProductFeedbackCreateReq, ProductFeedback>();
    }
}