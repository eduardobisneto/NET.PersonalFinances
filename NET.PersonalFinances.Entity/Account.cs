using System.ComponentModel.DataAnnotations.Schema;

namespace NET.PersonalFinances.Entity
{
    [Table("Account")]
    public class Account : EntityBase
    {
        public Account()
        {
        }

        public int StatusId { get; set; }

        public int? AccountId { get; set; }

        public int AccountTypeId { get; set; }

        public int AccountNatureId { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

        [ForeignKey("AccountId")]
        public Account Account1 { get; set; }

        [ForeignKey("AccountTypeId")]
        public virtual AccountType AccountType { get; set; }

        [ForeignKey("AccountNatureId")]
        public virtual AccountNature AccountNature { get; set; }
    }
}
