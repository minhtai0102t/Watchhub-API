using AutoMapper;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.Helpers;
using Ecom_API.PagingModel;
using Isopoh.Cryptography.Argon2;
using Microsoft.Extensions.Caching.Memory;
using Services.Repositories;

namespace Ecom_API.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IJwtUtils _jwtUtils;
        private bool disposedValue;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public UserService(
            IJwtUtils jwtUtils,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<AuthenticateRes> Authenticate(AuthenticateReq model)
        {
            try
            {
                var user = await _unitOfWork.Users.FindWithCondition(c => c.email == model.email);
                // validate
                if (user == null || !Argon2.Verify(user.password, model.password))
                    throw new AppException("email or password is incorrect");
                if (!user.is_verified)
                {
                    throw new AppException("user is not verified");
                }
                // authentication successful
                var response = _jwtUtils.GenerateToken(user).ToString();
                return new AuthenticateRes
                {
                    token = response
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<AuthenticateRes> LoginWithGoogle(GoogleUser req)
        {
            try
            {
                var user = await _unitOfWork.Users.FindWithCondition(c => c.email == req.email);
                if (user == null)
                {
                    var newUser = new User
                    {
                        fullname = req.name,
                        email = req.email,
                        password = Argon2.Hash(req.uid),
                        avatar = req.picture,
                        phone = req.phone,
                    };
                    await _unitOfWork.Users.CreateAsync(newUser);
                    await _unitOfWork.SaveChangesAsync();
                    return new AuthenticateRes
                    {
                        token = _jwtUtils.GenerateToken(newUser).ToString()
                    };
                }
                return new AuthenticateRes
                {
                    token = _jwtUtils.GenerateToken(user).ToString()
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PagedList<User>> GetAll(QueryStringParameters query)
        {
            return await _unitOfWork.Users.GetAllWithPaging(query);
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }
        public User GetById(int id)
        {
            return _unitOfWork.Users.GetById(id);
        }
        public async Task<bool> Register(UserRegisterReq model)
        {
            try
            {
                var validate = await _unitOfWork.Users.FindWithCondition(c => c.email == model.email);
                if (validate != null)
                    throw new AppException("email '" + model.email + "' is already existed in system");

                string verificationCode = GenerateVerificationCode();
                _cache.Set(model.email, verificationCode, TimeSpan.FromMinutes(10));

                GmailHelper.SendVerificationEmail(model.email, verificationCode);
                // map model to new user object
                var user = _mapper.Map<User>(model);
                // hash password
                user.password = Argon2.Hash(model.password);
                // save user
                await _unitOfWork.Users.CreateAsync(user);
                var res = await _unitOfWork.SaveChangesAsync();
                return res >= 1 ? true : false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<bool> UserVerification(string code, string email)
        {
            if (_cache.TryGetValue(email, out string storedCode))
            {
                if (code == storedCode)
                {
                    // Update isVerify = true
                    var user = await _unitOfWork.Users.FindWithCondition(c => c.email == email);
                    user.is_verified = true;
                    await _unitOfWork.Users.UpdateAsync(user);
                    var res = await _unitOfWork.SaveChangesAsync();
                    return res >= 1 ? true : false;
                }
            }
            return false;
        }
        public async Task<UpdateRes> Update(UserUpdateReq model, int id)
        {
            // validate
            var isExisted = await _unitOfWork.Users.GetByIdAsync(id);
            if (isExisted == null)
                throw new AppException("user " + id + " does not exist");
            isExisted.avatar = model.avatar;
            isExisted.address = model.address;
            isExisted.phone = model.phone;
            isExisted.username = model.username;
            isExisted.fullname = model.fullname;
            isExisted.updated_date = DateTime.Now.ToUniversalTime();
            await _unitOfWork.Users.UpdateAsync(isExisted);
            var res = await _unitOfWork.SaveChangesAsync();
            if (res == 1)
            {
                return new UpdateRes
                {
                    message = "Update successfully",
                    token = _jwtUtils.GenerateToken(isExisted)
                };
            }
            return new UpdateRes
            {
                message = "Update fail",
                token = ""
            };
        }

        public async Task<bool> SoftDelete(int id)
        {
            await _unitOfWork.Users.SoftDeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.Users.DeleteAsync(id);
            var res = await _unitOfWork.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
        private string GenerateVerificationCode()
        {
            // Generate a random verification code (you can replace this with your own code generation logic)
            Random random = new Random();
            int verificationCode = random.Next(100000, 999999);

            return verificationCode.ToString();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~UserService()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

