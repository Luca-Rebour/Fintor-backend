using Application.DTOs.Movements;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.Movements;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Movements
{
    public class CreateMovement : ICreateMovement
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IMapper _mapper;
        public CreateMovement(IMovementRepository movementRepository, IMapper mapper)
        {
            _movementRepository = movementRepository;
            _mapper = mapper;
        }

        public async Task<MovementDTO> ExecuteAsync(CreateMovementDTO dto)
        {
            Movement movement = new Movement(dto.AccountId, dto.RecurringMovementId, dto.CategoryId, dto.Amount, dto.Description, dto.MovementType);
            Movement newMovement = await _movementRepository.CreateMovementAsync(movement);
            MovementDTO ret = _mapper.Map<MovementDTO>(newMovement);
            return ret;
        }
    }
}
