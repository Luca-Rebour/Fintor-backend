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
    public class MovementRepository : IMovementRepository
    {
        private readonly FintorDbContext _context;
        public MovementRepository(FintorDbContext context)
        {
            _context = context;
        }

        public async Task<Movement> CreateMovementAsync(Movement movement)
        {
            _context.Movements.Add(movement);
            await _context.SaveChangesAsync();
            return movement;
        }

        public async Task<List<Movement>> GetAccountMovementsAsync(Guid accountId)
        {
            return await _context.Movements
                .Where(m => m.AccountId == accountId)
                .Include(m => m.Category)
                .ToListAsync();
        }
    }
}
