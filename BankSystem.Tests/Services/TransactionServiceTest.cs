using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankSystem;
using BankSystem.Controllers;
using Moq;
using BankSystem.Repositories.Contracts;
using BankSystem.Models;
using BankSystem.Services;

namespace BankSystem.Tests.Controllers
{
    [TestClass]
    public class TransactionServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(FromAccountNotHaveBalanceException))]
        public void SaveTransactionWithoutSufficientBalance()
        {
            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetAccountByNumber("12345")).Returns(new Account(1, "12345", null, null, 50));
            accountRepository.Setup(x => x.GetAccountByNumber("123456")).Returns(new Account(2, "123456", null, null, 10));
            accountRepository.Setup(x => x.Update(It.IsAny<Account>()));

            var transactionRepository = new Mock<ITransactionRepository>();
            transactionRepository.Setup(x => x.SaveTransaction(It.IsAny<Transaction>()));

            var transactionService = new TransactionService(accountRepository.Object, transactionRepository.Object);

            transactionService.SaveTransaction("12345", "123456", 100);
        }
        [TestMethod]
        [ExpectedException(typeof(LimitAmountException))]
        public void SaveTransactionLimitAmountException()
        {
            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetAccountByNumber("12345")).Returns(new Account(1, "12345", null, null, 200000));
            accountRepository.Setup(x => x.GetAccountByNumber("123456")).Returns(new Account(2, "123456", null, null, 10));
            accountRepository.Setup(x => x.Update(It.IsAny<Account>()));

            var transactionRepository = new Mock<ITransactionRepository>();
            transactionRepository.Setup(x => x.SaveTransaction(It.IsAny<Transaction>()));

            var transactionService = new TransactionService(accountRepository.Object, transactionRepository.Object);

            transactionService.SaveTransaction("12345", "123456", 200000);
        }
        [TestMethod]
        public void SaveTransaction()
        {
            var accountRepository = new Mock<IAccountRepository>();
            var accountOne = new Account(1, "12345", null, null, 100);
            var accountTwo = new Account(2, "123456", null, null, 10);
            var amount = 10;

            accountRepository.Setup(x => x.GetAccountByNumber("12345")).Returns(accountOne);
            accountRepository.Setup(x => x.GetAccountByNumber("123456")).Returns(accountTwo);
            accountRepository.Setup(x => x.Update(It.IsAny<Account>()));

            var transactionRepository = new Mock<ITransactionRepository>();
            transactionRepository.Setup(x => x.SaveTransaction(It.IsAny<Transaction>()));

            var transactionService = new TransactionService(accountRepository.Object, transactionRepository.Object);

            transactionService.SaveTransaction("12345", "123456", amount);

            Assert.AreEqual(accountOne.Balance, 90);
            Assert.AreEqual(accountTwo.Balance, 20);
        }
        [TestMethod]
        [ExpectedException(typeof(FromAccountNotExistsException))]
        public void FromAccountNotExists()
        {
            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetAccountByNumber("12345")).Returns(new Account(1, "12345", null, null, 50));
            accountRepository.Setup(x => x.GetAccountByNumber("123456")).Returns(new Account(2, "123456", null, null, 10));
            accountRepository.Setup(x => x.Update(It.IsAny<Account>()));

            var transactionRepository = new Mock<ITransactionRepository>();
            transactionRepository.Setup(x => x.SaveTransaction(It.IsAny<Transaction>()));

            var transactionService = new TransactionService(accountRepository.Object, transactionRepository.Object);

            transactionService.SaveTransaction("123455", "123456", 100);
        }
        [TestMethod]
        [ExpectedException(typeof(ToAccountNotExistsException))]
        public void ToAccountNotExists()
        {
            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetAccountByNumber("12345")).Returns(new Account(1, "12345", null, null, 50));
            accountRepository.Setup(x => x.GetAccountByNumber("123456")).Returns(new Account(2, "123456", null, null, 10));
            accountRepository.Setup(x => x.Update(It.IsAny<Account>()));

            var transactionRepository = new Mock<ITransactionRepository>();
            transactionRepository.Setup(x => x.SaveTransaction(It.IsAny<Transaction>()));

            var transactionService = new TransactionService(accountRepository.Object, transactionRepository.Object);

            transactionService.SaveTransaction("12345", "1234567", 100);
        }
        [TestMethod]
        [ExpectedException(typeof(AmountGreaterThanZeroException))]
        public void AmountGreaterThanZeroException()
        {
            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetAccountByNumber("12345")).Returns(new Account(1, "12345", null, null, 50));
            accountRepository.Setup(x => x.GetAccountByNumber("123456")).Returns(new Account(2, "123456", null, null, 10));
            accountRepository.Setup(x => x.Update(It.IsAny<Account>()));

            var transactionRepository = new Mock<ITransactionRepository>();
            transactionRepository.Setup(x => x.SaveTransaction(It.IsAny<Transaction>()));

            var transactionService = new TransactionService(accountRepository.Object, transactionRepository.Object);

            transactionService.SaveTransaction("12345", "123456", 0);
        }
    }
}
