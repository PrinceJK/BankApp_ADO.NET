using System;
using System.Collections.Generic;
using System.Text;

namespace JohnBankAppADO.NET.Model
{
    public class Transaction
    {
        public string Id { get; set; }
        public string AccountNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Amount { get; set; }
        public string TransactionDescription { get; set; }
        public string TransactionType { get; set; }
        

        public Transaction()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }

        public Transaction(decimal amount, DateTime date, string description, string tracsactionType)
        {
            CreatedAt = date;
            Amount = amount;
            TransactionDescription = description;
            TransactionType = tracsactionType;
        }
    }
}
