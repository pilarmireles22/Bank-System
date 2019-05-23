using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankSystem.DTO
{
    public class TransactionDTO
    {
        public string FromAccountNumber { get; set; }
        public string ToAccountNumber { get; set; }
        public Double Amount { get; set; }
    }
}