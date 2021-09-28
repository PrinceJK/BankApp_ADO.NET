using Commons;
using System;
using System.Collections.Generic;

namespace JohnBankAppADO.NET.Model
{
    public class User
    {
        public string Id { get; set; }
        private string _firstname;
        public string FirstName
        {
            get { return _firstname; }
            set
            {
                _firstname = Utility.RemoveDigitFromStart(value.Trim());
                _firstname = Utility.FirstCharacterToUpper(_firstname);

            }
        }
        private string _lastname;
        public string LastName
        {
            get { return _lastname; }
            set
            {
                _lastname = Utility.RemoveDigitFromStart(value.Trim());
                _lastname = Utility.FirstCharacterToUpper(_lastname);
            }
        }
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        
        public IList<Account> UserAccounts { get; set; }

        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserAccounts = new List<Account>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public User(string firstName, string lastName,string phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

    }
}
