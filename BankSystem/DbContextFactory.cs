using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankSystem
{
    public class DbContextFactory
    {
        private static BankContext _instance;
        public static BankContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BankContext();
                }

                return _instance;
            }
        }
    }
}