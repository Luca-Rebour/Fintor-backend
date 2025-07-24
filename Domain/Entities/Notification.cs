using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Title { get; private set; }
        public bool IsRead { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime TriggerAt { get; private set; }
        public Notification()
        {

        }
        public Notification(Guid userId, string title, bool isRead, DateTime createdAt, DateTime triggerAt)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Title = title;
            IsRead = isRead;
            CreatedAt = createdAt;
            TriggerAt = triggerAt;
        }
    }
}
