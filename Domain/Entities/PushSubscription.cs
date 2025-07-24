using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PushSubscription
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string EndPoint { get; private set; }
        public string P256dhKey { get; private set; }
        public string AuthKey { get; private set; }
        public PushSubscription()
        {

        }
        public PushSubscription(Guid userId, string endPoint, string p256dhKey, string authKey)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            EndPoint = endPoint;
            P256dhKey = p256dhKey;
            AuthKey = authKey;
        }
    }
}
