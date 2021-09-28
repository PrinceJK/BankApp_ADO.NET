using System;
using System.Text.RegularExpressions;

namespace Commons
{
    public class Checker
    {
        public static bool ValidateTransAccount(string accountNumber)
        {
            if (!Regex.IsMatch(accountNumber, @"\d{10}$"))
                return false;
            return true;
        }

        public static bool ValidateName(string name)
        {
            if (Regex.IsMatch(name, "[A-Za-z]") && string.IsNullOrWhiteSpace(name) != true)
            {
                return true;
            }
            return false;
        }

        public static bool ValidateEmail(string email)
        {
            if (Regex.IsMatch(email, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?") && string.IsNullOrWhiteSpace(email) != true)
            {
                return true;
            }
            return false;
        }
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            if (Regex.IsMatch(phoneNumber, @"^[0]\d{10}$") && string.IsNullOrWhiteSpace(phoneNumber) != true)
            {
                return true;
            }
            return false;
        }

        public static bool ValidatePassword(string password)
        {
            if (Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,15}$") && string.IsNullOrWhiteSpace(password) != true)
            {
                return true;
            }
            return false;
        }
    }
}
