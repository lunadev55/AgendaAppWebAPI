using AgendaAPI.Services.Interfaces;
using AgendaAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager; 
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthController(SignInManager<IdentityUser> singInManager, 
                                UserManager<IdentityUser> userManager,
                                ITokenService tokenService)
        {
            _signInManager = singInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<IdentityUser>> Registrar(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(user);
        }

        [HttpPost("entrar")]
        public async Task<ActionResult<string>> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
                      
            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                string token = _tokenService.CreateJwtToken(loginUser.Email);
                return Ok(token);
            }

            return BadRequest("Invalid Username or Password!");
        }     

        [HttpPost("sair")]
        public async Task<ActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
