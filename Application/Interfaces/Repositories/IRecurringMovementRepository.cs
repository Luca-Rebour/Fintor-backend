using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IRecurringMovementRepository
    {
        Task<RecurringMovement> CreateRecurringMovementAsync(RecurringMovement recurringMovement);
        Task<List<RecurringMovement>> GetAllAsync();
        Task<RecurringMovement?> GetByIdAsync(Guid id);
        Task AddAsync(RecurringMovement recurringMovement);
        Task UpdateAsync(RecurringMovement recurringMovement);
        Task DeleteAsync(Guid id);
    }
}
