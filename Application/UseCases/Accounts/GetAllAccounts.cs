using Application.DTOs.Accounts;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.Accounts;
using Application.Interfaces.UseCases.Movements;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.UseCases.Accounts
{
    public class GetAllAccounts : IGetAllAccounts
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IGetAccountMovements _getAccountMovements;
        private readonly IMapper _mapper;

        public GetAllAccounts(
            IAccountRepository accountRepository,
            IGetAccountMovements getAccountMovements,
            IMapper mapper)
        {
            _accountRepository = accountRepository;
            _getAccountMovements = getAccountMovements;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountDTO>> ExecuteAsync(Guid userId)
        {
            List<Account> accounts = await _accountRepository.GetAllAccountsAsync(userId);
            List<AccountDTO> ret = _mapper.Map<List<AccountDTO>>(accounts);

            foreach (AccountDTO accountDto in ret)
            {
                var movements = await _getAccountMovements.ExecuteAsync(accountDto.Id);
                accountDto.Movements = movements;
                accountDto.Balance = movements.Any()
                    ? movements
                        .Where(m => m.MovementType == MovementType.Income).Sum(m => m.Amount)
                        - movements.Where(m => m.MovementType == MovementType.Expense).Sum(m => m.Amount)
                    : 0;

            }


            return ret;
        }
    }
}
