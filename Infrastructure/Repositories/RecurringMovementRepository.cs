using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RecurringMovementRepository : IRecurringMovementRepository
    {
        private readonly FintorDbContext _context;
        public RecurringMovementRepository(FintorDbContext context)
        {
            _context = context;
        }

        public async Task<RecurringMovement> CreateRecurringMovementAsync(RecurringMovement recurringMovement)
        {
            _context.RecurringMovements.Add(recurringMovement);
            await _context.SaveChangesAsync();
            return recurringMovement;
        }
        public async Task<List<RecurringMovement>> GetAllAsync()
        {
            return await _context.RecurringMovements.ToListAsync();
        }


        public async Task<RecurringMovement?> GetByIdAsync(Guid id)
        {
            return await _context.RecurringMovements
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(RecurringMovement recurringMovement)
        {
            await _context.RecurringMovements.AddAsync(recurringMovement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RecurringMovement recurringMovement)
        {
            _context.RecurringMovements.Update(recurringMovement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.RecurringMovements.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
