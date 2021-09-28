using JohnBankAppADO.NET.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnBankAppADO.NET.Core.Interfaces
{
    public interface ITransactionRespository
    {
        List<Transaction> GetAllAccountTransactions(string accountNumber);
        List<Transaction> GetRecentTransactions(string account1, string account2);
        bool AddTransaction(Transaction transaction);
    }
}
