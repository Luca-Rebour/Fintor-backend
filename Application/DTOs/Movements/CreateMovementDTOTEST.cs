using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Movements
{
    public class CreateMovementDTOTEST
    {
        public Guid AccountId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? RecurringMovementId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public MovementType MovementType { get; set; }

        public CreateMovementDTOTEST() { }
        
    }
}
