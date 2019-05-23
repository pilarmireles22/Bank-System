using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Repositories.Contracts
{
    public interface IAccountRepository
    {
        List<Account> GetAccountList();
        Account GetAccountByNumber(string accountNumber);
        void Update(Account account);
    }
}
