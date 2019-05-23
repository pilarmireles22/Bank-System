using BankSystem.Models;
using BankSystem.Repositories;
using BankSystem.Repositories.Contracts;
using BankSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankSystem.Services
{
    public class TransactionService: ITransactionService
    {
        private ITransactionRepository _repository;
        private IAccountRepository _accountRepository;
        //constructor
        public TransactionService()
        {
        _repository = new TransactionRepository(DbContextFactory.Instance);
        _accountRepository = new AccountRepository(DbContextFactory.Instance);

        }
        //constructor
        public TransactionService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _repository = transactionRepository;
        }
        /// <summary>
        /// Save transaction and validate 
        /// </summary>
        /// <param name="fromAccountNumber"></param>
        /// <param name="toAccountNumber"></param>
        /// <param name="amount"></param>
        public void SaveTransaction(string fromAccountNumber,string toAccountNumber, double amount) {
            var fromAccount = _accountRepository.GetAccountByNumber(fromAccountNumber);
            var toAccount = _accountRepository.GetAccountByNumber(toAccountNumber);

            // validate from account exist
            if (fromAccount == null)
                throw new FromAccountNotExistsException("Cuenta origen no existe","RR01");
            // validate to account exist
            if (toAccount == null)
                throw new ToAccountNotExistsException("Cuenta origen no existe", "RR04");
            // validate account have balance
            if (amount > fromAccount.Balance)
                throw new FromAccountNotHaveBalanceException("No tiene balance disponible","RR02");
            // validate limit amount
            if (amount > 20000)
                throw new LimitAmountException("monto límite de transacción superado", "RR03");
            // validate Amount Greater Than Zero
            if (amount <= 0)
                throw new AmountGreaterThanZeroException("monto debe ser mayor a cero", "RR05");
            //save debit transaction
            _repository.SaveTransaction(new Transaction
            {
                Account = fromAccount,
                Client= fromAccount.Client,
                Type=TransactionType.DEBIT,
                Amount=amount
            });
            //update the balance from account
            fromAccount.Balance -= amount;
            _accountRepository.Update(fromAccount);
            //save credit transaction
            _repository.SaveTransaction(new Transaction
            {
                Account = toAccount,
                Client = fromAccount.Client,
                Type = TransactionType.CREDIT,
                Amount = amount
            });
            //update the balance to account
            toAccount.Balance += amount;
            _accountRepository.Update(toAccount);
        }
    }
}