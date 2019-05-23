using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Repositories.Contracts
{
    public interface ITransactionRepository
    {

        void SaveTransaction(Transaction transaction);
    }
}
