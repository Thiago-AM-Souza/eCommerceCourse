using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDTO request)
        {
            if (request == null)
            {
                return BadRequest("Invalid registration data");
            }

            AuthenticationResponseDTO? authenticationResponse = await _usersService.Register(request);

            if (authenticationResponse == null || !authenticationResponse.Success)
            {
                return BadRequest(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDTO request)
        {
            if (request == null)
            {
                return BadRequest("Invalid login data");
            }

            AuthenticationResponseDTO? authenticationResponse = await _usersService.Login(request);

            if (authenticationResponse != null && !authenticationResponse.Success)
            {
                return Unauthorized(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }
    }
}
