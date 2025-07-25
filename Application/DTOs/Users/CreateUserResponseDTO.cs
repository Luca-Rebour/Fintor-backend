using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Users
{
    public class CreateUserResponseDTO
    {
        public string Token { get; set; } = null!;
        public UserDTO User { get; set; } = null!;
    }
}
