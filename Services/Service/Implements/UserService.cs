using AutoMapper;
using Ecom_API.Authorization;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.Helpers;
using Isopoh.Cryptography.Argon2;
using Services.Repositories;

namespace Ecom_API.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IJwtUtils _jwtUtils;
        private bool disposedValue;
        private readonly IMapper _mapper;
        public UserService(
            IJwtUtils jwtUtils,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }
        public async Task<AuthenticateRes> Authenticate(AuthenticateReq model)
        {
            try
            {
                var user = await _unitOfWork.Users.FindWithCondition(c => c.email == model.email);
                // validate
                if (user == null || !Argon2.Verify(user.password, model.password))
                    throw new AppException("email or password is incorrect");
                // authentication successful
                var response = _jwtUtils.GenerateToken(user).ToString();
                return new AuthenticateRes {
                    token = response
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _unitOfWork.Users.GetAllAsync();
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

                GmailHelper.SendVerificationEmail(model.email, model.email);
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
        public async Task<bool> UserVerification(string code)
        {
            var user = await _unitOfWork.Users.FindWithCondition(c => c.email == code);
            if (user != null)
            {
                // verification success
                GmailHelper.SendLoginEmail(code);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(UserUpdateReq model)
        {
            // validate
            var isExisted = await _unitOfWork.Users.FindWithCondition(c => c.username == model.username);
            if (isExisted != null)
                throw new AppException("username '" + model.username + "' is already taken");

            var user = _mapper.Map<User>(model);
            // hash password before store to DB
            if (!string.IsNullOrEmpty(model.password))
                user.password = Argon2.Hash(model.password);
            var res = await _unitOfWork.Users.UpdateAsync(user);
            return res >= 1 ? true : false;
        }

        public async Task<User> Delete(int id)
        {
            return await _unitOfWork.Users.DeleteSoftAsync(id);
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

