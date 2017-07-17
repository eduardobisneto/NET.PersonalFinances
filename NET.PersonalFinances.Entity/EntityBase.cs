using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET.PersonalFinances.Entity
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
        }

        [Key]
        public int Id { get; set; }

        [Column("CreatedDate", TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [Column("ModifiedDate", TypeName = "datetime2")]
        public DateTime? ModifiedDate { get; set; }

        [Required]
        [StringLength(100)]
        [Column("Description", TypeName = "varchar")]
        public string Description { get; set; }
    }
}
