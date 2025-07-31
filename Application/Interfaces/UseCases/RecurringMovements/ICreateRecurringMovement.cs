using Application.DTOs.RecurringMovements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.RecurringMovements
{
    public interface ICreateRecurringMovement
    {
        Task<RecurringMovementDTO> ExecuteAsync(CreateRecurringMovementDTO recurringMovementDTO);
    }
}
