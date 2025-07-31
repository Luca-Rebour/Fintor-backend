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
    public class GetAccountMovements : IGetAccountMovements
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IMapper _mapper;
        public GetAccountMovements(IMovementRepository movementRepository, IMapper mapper)
        {
            _movementRepository = movementRepository;
            _mapper = mapper;
        }

        public async Task<List<MovementDTO>> ExecuteAsync(Guid accountId)
        {
            List<Movement> movements = await _movementRepository.GetAccountMovementsAsync(accountId);
            List<MovementDTO> ret = _mapper.Map<List<MovementDTO>>(movements);
            return ret;

        }
    }
}
