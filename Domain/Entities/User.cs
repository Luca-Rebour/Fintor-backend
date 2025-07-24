using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string? Provider { get; private set; }
        public string? ProviderId { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
