﻿using Application.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Auth
{
    public class SignInResponseDTO
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}
