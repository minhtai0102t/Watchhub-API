using System;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;

namespace Ecom_API.Service;

public interface IUserService : IDisposable
{
    Task<AuthenticateRes> Authenticate(AuthenticateReq model);
    Task<AuthenticateRes> LoginWithGoogle(GoogleUser req);
    Task<IEnumerable<User>> GetAll();
    Task<User> GetByIdAsync(int id);
    User GetById(int id);
    Task<bool> Register(UserRegisterReq model);
    Task<UpdateRes> Update(UserUpdateReq model, int id);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
    Task<bool> UserVerification(string code, string id);
}

