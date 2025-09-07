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
    public class CreateTransaction : ICreateTransaction
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IMapper _mapper;
        public CreateTransaction(IMovementRepository movementRepository, IMapper mapper)
        {
            _movementRepository = movementRepository;
            _mapper = mapper;
        }

        public async Task<TransactionDTO> ExecuteAsync(CreateTransactionDTO dto)
        {
            Transaction movement = new Transaction(dto.AccountId, dto.RecurringMovementId, dto.CategoryId, dto.Amount, dto.Description, dto.MovementType);
            Transaction newMovement = await _movementRepository.CreateMovementAsync(movement);
            TransactionDTO ret = _mapper.Map<TransactionDTO>(newMovement);
            return ret;
        }
    }
}
