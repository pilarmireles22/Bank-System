using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Services.Contracts
{
    interface ITransactionService
    {
        void SaveTransaction(string fromAccountNumber, string toAccountNumber, double amount);
    }
}
