using NET.PersonalFinances.Entity;
using System.Collections.Generic;

namespace NET.PersonalFinances.Data.Interface
{
    public interface IAccountMovementRepository : IRepository<AccountMovement>
    {
        IEnumerable<AccountMovement> InsertRange(IEnumerable<AccountMovement> entities);

        IEnumerable<Balance> GetBalance(NET.PersonalFinances.Entity.Filter.Balance Period);
    }
}
