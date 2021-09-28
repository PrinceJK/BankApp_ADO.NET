using JohnBankAppADO.NET.Core.Implemantations;
using JohnBankAppADO.NET.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnBankAppADO.NET.UI
{
    public static class GlobalConfig
    {
        public static IUserRepository UserRepository { get; set; }
        public static IAuthentication Authentication { get; set; }
        public static IBankOperation BankOperation { get; set; }
        public static IAccountRepository AccountRepository { get; set; }
        public static ITransactionRespository TransactionRespository { get; private set; }


        public static void AddInstance()
        {
            TransactionRespository = new TransactionRespository();
            AccountRepository = new AccountRepository(TransactionRespository);
            UserRepository = new UserRepository(AccountRepository);
            Authentication = new Authentication(UserRepository);
            BankOperation = new BankOperation(TransactionRespository, AccountRepository);
        }
    }
}
