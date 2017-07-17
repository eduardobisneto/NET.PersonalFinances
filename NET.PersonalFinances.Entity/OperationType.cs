using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET.PersonalFinances.Entity
{
    [Table("OperationType")]
    public class OperationType : EntityBase
    {
        [StringLength(1)]
        [Column("Initials", TypeName = "varchar")]
        public string Initials { get; set; }
    }
}
