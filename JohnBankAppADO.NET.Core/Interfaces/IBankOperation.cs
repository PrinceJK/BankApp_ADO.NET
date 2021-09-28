using System;
using System.Collections.Generic;
using System.Text;

namespace JohnBankAppADO.NET.Core.Interfaces
{
    public interface IBankOperation
    {
        public void MakeDeposit(string accountNumber, decimal amount, string description, string AccountType);
        public void MakeWithdrawal(string accountNumber, decimal amount, string transactionDescription, string transactionType);
        public void MakeTransfer(string senderAccountNumber, string ReceiverAccount, decimal amount);
    }
}
