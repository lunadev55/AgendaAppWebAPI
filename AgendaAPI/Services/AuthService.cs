using AgendaAPI.Helpers;
using AgendaAPI.Repositories.Interfaces;
using AgendaAPI.Services.Interfaces;
using AgendaAPI.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AgendaAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IAuthRepository authRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }
        public async Task<string> Login(LoginUserViewModel loginUser)
        {
            if (!Utils.IsValidEmailAddress(loginUser.Email))
                throw new ArgumentException("Invalid Email Address!");

            try
            {
                var result = await _authRepository.Login(loginUser);

                if (result.Succeeded)
                {
                    string token = _tokenService.CreateJwtToken(loginUser.Email);
                    return token;
                }
                throw new Exception("Error!\n Review your credentials or Try again later!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IdentityResult> Register(RegisterUserViewModel registerUser)
        {
            if (!Utils.IsValidEmailAddress(registerUser.Email))
                throw new ArgumentException("Invalid Email Address!");              

            try
            {
                var result = await _authRepository.Register(registerUser);
                return result;
            }        
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }
    }
}
