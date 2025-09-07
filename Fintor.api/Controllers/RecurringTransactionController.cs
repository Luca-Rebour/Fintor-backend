using Application.DTOs.Transactions;
using Application.DTOs.RecurringTransactions;
using Application.Interfaces.UseCases.Transactions;
using Application.Interfaces.UseCases.RecurringTransactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fintor.api.Controllers
{
    [ApiController]
    [Route("api/recurring-transactions")]
    public class RecurringTransactionController : Controller
    {
        private readonly ICreateRecurringMovement _createRecurringMovement;
        public RecurringTransactionController(ICreateRecurringMovement createRecurringMovement)
        {
            _createRecurringMovement = createRecurringMovement;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateRecurringMovement([FromBody] CreateRecurringTransactionDTO createRecurringMovementDTO)
        {
            RecurringTransactionDTO recurringMovementDTO = await _createRecurringMovement.ExecuteAsync(createRecurringMovementDTO);
            return Ok(recurringMovementDTO);
        }
    }
}
