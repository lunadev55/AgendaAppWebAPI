using AgendaAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace AgendaAPI.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<IdentityResult> Register(RegisterUserViewModel registerUser);
        Task<SignInResult> Login(LoginUserViewModel loginUser);
    }
}
