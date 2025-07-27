using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly FintorDbContext _context;
        public CurrencyRepository(FintorDbContext context)
        {
            _context = context;
        }
        public async Task<Currency?> GetCurrencyAsync(Guid id)
        {
            return await _context.Currencies.FindAsync(id);
        }
    }
}
