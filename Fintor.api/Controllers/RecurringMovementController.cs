using Application.DTOs.Movements;
using Application.DTOs.RecurringMovements;
using Application.Interfaces.UseCases.Movements;
using Application.Interfaces.UseCases.RecurringMovements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fintor.api.Controllers
{
    [ApiController]
    [Route("api/recurring-movements")]
    public class RecurringMovementController : Controller
    {
        private readonly ICreateRecurringMovement _createRecurringMovement;
        public RecurringMovementController(ICreateRecurringMovement createRecurringMovement)
        {
            _createRecurringMovement = createRecurringMovement;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateRecurringMovement([FromBody] CreateRecurringMovementDTO createRecurringMovementDTO)
        {
            RecurringMovementDTO recurringMovementDTO = await _createRecurringMovement.ExecuteAsync(createRecurringMovementDTO);
            return Ok(recurringMovementDTO);
        }
    }
}
