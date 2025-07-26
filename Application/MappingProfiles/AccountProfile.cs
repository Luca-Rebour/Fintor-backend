using Application.DTOs.Accounts;
using Application.DTOs.Users;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile() {
            CreateMap<CreateAccountDTO, Account>();
        }
    }
}
