using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET.PersonalFinances.Entity
{
    [Table("AccountMovement")]
    public class AccountMovement : EntityBase
    {
        public AccountMovement()
        {
        }

        public DateTime DueDate { get; set; }

        public string Note { get; set; }

        public int AccountId { get; set; }

        public int OperationTypeId { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        [ForeignKey("OperationTypeId")]
        public virtual OperationType OperationType { get; set; }

        public decimal Amount { get; set; }
    }
}
