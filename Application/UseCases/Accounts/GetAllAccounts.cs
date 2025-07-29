using Application.DTOs.Accounts;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.Accounts;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Accounts
{
    public class GetAllAccounts : IGetAllAccounts
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public GetAllAccounts(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountDTO>> ExecuteAsync(Guid userId)
        {
            List<Account> accounts = await _accountRepository.GetAllAccountsAsync(userId);
            List<AccountDTO> ret = _mapper.Map<List<AccountDTO>>(accounts);
            foreach (AccountDTO a in ret)
            {
                a.Balance = a.Movements != null && a.Movements.Any()
                    ? a.Movements.Sum(m => m.Amount)
                    : 0;
            }
            return ret;
        }
    }
}
