using Application.DTOs.Accounts;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
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
    public class CreateAccount : ICreateAccount
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        public CreateAccount(
            IMapper mapper,
            IJwtService jwtService,
            IAccountRepository accountRepository
            )
        {
            _mapper = mapper;
            _jwtService = jwtService;
            _accountRepository = accountRepository;
        }
        public async Task<Account> ExecuteAsync(CreateAccountDTO createAccountDTO, Guid userId)
        {
            createAccountDTO.Validate();
            Account newAccount = new Account(userId, createAccountDTO.Name);
            Account ret = await _accountRepository.CreateAccountAsync(newAccount);
            return ret;
        }
    }
}
