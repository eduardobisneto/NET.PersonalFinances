using NET.PersonalFinances.Data.Interface;
using NET.PersonalFinances.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NET.PersonalFinances.Data.Repository
{
    public class AccountMovementRepository : Repository<AccountMovement>, IAccountMovementRepository
    {
        public override IEnumerable<AccountMovement> GetAll(AccountMovement entity)
        {
            if (null == entity)
                entity = new AccountMovement();

            return (from am in base.context.AccountMovement.Include("Account")
                    where (entity.Account.AccountNatureId > 0 ? am.Account.AccountNatureId.Equals(entity.Account.AccountNatureId) : entity.Account.AccountNatureId == 0)
                    //&& (entity.AccountId > 0 ? am.AccountId.Equals(entity.AccountId) : entity.AccountId == 0)
                    //&& (null != entity.Description ? am.Description.Contains(entity.Description) : entity.Description == null)
                    //&& (entity.Amount > 0 ? am.Amount.Equals(entity.Amount) : entity.Amount == 0)
                    select am).ToList();
        }

        public IEnumerable<AccountMovement> InsertRange(IEnumerable<AccountMovement> entities)
        {
            foreach (AccountMovement entity in entities)
                entity.CreatedDate = DateTime.Now;

            context.Set<AccountMovement>().AddRange(entities);
            context.SaveChanges();

            return entities;
        }

        public IEnumerable<Balance> GetBalance(Entity.Filter.Balance Period)
        {
            return (from a in base.context.Account
                    join am in base.context.AccountMovement on a.Id equals am.AccountId into leftA
                    from la in leftA.DefaultIfEmpty()
                    //where la.DueDate.Equals(null) || (la.DueDate > Period.Start && la.DueDate < Period.End)
                    group la by new
                    {
                        Id = a.Id,
                        AccountId = a.AccountId,
                        Description = a.Description,
                        DueDate = DbFunctions.TruncateTime(la.DueDate)
                    } into g
                    select new Balance()
                    {
                        Id = g.Key.Id,
                        AccountId = g.Key.AccountId,
                        Description = g.Key.Description,
                        Amount = g.Sum(amount => amount.Amount),
                        DueDate = g.Key.DueDate
                    }).ToList();
        }
    }
}
