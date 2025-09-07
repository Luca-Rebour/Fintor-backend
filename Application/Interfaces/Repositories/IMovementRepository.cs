using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateTransactionAsync(Transaction movement);
        Task<List<Transaction>> GetAccountTransactionsAsync(Guid accountId);
        Task<List<Transaction>> GetLatestTransactions(Guid userId);
    }
}
