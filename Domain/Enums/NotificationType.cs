using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum NotificationType
    {
        BudgetExceeded = 0,
        DailyReminder = 1,
        PaymentDue = 2,
        GoalReached = 3,
        GoalReminder = 4
    }
}
