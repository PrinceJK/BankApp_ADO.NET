using JohnBankAppADO.NET.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnBankAppADO.NET.Core.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        bool AddUser(User user);
        User GetUserByEmail(string Email);
    }
}
