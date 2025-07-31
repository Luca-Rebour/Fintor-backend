using Application.DTOs.RecurringMovements;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.RecurringMovements;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.RecurringMovements
{
    public class CreateRecurringMovement : ICreateRecurringMovement
    {
        private readonly IRecurringMovementRepository _recurringMovementRepository;
        private readonly IMapper _mapper;
        public CreateRecurringMovement(IRecurringMovementRepository recurringMovementRepository, IMapper mapper)
        {
            _recurringMovementRepository = recurringMovementRepository;
            _mapper = mapper;
        }
        public async Task<RecurringMovementDTO> ExecuteAsync(CreateRecurringMovementDTO createRecurringMovementDTO)
        {
            RecurringMovement recurringMovement = new RecurringMovement(createRecurringMovementDTO.CategoryId, createRecurringMovementDTO.AccountId, createRecurringMovementDTO.Name, createRecurringMovementDTO.Amount, createRecurringMovementDTO.Description, createRecurringMovementDTO.movementType, createRecurringMovementDTO.Frequency, createRecurringMovementDTO.StartDate, createRecurringMovementDTO.EndDate);
            await _recurringMovementRepository.AddAsync(recurringMovement);
            RecurringMovementDTO recurringMovementDTO = _mapper.Map<RecurringMovementDTO>(recurringMovement);
            return recurringMovementDTO;
        }
    }
}
