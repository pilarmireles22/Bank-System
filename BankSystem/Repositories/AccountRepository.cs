using BankSystem.Models;
using BankSystem.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankSystem.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        
        private BankContext _context; 
        //create constructor
        public AccountRepository(BankContext context)
        {
            //asign instance
            _context = context; 
        }

        public AccountRepository() { }

        public List<Account> GetAccountList()
        {
            
            return _context.Accounts.ToList();
        }

        public Account GetAccountByNumber(string accountNumber)
        {
            return _context.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }
        public void Update(Account account)
        {
            //_context.Accounts.Add(account);
            _context.Entry(account).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}