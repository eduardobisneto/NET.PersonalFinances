using NET.PersonalFinances.Entity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NET.PersonalFinances.API.Controllers
{
    [RoutePrefix("api/bill")]
    public class BillController : ApiController
    {
        public BillController()
        {
        }

        #region AccountMovement

        [Route("deleteAccountMovement")]
        public AccountMovement Delete(AccountMovement entity)
        {
            try
            {
                return new Core.AccountMovement().Delete(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("getAccountMovement")]
        public AccountMovement Get(AccountMovement entity)
        {
            try
            {
                return new Core.AccountMovement().Get(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("insertAccountMovement")]
        public AccountMovement Insert(AccountMovement entity)
        {
            try
            {
                return new Core.AccountMovement().Insert(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("insertRangeAccountMovement")]
        public IEnumerable<AccountMovement> InsertRange(IEnumerable<AccountMovement> entities)
        {
            try
            {
                return new Core.AccountMovement().InsertRange(entities);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("updateAccountMovement")]
        public AccountMovement Update(AccountMovement entity)
        {
            try
            {
                return new Core.AccountMovement().Update(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("getAllAccountsMovements")]
        public IEnumerable<AccountMovement> GetAllMovements(AccountMovement entity)
        {
            try
            {
                return new Core.AccountMovement().GetAll(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("getBalance")]
        public IEnumerable<Balance> GetBalance(Entity.Filter.Balance period)
        {
            try
            {
                return new Core.AccountMovement().GetBalance(period);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        #endregion

        #region Account

        [Route("deleteAccount")]
        public Account Delete(Account entity)
        {
            try
            {
                return new Core.Account().Delete(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("getAccount")]
        public Account Get(Account entity)
        {
            try
            {
                return new Core.Account().Get(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("getAllAccounts")]
        public IEnumerable<Account> GetAll(Account entity)
        {
            try
            {
                return new Core.Account().GetAll(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.ExpectationFailed, e.Message));
            }
        }

        [HttpPost]
        [Route("insertAccount")]
        public Account Insert(Account entity)
        {
            try
            {
                return new Core.Account().Insert(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("updateAccount")]
        public Account Update(Account entity)
        {
            try
            {
                return new Core.Account().Update(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        #endregion
    }
}