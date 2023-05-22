using System;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;

namespace Ecom_API.Service;

public interface IUserService : IDisposable
{
    Task<AuthenticateRes> Authenticate(AuthenticateReq model);
    Task<AuthenticateRes> AuthenticateGoogle(string model);
    Task<IEnumerable<User>> GetAll();
    Task<User> GetByIdAsync(int id);
    User GetById(int id);
    Task<bool> Register(UserRegisterReq model);
    Task<bool> Update(UserUpdateReq model);
    Task<User> Delete(int id);
    Task<bool> UserVerification(string verificationCode);
}

