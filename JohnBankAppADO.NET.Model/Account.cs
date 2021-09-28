using Commons;
using System;
using System.Collections.Generic;

namespace JohnBankAppADO.NET.Model
{
    public class Account
    {
        public string Id { get; set; }
        public string AccountNumber { get; set; }
        public virtual string AccountType { get; set; }
        public string UserID { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual decimal MinimumBalance { get; } = 0m;
        public List<Transaction> Transactions { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var _transaction in Transactions)
                {
                    balance += _transaction.Amount;
                }
                return balance;
            }
        }

        public Account()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
            Transactions = new List<Transaction>();
            AccountNumber = Utility.GenerateAccountNumber();
        }
        
    }
}
