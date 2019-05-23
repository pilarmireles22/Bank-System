using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankSystem.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        public string AccountNumber { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual Client Client { get; set; }
        public double Balance { get; set; }

        public Account() { }

        public Account(int accountID, string accountNumber, Bank bank, Client client, double balance)
        {
            AccountID = accountID;
            AccountNumber = accountNumber;
            Bank = bank;
            Client = client;
            Balance = balance;
        }
    }
}