using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankSystem
{
    public class LimitAmountException : Exception
    {
        public string ErrorCode { get; set; }
        public LimitAmountException(string message, string errorCode) : base(message) {
            ErrorCode = errorCode;
        }
    }
}