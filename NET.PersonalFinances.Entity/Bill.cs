using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET.PersonalFinances.Entity
{
    [Table("Bill")]
    public class Bill : EntityBase
    {
        public int? AccountId { get; set; }

        public decimal Amount{ get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        public virtual AccountType AccountType { get; set; }

        [ForeignKey("AccountNatureId")]
        public virtual AccountNature AccountNature { get; set; }

        public virtual ICollection<AccountMovement> AccountMovement { get; set; }
    }
}
