using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> CreateAccountAsync(Account account);
        Task DeleteAccountAsync(Guid accountId);
        Task<List<Account>> GetAllAccountsAsync(Guid userId);
    }
}
