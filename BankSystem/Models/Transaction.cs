using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankSystem.Models
{
    public enum TransactionType
    {
        DEBIT, CREDIT
    }

    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public virtual Account Account { get; set; }
        public virtual Client Client { get; set; }
        public TransactionType Type  { get; set; }
        public double Amount { get; set; }
    }
}