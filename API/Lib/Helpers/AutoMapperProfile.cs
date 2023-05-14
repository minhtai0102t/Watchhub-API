namespace Ecom_API.Helpers;

using AutoMapper;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // User -> AuthenticateResponse
        CreateMap<User, AuthenticateRes>().ReverseMap();

        // RegisterRequest -> User
        CreateMap<UserRegisterReq, User>();

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