using NET.PersonalFinances.Data.Interface;
using NET.PersonalFinances.Data.Repository;
using System;
using System.Collections.Generic;

namespace NET.PersonalFinances.Core
{
    public class Account : IAccountRepository
    {
        private readonly IAccountRepository repository;

        public Account()
        {
            repository = new AccountRepository();
        }

        public Entity.Account Delete(Entity.Account entity)
        {
            if (entity.Id.Equals(0))
                throw new Exception("The Id of Account is required");

            return repository.Delete(entity);
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public Entity.Account Get(Entity.Account entity)
        {
            if (entity.Id.Equals(0))
                throw new Exception("The Id of Account is required");

            return repository.Get(entity);
        }

        public IEnumerable<Entity.Account> GetAll(Entity.Account entity = null)
        {
            return repository.GetAll(entity);
        }

        public Entity.Account Insert(Entity.Account entity)
        {
            if (entity.AccountNatureId.Equals(0))
                throw new Exception("The Account Nature of Account is required");

            if (entity.AccountTypeId.Equals(0))
                throw new Exception("The Account Type of Account is required");

            if (entity.StatusId.Equals(0))
                throw new Exception("The Status of Account is required");

            if (string.IsNullOrEmpty(entity.Description))
                throw new Exception("The Description of Account is required");

            return repository.Insert(entity);
        }

        public Entity.Account Update(Entity.Account entity)
        {
            if (entity.Id.Equals(0))
                throw new Exception("The Id of Account is required");

            if (entity.AccountNatureId.Equals(0))
                throw new Exception("The Account Nature of Account is required");

            if (entity.AccountTypeId.Equals(0))
                throw new Exception("The Account Type of Account is required");

            if (entity.StatusId.Equals(0))
                throw new Exception("The Status of Account is required");

            if (string.IsNullOrEmpty(entity.Description))
                throw new Exception("The Description of Account is required");

            return repository.Update(entity);
        }
    }
}
