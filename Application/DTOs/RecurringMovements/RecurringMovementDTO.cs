using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.RecurringMovements
{
    public class RecurringMovementDTO
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public MovementType movementType { get; private set; }
        public Frequency Frequency { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        public DateOnly LastGeneratedAt { get; private set; }
        public Account Account { get; private set; } = null!;
    }
}
