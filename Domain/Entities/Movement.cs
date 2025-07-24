using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movement
    {
        public Guid Id { get; private set; }
        public Guid AccountId { get; private set; }
        public Guid? RecurringMovementId { get; private set; }
        public Guid CategoryId { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public MovementType MovementType { get; private set; }
        public Account Account { get; private set; } = null!;
        public Category Category { get; private set; } = null!;
        public RecurringMovement? RecurringMovement { get; private set; }


        public Movement()
        {

        }
        public Movement(Guid accountId, Guid recurringMovementId, Guid categoryId, decimal amount, string description, DateTime date, MovementType movementType)
        {
            Id = Guid.NewGuid();
            AccountId = accountId;
            RecurringMovementId = recurringMovementId;
            CategoryId = categoryId;
            Amount = amount;
            Description = description;
            Date = date;
            MovementType = movementType;
        }

        public bool IsIncome()
        {
            if (MovementType == MovementType.Income)
            {
                return true;
            }
            return false;
        }

        public bool IsExpense()
        {
            if (MovementType == MovementType.Expense)
            {
                return true;
            }
            return false;
        }
    }
}
