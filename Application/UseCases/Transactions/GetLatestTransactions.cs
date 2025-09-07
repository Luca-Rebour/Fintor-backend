using Application.DTOs.Transactions;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.Transactions;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Transactions
{
    public class GetLatestTransactions : IGetLatestTransactions
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        public GetLatestTransactions(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<List<TransactionDTO>> ExecuteAsync(Guid userId)
        {
            List<Transaction> transactions = await _transactionRepository.GetLatestTransactions(userId);

            List<TransactionDTO> transactionsDto = _mapper.Map<List<TransactionDTO>>(transactions);
            return transactionsDto;
        }
    }
}
