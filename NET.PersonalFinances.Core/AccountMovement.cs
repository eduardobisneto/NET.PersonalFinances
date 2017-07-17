using NET.PersonalFinances.Data.Interface;
using NET.PersonalFinances.Data.Repository;
using System;
using System.Collections.Generic;

namespace NET.PersonalFinances.Core
{
    public class AccountMovement : IAccountMovementRepository
    {
        private readonly IAccountMovementRepository repository;

        public AccountMovement()
        {
            repository = new AccountMovementRepository();
        }

        public Entity.AccountMovement Delete(Entity.AccountMovement entity)
        {
            if (entity.Id.Equals(0))
                throw new Exception("The Id of Account Movement is required");

            return repository.Delete(entity);
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public Entity.AccountMovement Get(Entity.AccountMovement entity)
        {
            if (entity.Id.Equals(0))
                throw new Exception("The Id of Account Movement is required");

            return repository.Get(entity);
        }

        public IEnumerable<Entity.AccountMovement> GetAll(Entity.AccountMovement entity)
        {
            return repository.GetAll(entity);
        }

        public Entity.AccountMovement Insert(Entity.AccountMovement entity)
        {
            if (entity.AccountId.Equals(0))
                throw new Exception("The Account is required");

            if (entity.Amount.Equals(0))
                throw new Exception("The Amount need be bigger than 0");

            if (entity.OperationTypeId.Equals(0))
                throw new Exception("The Operation Type is required");

            return repository.Insert(entity);
        }

        public IEnumerable<Entity.AccountMovement> InsertRange(IEnumerable<Entity.AccountMovement> entities)
        {
            foreach (Entity.AccountMovement entity in entities)
            {
                if (entity.AccountId.Equals(0))
                    throw new Exception("The Account is required");

                if (entity.Amount.Equals(0))
                    throw new Exception("The Amount need be bigger than 0");

                if (entity.OperationTypeId.Equals(0))
                    throw new Exception("The Operation Type is required");
            }

            return repository.InsertRange(entities);
        }

        public Entity.AccountMovement Update(Entity.AccountMovement entity)
        {
            return repository.Update(entity);
        }

        public IEnumerable<Entity.Balance> GetBalance(Entity.Filter.Balance period)
        {
            return repository.GetBalance(period);
        }
    }
}
