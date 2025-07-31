using Application.DTOs.Accounts;
using Application.DTOs.Movements;
using Application.Interfaces.UseCases.Movements;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fintor.api.Controllers
{
    [ApiController]
    [Route("api/movements")]
    public class MovementController : Controller
    {
        private readonly ICreateMovement _createMovement;
        public MovementController(ICreateMovement createMovement)
        {
            _createMovement = createMovement;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateMovementNEW([FromBody] CreateMovementDTO createMovementDTO)
        {
            MovementDTO movementDto = await _createMovement.ExecuteAsync(createMovementDTO);
            return Ok(movementDto);
        }


    }
}
