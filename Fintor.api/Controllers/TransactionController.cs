using Application.DTOs.Accounts;
using Application.DTOs.Transactions;
using Application.Interfaces.UseCases.Transactions;
using Application.UseCases.Transactions;
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
        private readonly ICreateTransaction _createTransaction;
        private readonly IGetLatestTransactions _getLatestTransactions;
        public TransactionController(ICreateTransaction createTransaction, IGetLatestTransactions getLatestTransactions)
        {
            _createTransaction = createTransaction;
            _getLatestTransactions = getLatestTransactions;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateMovement([FromBody] CreateTransactionDTO createMovementDTO)
        {
            TransactionDTO transactionDto = await _createTransaction.ExecuteAsync(createMovementDTO);
            return Ok(transactionDto);
        }

        [HttpGet("get-latest")]
        [Authorize]
        public async Task<IActionResult> GetLatestTransactions()
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            List<TransactionDTO> transactionsDto = await _getLatestTransactions.ExecuteAsync(userId);
            return Ok(transactionsDto);
        }


    }
}
