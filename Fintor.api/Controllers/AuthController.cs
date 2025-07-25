using Application.DTOs.Auth;
using Application.DTOs.Users;
using Application.Interfaces.UseCases.Auth;
using Application.Interfaces.UseCases.Users;
using Microsoft.AspNetCore.Mvc;

namespace Fintor.api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly ISignIn _signIn;

        public AuthController(ISignIn signIn)
        {
            _signIn = signIn;
        }
        [HttpPost("sign-in")]
        public async Task<SignInResponseDTO> SignIn(SignInDTO signInDTO)
        {
            SignInResponseDTO response = await _signIn.Execute(signInDTO);
            return response;
        }
    }
}
