using Application.DTOs.Accounts;
using Application.DTOs.Transactions;
using Application.Interfaces.UseCases.Transactions;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fintor.api.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : Controller
    {
        private readonly ICreateTransaction _createMovement;
        public TransactionController(ICreateTransaction createMovement)
        {
            _createMovement = createMovement;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDTO createMovementDTO)
        {
            TransactionDTO movementDto = await _createMovement.ExecuteAsync(createMovementDTO);
            return Ok(movementDto);
        }


    }
}
