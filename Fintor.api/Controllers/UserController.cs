using Application.DTOs.Users;
using Application.Interfaces.UseCases.Users;
using Microsoft.AspNetCore.Mvc;

namespace Fintor.api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly ICreateUser _createUser;

        public UserController(ICreateUser createUser)
        {
            _createUser = createUser;
        }

        [HttpPost("create-user")]
        public async Task<CreateUserResponseDTO> CreateUser(CreateUserDTO createUserDTO)
        {
            CreateUserResponseDTO response = await _createUser.Execute(createUserDTO);
            return response;
        }
    }
}
