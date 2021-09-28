using Commons;
using JohnBankAppADO.NET.Core.Interfaces;
using JohnBankAppADO.NET.Model;
using System;

namespace JohnBankAppADO.NET.Core.Implemantations
{
    public class Authentication : IAuthentication
    {
        private readonly IUserRepository _userRepository;

        public Authentication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        internal bool EmailExist(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var users = _userRepository.GetUsers();
                if (users == null)
                {
                    return false;
                }

                foreach (var user in users)
                {
                    if (user.Email == email)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsValidCredentials(string email, string password)
        {
            if (_userRepository.GetUsers().Count < 1)
            {
                throw new Exception("No record found");
            }

            var user = _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                return false;
            }
            if (user.Email == email)
            {
                if(!Utility.CompareHash(user.PasswordSalt, user.PasswordHash, password))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        public User Login(string email, string password)
        {
            if (!IsValidCredentials(email, password))
            {
                throw new Exception("Invalid Credentials");
            }
            var user = _userRepository.GetUserByEmail(email);
            return user;
        }

        public bool Register(User user, string password)
        {
            if (EmailExist(user.Email))
            {
                throw new Exception("Email already exists");
            }

            var hashPasword = Utility.GenerateHash(password);
            user.PasswordHash = hashPasword[0];
            user.PasswordSalt = hashPasword[1];

            if (_userRepository.AddUser(user))
            {
                return true;
            }
            return false;
        }
    }
}
