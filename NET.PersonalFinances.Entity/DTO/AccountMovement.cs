using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET.PersonalFinances.Entity.DTO
{
    public class AccountMovement
    {
        public DateTime DueDate { get; set; }

        public string Note { get; set; }

        public int AccountId { get; set; }
                
        public int OperationTypeId { get; set; }

        public Account Account { get; set; }

        public OperationType OperationType { get; set; }

        public decimal Amount { get; set; }

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string Description { get; set; }
    }
}
