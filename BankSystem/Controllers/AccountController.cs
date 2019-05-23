using BankSystem.Models;
using BankSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BankSystem.Controllers
{
    public class AccountController : ApiController
    {
        private AccountService _service;
        public AccountController()
        {
            _service = new AccountService();
        }
        public IEnumerable<Account> GetAllAccount()
        {
            return _service.GetAccountList();
        }

        [Route("api/Account/{accountNumber}")]
        public IHttpActionResult GetAccountByNumber(string accountNumber)
        {
            return Ok(_service.GetAccountByNumber(accountNumber));
        }
    }
}
