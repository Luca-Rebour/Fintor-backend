using Application.DTOs.RecurringTransactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.RecurringTransactions
{
    public interface ICreateRecurringMovement
    {
        Task<RecurringTransactionDTO> ExecuteAsync(CreateRecurringTransactionDTO recurringMovementDTO);
    }
}
