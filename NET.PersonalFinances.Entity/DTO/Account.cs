using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET.PersonalFinances.Entity.DTO
{
    public class AccountDTO : EntityBase
    {
        public int StatusId { get; set; }

        public int? AccountId { get; set; }

        public int AccountTypeId { get; set; }

        public int AccountNatureId { get; set; }

        public Status Status { get; set; }

        public Account Account1 { get; set; }

        public AccountType AccountType { get; set; }

        public AccountNature AccountNature { get; set; }

        public ICollection<AccountMovement> AccountMovement { get; set; }
    }
}
