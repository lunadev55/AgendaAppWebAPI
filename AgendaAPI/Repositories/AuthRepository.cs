using AgendaAPI.Repositories.Interfaces;
using AgendaAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace AgendaAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public async Task<SignInResult> Login(LoginUserViewModel loginUser)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }     
        }

        public async Task<IdentityResult> Register(RegisterUserViewModel registerUser)
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = registerUser.Email,
                    Email = registerUser.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, registerUser.Password);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
