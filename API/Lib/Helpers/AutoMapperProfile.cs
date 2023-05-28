namespace Ecom_API.Helpers;

using AutoMapper;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // RegisterRequest -> User
        CreateMap<UserRegisterReq, User>();
        CreateMap<CategoryCreateReq, Category>();
        CreateMap<SubCategoryCreateReq, SubCategory>();
        CreateMap<BrandCreateReq, Brand>();
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