using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Movements
{
    public class MovementDTO
    {
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public MovementType MovementType { get; private set; }
        public Account Account { get; private set; } = null!;
        public Category Category { get; private set; } = null!;
        public RecurringMovement? RecurringMovement { get; private set; }
        public MovementDTO()
        {

        }
    }
}
