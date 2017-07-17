using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NET.PersonalFinances.Entity.DTO
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
        }

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string Description { get; set; }
    }
}
