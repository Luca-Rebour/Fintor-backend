﻿using Application.DTOs.Auth;
using Application.DTOs.Users;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases.Auth;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Auth
{
    public class SignIn : ISignIn
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        public SignIn(
            IUserRepository userRepository,
            IPasswordService passwordService,
            IMapper mapper,
            IJwtService jwtService
            )
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _mapper = mapper;
            _jwtService = jwtService;
        }
        public async Task<SignInResponseDTO> Execute(SignInDTO signInDTO)
        {
            User user = await _userRepository.GetUserByEmail(signInDTO.Email);

            if (user == null) {
                throw new NotFoundException($"There is no user registered with email {signInDTO.Email}");
            }

            if(!_passwordService.VerifyPassword(user.PasswordHash, signInDTO.Password))
            {
                throw new InvalidCredentialException("Invalid credentials");
            }
            UserDTO userDTO = _mapper.Map<UserDTO>(user);

            return new SignInResponseDTO
            {
                Token = _jwtService.GenerateToken(userDTO.Id, userDTO.Email),
                User = userDTO
            };


        }
    }
}
