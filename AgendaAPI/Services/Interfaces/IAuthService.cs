using AgendaAPI.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AgendaAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(RegisterUserViewModel registerUser);
        Task<string> Login(LoginUserViewModel loginUser);

    }
}
