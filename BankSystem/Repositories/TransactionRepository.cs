using BankSystem.Models;
using BankSystem.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankSystem.Repositories
{
    public class TransactionRepository: ITransactionRepository
    {
        private BankContext _context;
        //constructor
        public TransactionRepository(BankContext context)
        {
            _context = context;
        }
        public TransactionRepository() { }
        /// <summary>
        /// Save transaction to database
        /// </summary>
        /// <param name="transaction"></param>
        public void SaveTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.Entry(transaction).State = EntityState.Added;
            _context.SaveChanges();
        }
    }
}