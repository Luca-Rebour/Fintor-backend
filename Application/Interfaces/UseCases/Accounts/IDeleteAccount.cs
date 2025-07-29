using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Accounts
{
    public interface IDeleteAccount
    {
        Task ExecuteAsync(Guid accountId);
    }
}
