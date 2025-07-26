using Application.DTOs.Accounts;
using Application.Interfaces.UseCases.Accounts;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Fintor.api.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : Controller
    {
        private readonly ICreateAccount _createAccount;
        public AccountController(ICreateAccount createAccount) 
        { 
            _createAccount = createAccount;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateAccount(CreateAccountDTO createAccountDTO)
        {
            var authHeader = Request.Headers["Authorization"].FirstOrDefault();
            Console.WriteLine($"Authorization Header: {authHeader}");
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            Account account = await _createAccount.ExecuteAsync(createAccountDTO, userId);
            return Ok(account);
        }
    }
}
