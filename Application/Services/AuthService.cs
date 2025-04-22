using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    namespace Application.Services
    {
        public class AuthService : IAuthService
        {
            private readonly IAuthRepository _authRepo;
            public AuthService(IAuthRepository authRepo)
            {
                _authRepo = authRepo;
            }

            public async Task<string> RegisterAsync(RegisterUserDto model)
            {
                // Map DTO to domain object
                var registerUser = new RegisterUser
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Password = model.Password,
                    DepartmentId = model.DepartmentId
                };
                return await _authRepo.RegisterAsync(registerUser);
            }

            public async Task<string> LoginAsync(UserLoginDto model)
            {
                var userLogin = new UserLogin
                {
                    Email = model.Email,
                    Password = model.Password
                };
                return await _authRepo.LoginAsync(userLogin);
            }

            public async Task<string> LogoutAsync()
            {
                return await _authRepo.LogoutAsync();
            }
        }
    }
}
