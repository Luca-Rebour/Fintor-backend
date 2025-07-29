using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Accounts
{
    public class DeleteAccount : IDeleteAccount
    {
        private readonly IAccountRepository _repository;
        public DeleteAccount(IAccountRepository repository)
        {
            _repository = repository;
        }
        public async Task ExecuteAsync(Guid accountId)
        {
            await _repository.DeleteAccountAsync(accountId);
        }
    }
}
