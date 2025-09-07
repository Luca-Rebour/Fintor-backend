using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Transactions
{
    public class TransactionDTO
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TransactionType MovementType { get; set; }
        public RecurringTransaction? RecurringTransaction { get; set; }
        public Category Category { get; set; }
        public TransactionDTO()
        {

        }
    }
}
