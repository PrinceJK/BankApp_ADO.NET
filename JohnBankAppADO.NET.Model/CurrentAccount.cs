using System;
using System.Collections.Generic;
using System.Text;

namespace JohnBankAppADO.NET.Model
{
    public class CurrentAccount : Account
    {
        public override string AccountType { get; set; } = "Current";
        public override string ToString()
        {
            return "Current Account";
        }
    }
}
