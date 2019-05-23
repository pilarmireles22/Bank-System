using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankSystem.Models
{
    public class Bank
    {
        [Key]
        public int BankID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}