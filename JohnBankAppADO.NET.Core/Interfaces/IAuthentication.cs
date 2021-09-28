using JohnBankAppADO.NET.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnBankAppADO.NET.Core.Interfaces
{
    public interface IAuthentication
    {
        bool Register(User user, string password);
        User Login(string email, string password);
    }
}
