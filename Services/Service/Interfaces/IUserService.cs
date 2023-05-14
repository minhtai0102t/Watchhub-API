using System;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;

namespace Ecom_API.Service;

public interface IUserService : IDisposable
{
    Task<AuthenticateRes> Authenticate(AuthenticateReq model);
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(Guid id);
    Task<bool> Register(UserRegisterReq model);
    Task<bool> Update(UserUpdateReq model);
    Task<User> Delete(Guid id);
}

