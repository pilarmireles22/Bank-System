using BankSystem.Models;
using BankSystem.Repositories;
using BankSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankSystem.Services
{
    public class AccountService: IAccountService
    {
        private AccountRepository _repository;
        public AccountService() {
            _repository = new AccountRepository(DbContextFactory.Instance);
        }

        public AccountService(AccountRepository accountRepository)
        {
            _repository = accountRepository;
        }

        public List<Account> GetAccountList()
        {
            return _repository.GetAccountList();
        }
        public Account GetAccountByNumber(string accountNumber)
        {
            return _repository.GetAccountByNumber(accountNumber);
        }
    }
   
}