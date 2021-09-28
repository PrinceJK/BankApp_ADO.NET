using JohnBankAppADO.NET.Core.Interfaces;
using JohnBankAppADO.NET.Data;
using JohnBankAppADO.NET.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JohnBankAppADO.NET.Core.Implemantations
{
    public class TransactionRespository : ITransactionRespository
    {
        public bool AddTransaction(Transaction transaction)
        {
            //using string command = "INSERT INTO dbo.TransactionTable";
            // string command = "GetTransactions";
            string command = "INSERT INTO [dbo].[Transactions] (Id, AccountNumber,CreatedAt,Amount,TransactionDescription,TransactionType)" +
                " VALUES(@a_Id, @a_AccountNumber, @a_CreatedAt, @a_Amount, @a_TransactionDescription, @a_TransactionType)";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter(@"a_Id",transaction.Id),
                new SqlParameter(@"a_AccountNumber",transaction.AccountNumber),
                new SqlParameter(@"a_CreatedAt",transaction.CreatedAt),
                new SqlParameter(@"a_Amount",transaction.Amount),
                new SqlParameter(@"a_TransactionDescription",transaction.TransactionDescription),
                new SqlParameter(@"a_TransactionType",transaction.TransactionType)
            };
            return SQLHelper.ExecuteNonQuery(command, CommandType.Text, sqlParameters);
        }

        public List<Transaction> GetAllAccountTransactions(string accountNumber)
        {
            string command = "SELECT [AccountNumber], [CreatedAt], [Amount], [TransactionDescription], [TransactionType]" +
                "FROM [dbo].[Transactions] WHERE [AccountNumber] = @a_AccountNumber";
            Transaction transaction = new Transaction();
            List<Transaction> transactionList = new List<Transaction>();

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@a_AccountNumber",accountNumber)
            };

            using DataTable dataTable = SQLHelper.ExecuteParameterizedCommand(command, CommandType.Text, sqlParameters);


            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    transaction.AccountNumber = row["AccountNumber"].ToString();
                    transaction.CreatedAt = Convert.ToDateTime(row["CreatedAt"]);
                    transaction.Amount = Convert.ToDecimal(row["Amount"].ToString());
                    transaction.TransactionDescription = row["TransactionDescription"].ToString();
                    transaction.TransactionType = row["TransactionType"].ToString();

                    transactionList.Add(transaction);
                };
               
            }
            return transactionList;
        }
       

        public List<Transaction> GetRecentTransactions(string account1, string account2)
        {
            string command = $"SELECT AccountNumber, CreatedAt, Amount, TransactionDescription, TransactionType " +
                $"FROM Transactions WHERE AccountNumber = {account1} OR AccountNumber = {account2} ORDER BY Id DESC";

            List<Transaction> transactionList = null;
            

            using (DataTable dataTable = SQLHelper.ExecuteSelectCommand(command, CommandType.Text))
            {
                if (dataTable.Rows.Count > 0)
                {
                    Transaction transaction = new Transaction();
                    transactionList = new List<Transaction>();
                    
                    foreach (DataRow row in dataTable.Rows)
                    {
                        transaction.AccountNumber = row["AccountNumber"].ToString();
                        transaction.CreatedAt = Convert.ToDateTime(row["CreatedAt"]);
                        transaction.Amount = Convert.ToDecimal(row["Amount"].ToString());
                        transaction.TransactionDescription = row["TransactionDescription"].ToString();
                        transaction.TransactionType = row["TransactionType"].ToString();

                        transactionList.Add(transaction);
                    }
                }
            }
            return transactionList;
        }
    }
}
