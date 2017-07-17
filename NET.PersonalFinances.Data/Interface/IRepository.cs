using NET.PersonalFinances.Entity;
using System;
using System.Collections.Generic;

namespace NET.PersonalFinances.Data.Interface
{
    public interface IRepository<T> : IDisposable where T : EntityBase
    {
        T Insert(T entity);

        T Update(T entity);

        T Delete(T entity);

        T Get(T entity);

        IEnumerable<T> GetAll(T entity);
    }
}
