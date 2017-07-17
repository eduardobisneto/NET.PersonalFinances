using NET.PersonalFinances.Data.Interface;
using NET.PersonalFinances.Entity;
using System.Collections.Generic;
using System.Linq;

namespace NET.PersonalFinances.Data.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public override IEnumerable<Account> GetAll(Account entity)
        {
            if (null == entity)
                entity = new Account();

            return (from a in context.Account
                    where (null != entity.AccountId ? a.AccountId.Equals(entity.AccountId) : entity.AccountId == null)
                    && (null != entity.Description ? a.Description.Equals(entity.Description) : entity.Description == null)
                    && (entity.AccountNatureId > 0 ? a.AccountNatureId.Equals(entity.AccountNatureId) : entity.AccountNatureId == 0)
                    && (entity.AccountTypeId > 0 ? a.AccountTypeId.Equals(entity.AccountTypeId) : entity.AccountTypeId == 0)
                    && (entity.StatusId > 0 ? a.StatusId.Equals(entity.StatusId) : entity.StatusId == 0)
                    select a).ToList();
        }
    }
}
