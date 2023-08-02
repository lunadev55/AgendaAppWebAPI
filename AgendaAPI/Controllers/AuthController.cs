using AgendaAPI.Services.Interfaces;
using AgendaAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {       
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {                        
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            try
            {               
                var result = await _authService.Register(registerUser);

                if (!result.Succeeded)
                    return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            

            return Ok("Success");
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));         

            try
            {
                var token = await _authService.Login(loginUser);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }     
       
    }
}
