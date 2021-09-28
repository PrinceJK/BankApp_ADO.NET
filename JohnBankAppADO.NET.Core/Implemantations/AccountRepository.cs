using JohnBankAppADO.NET.Core.Interfaces;
using JohnBankAppADO.NET.Data;
using JohnBankAppADO.NET.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace JohnBankAppADO.NET.Core.Implemantations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ITransactionRespository _transactionRepository;

        public AccountRepository(ITransactionRespository transactionRespository)
        {
            _transactionRepository = transactionRespository;
        }
        public bool AddAccount(Account account, string Id)
        {
            //Tie the account to user id
            account.UserID = Id;

            //string command = "spAddNewAccount";

            string command = "INSERT INTO[dbo].[Account]([Id], [AccountNumber],[AccountType], [UserId], [CreatedAt])" +
                " VALUES(@a_Id,@a_AccountNumber,@a_AccountType, @a_UserId, @a_CreatedAt)";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter(@"a_Id",account.Id),
                new SqlParameter(@"a_AccountNumber",account.AccountNumber),
                new SqlParameter(@"a_AccountType",account.AccountType), 
                new SqlParameter(@"a_UserId", account.UserID),
                new SqlParameter(@"a_CreatedAt",account.CreatedAt),
            };

            if (SQLHelper.ExecuteNonQuery(command, System.Data.CommandType.Text, sqlParameters))
            {
                if (account.Transactions.Count > 0)
                {
                    foreach (var item in account.Transactions)
                    {
                        _transactionRepository.AddTransaction(item);
                    }
                }
                return true;
            }
            return false;
        }

        public Account GetAccountByAccountNumber(string accountNumber)
        {
            string command = "SELECT [AccountNumber], [AccountType], [UserID] " +
                "FROM [dbo].[Account] WHERE [AccountNumber] = @AccountNumber";

            Account account = null;

            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@AccountNumber", accountNumber)
            };

            using (DataTable dataTable = SQLHelper.ExecuteParameterizedCommand(command, CommandType.Text, sqlParameter))
            {
                if (dataTable.Rows.Count == 1)
                {
                    DataRow dataRow = dataTable.Rows[0];

                    if (dataRow["AccountType"].ToString() == "Savings")
                    {
                        account = new SavingAccount();
                    }
                    if (dataRow["AccountType"].ToString() == "Current")
                    {
                        account = new CurrentAccount();
                    }

                    account.AccountNumber = dataRow["AccountNumber"].ToString();
                    account.AccountType = dataRow["AccountType"].ToString();
                    account.UserID = dataRow["UserID"].ToString();

                    foreach (var item in _transactionRepository.GetAllAccountTransactions(account.AccountNumber))
                    {
                        account.Transactions.Add(item);
                    }
                }
            }
            return account;
        }

        public List<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAUserAccounts(string id)
        {
            string command = "SELECT [AccountNumber], [AccountType], [UserID] FROM [dbo].[Account] " +
                "WHERE [UserID] = @a_Id";

            List<Account> userAccounts = null;

            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@a_Id", id)
            };

            using (DataTable dataTable = SQLHelper.ExecuteParameterizedCommand(command, CommandType.Text, sqlParameter))
            {
                if (dataTable.Rows.Count > 0)
                {
                    userAccounts = new List<Account>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Account account = default;

                        if (row["AccountType"].ToString() == "Savings")
                        {
                            account = new SavingAccount();
                        }
                        if (row["AccountType"].ToString() == "Current")
                        {
                            account = new CurrentAccount();
                        }

                        account.AccountNumber = row["AccountNumber"].ToString();
                        account.AccountType = row["AccountType"].ToString();
                        account.UserID = row["UserID"].ToString();

                        foreach (var item in _transactionRepository.GetAllAccountTransactions(account.AccountNumber))
                        {
                            account.Transactions.Add(item);
                        }
                        userAccounts.Add(account);
                    }
                }
            }

            return userAccounts;
        }
    }
}
