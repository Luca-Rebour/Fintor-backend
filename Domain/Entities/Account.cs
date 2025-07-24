using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Name { get; private set; } = null!;

        public User User { get; private set; } = null!;
        public ICollection<Movement> Movements { get; private set; } = new List<Movement>();
        public ICollection<RecurringMovement> RecurringMovements { get; private set; } = new List<RecurringMovement>();

        private Account() { }

        public Account(Guid userId, string name)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Name = name;
        }

        public void Rename(string newName)
        {
            Name = newName;
        }
    }
}
