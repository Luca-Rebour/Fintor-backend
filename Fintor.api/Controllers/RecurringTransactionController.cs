using Application.DTOs.Transactions;
using Application.DTOs.RecurringTransactions;
using Application.Interfaces.UseCases.Transactions;
using Application.Interfaces.UseCases.RecurringTransactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.UseCases.RecurringTransactions;

namespace Fintor.api.Controllers
{
    [ApiController]
    [Route("api/recurring-transactions")]
    public class RecurringTransactionController : Controller
    {
        private readonly ICreateRecurringTransaction _createRecurringTransaction;
        public RecurringTransactionController(ICreateRecurringTransaction createRecurringTransaction)
        {
            _createRecurringTransaction = createRecurringTransaction;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateRecurringMovement([FromBody] CreateRecurringTransactionDTO createRecurringMovementDTO)
        {
            RecurringTransactionDTO recurringMovementDTO = await _createRecurringTransaction.ExecuteAsync(createRecurringMovementDTO);
            return Ok(recurringMovementDTO);
        }
    }
}
