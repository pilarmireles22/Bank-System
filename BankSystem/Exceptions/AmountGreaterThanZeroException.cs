using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankSystem
{
    public class AmountGreaterThanZeroException : Exception
    {   public string ErrorCode { get; set; }
        public AmountGreaterThanZeroException(string message, string errorCode): base(message) {
            ErrorCode = errorCode;
                }
    }
}