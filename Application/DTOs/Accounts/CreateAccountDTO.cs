using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.DTOs.Accounts
{
    public class CreateAccountDTO
    {
        public string Name { get; set; }

        public void Validate()
        {
            if (Name.Length > 30)
            {
                throw new ArgumentException("Account name is too long. Maximum allowed length is 30 characters.");
            }
        }

    }
}
