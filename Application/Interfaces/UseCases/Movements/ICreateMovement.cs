using Application.DTOs.Movements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Movements
{
    public interface ICreateMovement
    {
        Task<MovementDTO> ExecuteAsync(CreateMovementDTO dto);
    }
}
