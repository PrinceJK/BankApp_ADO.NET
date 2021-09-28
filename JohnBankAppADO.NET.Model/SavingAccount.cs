using System;
using System.Collections.Generic;
using System.Text;

namespace JohnBankAppADO.NET.Model
{
    public class SavingAccount : Account
    {
        public override decimal MinimumBalance { get; } = 1000m;
        public override string AccountType { get; set; } = "Savings";
        public override string ToString()
        {
            return "Savings Account";
        }
    }
}
