﻿namespace Ecom_API.Helpers;

using AutoMapper;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using global::DTO.DTO.Models.Request;

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
    }
}