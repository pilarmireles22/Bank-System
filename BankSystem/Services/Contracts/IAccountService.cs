using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Services.Contracts
{
    interface IAccountService
    {
         List<Account> GetAccountList();
        Account GetAccountByNumber(string accountNumber);
    }
}
