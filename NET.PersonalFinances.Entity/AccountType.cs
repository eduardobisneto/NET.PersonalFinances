using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET.PersonalFinances.Entity
{
    [Table("AccountType")]
    public class AccountType : EntityBase
    {
        [StringLength(1)]
        [Column("Initials", TypeName = "varchar")]
        public string Initials { get; set; }
    }
}
