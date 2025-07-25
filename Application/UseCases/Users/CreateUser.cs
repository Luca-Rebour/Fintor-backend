using Application.DTOs.Users;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases.Users;
using AutoMapper;
using Domain.Entities;
using Fintor.api.Exceptions;

namespace Application.UseCases.Users
{
    public class CreateUser : ICreateUser
    {
        private readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        public readonly IPasswordService _passwordService;
        public CreateUser(
            IUserRepository userRepository,
            IMapper mapper,
            IPasswordService passwordService
            ) 
        { 
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordService = passwordService;
        }
        public async Task<CreateUserResponseDTO> Execute(CreateUserDTO dto)
        {
            dto.Validate();
            if (await _userRepository.GetUserByEmail(dto.Email) != null)
            {
                throw new EmailAlreadyExistsException(dto.Email); 
            }
            User newUser = _mapper.Map<User>(dto);
            newUser.SetPassword(_passwordService.HashPassword(dto.Password));
            newUser = await _userRepository.CreateUser(newUser);
            CreateUserResponseDTO ret = _mapper.Map<CreateUserResponseDTO>(newUser);
            return ret;
        }

    }
}
