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
    public class TransactionRepository : IMovementRepository
    {
        private readonly FintorDbContext _context;
        public TransactionRepository(FintorDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> CreateMovementAsync(Transaction movement)
        {
            _context.Transactions.Add(movement);
            await _context.SaveChangesAsync();
            return movement;
        }

        public async Task<List<Transaction>> GetAccountMovementsAsync(Guid accountId)
        {
            return await _context.Transactions
                .Where(m => m.AccountId == accountId)
                .Include(m => m.Category)
                .ToListAsync();
        }
    }
}
