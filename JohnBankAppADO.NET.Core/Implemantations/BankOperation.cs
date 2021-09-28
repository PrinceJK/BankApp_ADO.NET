using JohnBankAppADO.NET.Core.Interfaces;
using JohnBankAppADO.NET.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnBankAppADO.NET.Core.Implemantations
{
    public class BankOperation : IBankOperation
    {
        private readonly ITransactionRespository _transactionRespository;

        private readonly IAccountRepository _accountRepository;

        public BankOperation(ITransactionRespository transactionRespository, IAccountRepository accountRepository)
        {
            _transactionRespository = transactionRespository;
            _accountRepository = accountRepository;
        }
        public void MakeDeposit(string accountNumber, decimal amount, string transactionDescription, string transactionType)
        {
            var transaction = new Transaction
            {
                Amount =  amount,
                AccountNumber = accountNumber,
                TransactionDescription = transactionDescription,
                TransactionType = transactionType
            };
            _transactionRespository.AddTransaction(transaction);
        }

        public void MakeTransfer(string senderAccountNumber, string receiverAccount, decimal amount)
        {
            if (_accountRepository.GetAccountByAccountNumber(receiverAccount) ==  null)
            {
                throw new ArgumentException("Account does not exist");
            }

            var debitTransaction = new Transaction
            {
                AccountNumber = senderAccountNumber,
                CreatedAt = DateTime.Now,
                Amount =- amount,
                TransactionType = "Debit",
                TransactionDescription = "Debit"
            };
            _transactionRespository.AddTransaction(debitTransaction);
            var creditTransaction = new Transaction
            {
                AccountNumber = receiverAccount,
                CreatedAt = DateTime.Now,
                Amount =+ amount,
                TransactionType = "Credit",
                TransactionDescription = "Credit"
            };
            _transactionRespository.AddTransaction(creditTransaction);
        }

        public void MakeWithdrawal(string accountNumber, decimal amount, string transactionDescription, string transactionType)
        {
            var withdralTransaction = new Transaction
            {
                Amount = -amount,
                AccountNumber = accountNumber,
                TransactionDescription = transactionDescription,
                TransactionType = transactionType
            };
            _transactionRespository.AddTransaction(withdralTransaction);
        }
    }
}
