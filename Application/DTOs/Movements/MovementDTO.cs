using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Movements
{
    public class MovementDTO
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public MovementType MovementType { get; set; }
        public RecurringMovement? RecurringMovement { get; set; }
        public Category Category { get; set; }
        public MovementDTO()
        {

        }
    }
}
