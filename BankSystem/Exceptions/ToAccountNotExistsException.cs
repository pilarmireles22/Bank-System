using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankSystem
{
    public class ToAccountNotExistsException : Exception
    {   public string ErrorCode { get; set; }
        public ToAccountNotExistsException(string message, string errorCode): base(message) {
            ErrorCode = errorCode;
                }
    }
}