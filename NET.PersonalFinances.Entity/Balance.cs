using System;

namespace NET.PersonalFinances.Entity
{
    public class Balance
    {
        public int Id { get; set; }

        public int? AccountId { get; set; }

        public string Description { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
