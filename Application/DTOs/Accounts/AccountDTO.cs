using Application.DTOs.Movements;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Accounts
{
    public class AccountDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public Currency Currency { get; set; }
        public IEnumerable<MovementDTO> Movements { get; set; }
        public ICollection<RecurringMovement> RecurringMovements { get; set; }

        public AccountDTO() { }
    }
}
