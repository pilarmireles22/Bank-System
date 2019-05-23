using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankSystem
{
    public class FromAccountNotExistsException : Exception
    {   public string ErrorCode { get; set; }
        public FromAccountNotExistsException(string message, string errorCode): base(message) {
            ErrorCode = errorCode;
                }
    }
}