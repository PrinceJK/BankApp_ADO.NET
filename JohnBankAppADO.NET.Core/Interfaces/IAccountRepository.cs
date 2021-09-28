using JohnBankAppADO.NET.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnBankAppADO.NET.Core.Interfaces
{
    public interface IAccountRepository
    {
        List<Account> GetAccounts();
        public bool AddAccount(Account account, string Id);
        List<Account> GetAUserAccounts(string id);

        Account GetAccountByAccountNumber(string accountNumber);
    }
}
