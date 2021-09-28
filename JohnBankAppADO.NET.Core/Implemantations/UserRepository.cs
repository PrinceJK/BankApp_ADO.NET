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
    public class UserRepository : IUserRepository
    {
        private readonly IAccountRepository _accountRepository;

        public UserRepository(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public bool AddUser(User user)
        {

            //string command = "spAddNewUser";

            string command = "INSERT INTO[dbo].[User]([Id], [FirstName],[LastName], [PhoneNumber],[Email],[CreatedAt],[UpdatedAt],[PasswordSalt],[PasswordHash])";
            command += " VALUES(@a_Id,@a_FirstName,@a_LastName,@a_PhoneNumber,@a_Email,@a_CreatedAt,@a_UpdatedAt,@a_PasswordSalt,@a_PasswordHash)";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                    new SqlParameter("@a_Id",user.Id),
                    new SqlParameter("@a_FirstName",user.FirstName),
                    new SqlParameter("@a_LastName",user.LastName),
                    new SqlParameter("@a_PhoneNumber",user.PhoneNumber),
                    new SqlParameter("@a_Email",user.Email),
                    new SqlParameter("@a_CreatedAt",user.CreatedAt),
                    new SqlParameter("@a_UpdatedAt",user.UpdatedAt),
                    new SqlParameter("@a_PasswordSalt",user.PasswordSalt),
                    new SqlParameter("@a_PasswordHash",user.PasswordHash)

            };

            if (SQLHelper.ExecuteNonQuery(command, CommandType.Text, sqlParameters))
            {
                if (user.UserAccounts.Count > 0)
                {
                    foreach (var item in user.UserAccounts)
                    {
                        _accountRepository.AddAccount(item, user.Id);
                    }
                }
                return true;
            }
            return false;
        }

        public User GetUserByEmail(string email)
        {
            string command = "SELECT [Id], [FirstName], [LastName], [PhoneNumber], [Email], [CreatedAt], [UpdatedAt], [PasswordSalt], [PasswordHash] " +
                "FROM [dbo].[User] WHERE [Email] = @a_Email";

            User user = null;

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@a_Email", email)
            };
            using (DataTable dataTable = SQLHelper.ExecuteParameterizedCommand(command, CommandType.Text, sqlParameters))
            {
                if (dataTable.Rows.Count == 1)
                {
                    DataRow dataRow = dataTable.Rows[0];

                    user = new User();

                    user.Id = dataRow["Id"].ToString();
                    user.FirstName = dataRow["FirstName"].ToString();
                    user.LastName = dataRow["LastName"].ToString();
                    user.PhoneNumber = dataRow["PhoneNumber"].ToString();
                    user.Email = dataRow["Email"].ToString();
                    user.CreatedAt = Convert.ToDateTime(dataRow["CreatedAt"]);
                    user.UpdatedAt = Convert.ToDateTime(dataRow["UpdatedAt"]);
                    user.PasswordSalt = (byte[])dataRow["PasswordSalt"];
                    user.PasswordHash = (byte[])dataRow["PasswordHash"];

                    foreach (var item in _accountRepository.GetAUserAccounts(user.Id))
                    {
                        user.UserAccounts.Add(item);
                    }
                }
            }
            return user;
        }

        public List<User> GetUsers()
        {
            string command = "SELECT [FirstName], [LastName], [PhoneNumber], [Email], [CreatedAt], [UpdatedAt], [PasswordSalt], [PasswordHash]" +
                " FROM[dbo].[User]";

            List<User> usersList = new List<User>();

            using (DataTable dataTable = SQLHelper.ExecuteSelectCommand(command, CommandType.Text))
            {
                if (dataTable.Rows.Count > 0)
                {
                    usersList = new List<User>();

                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        User user = new User();
                        //user.Id = dataRow["Id"].ToString();
                        user.FirstName = dataRow["FirstName"].ToString();
                        user.LastName = dataRow["LastName"].ToString();
                        user.PhoneNumber = dataRow["PhoneNumber"].ToString();
                        user.Email = dataRow["Email"].ToString();
                        user.CreatedAt = Convert.ToDateTime(dataRow["CreatedAt"]);
                        user.UpdatedAt = Convert.ToDateTime(dataRow["UpdatedAt"]);
                        user.PasswordSalt = (byte[])dataRow["PasswordSalt"];
                        user.PasswordHash = (byte[])dataRow["PasswordHash"];

                        usersList.Add(user);
                    }
                }
            }
            return usersList;
        }
    }
}
