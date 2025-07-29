using Application.DTOs.Accounts;
using Application.DTOs.RecurringMovements;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class RecurringMovementProfile : Profile
    {
        public RecurringMovementProfile() {
            CreateMap<RecurringMovement, RecurringMovementDTO>();
        }
    }
}
