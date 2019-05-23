using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankSystem
{
    public class FromAccountNotHaveBalanceException : Exception
    {
        public string ErrorCode { get; set; }
        public FromAccountNotHaveBalanceException(string message, string errorCode) : base(message) {
            ErrorCode = errorCode;
        }
    }
}