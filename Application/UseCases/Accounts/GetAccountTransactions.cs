using Application.DTOs.Transactions;
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
    public class GetAccountTransactions : IGetAccountMovements
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IMapper _mapper;
        public GetAccountTransactions(IMovementRepository movementRepository, IMapper mapper)
        {
            _movementRepository = movementRepository;
            _mapper = mapper;
        }

        public async Task<List<TransactionDTO>> ExecuteAsync(Guid accountId)
        {
            List<Transaction> movements = await _movementRepository.GetAccountMovementsAsync(accountId);
            List<TransactionDTO> ret = _mapper.Map<List<TransactionDTO>>(movements);
            return ret;
        }
    }
}
