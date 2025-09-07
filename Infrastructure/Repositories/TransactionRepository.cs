using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FintorDbContext _context;
        public TransactionRepository(FintorDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> CreateTransactionAsync(Transaction movement)
        {
            _context.Transactions.Add(movement);
            await _context.SaveChangesAsync();
            return movement;
        }

        public async Task<List<Transaction>> GetAccountTransactionsAsync(Guid accountId)
        {
            return await _context.Transactions
                .Where(m => m.AccountId == accountId)
                .Include(m => m.Category)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetLatestTransactions(Guid userId)
        {
            return await _context.Transactions
                .Where(t => t.Account.UserId == userId)
                .Include(t => t.Category)
                .OrderByDescending(t => t.Date)
                .Take(50)
                .ToListAsync();
        }


    }
}
