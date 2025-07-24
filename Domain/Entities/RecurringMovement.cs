using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RecurringMovement
    {
        public Guid Id { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid AccountId { get; private set; }
        public string Name { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public MovementType movementType { get; private set; }
        public Frequency Frequency { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        public DateOnly LastGeneratedAt { get; private set; }
        public ICollection<Movement> Movements { get; private set; } = new List<Movement>();
        public Account Account { get; private set; } = null!;

        public RecurringMovement()
        {

        }
        public RecurringMovement(Guid categoryId, Guid accountId, string name, decimal amount, string description, MovementType movementType, Frequency frequency, DateOnly startDate, DateOnly endDate, DateOnly lastGeneratedAt)
        {
            Id = Guid.NewGuid();
            CategoryId = categoryId;
            AccountId = accountId;
            Name = name;
            Amount = amount;
            Description = description;
            this.movementType = movementType;
            Frequency = frequency;
            StartDate = startDate;
            EndDate = endDate;
            LastGeneratedAt = lastGeneratedAt;
        }
        public bool ShouldGenerate(DateOnly today)
        {
            if (LastGeneratedAt < today)
            {
                return true;
            }
            return false;
        }
    }
}
