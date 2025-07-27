using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seeds
{
    public static class CurrencySeeder
    {
        public static void SeedCurrencies(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency(id: Guid.Parse("00000000-0000-0000-0000-000000000001"), code: "USD", symbol: "$", name: "Dólar estadounidense"),
                new Currency(id: Guid.Parse("00000000-0000-0000-0000-000000000002"), code: "UYU", symbol: "$U", name: "Peso uruguayo"),
                new Currency(id: Guid.Parse("00000000-0000-0000-0000-000000000003"), code: "EUR", symbol: "€", name: "Euro")
            );
        }
    }
}
