using Application.DTOs.Accounts;
using Application.DTOs.Movements;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class MovementProfile : Profile
    {
        public MovementProfile()
        {
            CreateMap<Movement, MovementDTO>();
        }
    }
}
