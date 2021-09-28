using BankApp.UI;
using Commons;
using JohnBankAppADO.NET.Core.Interfaces;
using JohnBankAppADO.NET.Model;
using JohnBankAppADO.NET.UI.DTO;
using System;
using System.Windows.Forms;

namespace JohnBankAppADO.NET.UI.Views.UserForms
{
    public partial class frmRegister : Form
    {
        private readonly IAuthentication _authentication;
        private readonly IBankOperation _bankOperation;
        private readonly IUserRepository _userRepository;
        UserInput _userInput = new UserInput();


        public frmRegister(IBankOperation bankOperation, IAuthentication authentication) 
        {
            _bankOperation = bankOperation;
            _authentication = authentication;
            //userRepository = userRepository;
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void txtPassword1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Password Mismatch!");
            }
            else
            {

                _userInput.FirstName = this.txtFirstName.Text;
                _userInput.LastName = this.txtLastName.Text;
                _userInput.PhoneNumber = this.txtPhoneNumber.Text;
                _userInput.Email = this.txtEmail.Text;
                _userInput.Password = this.txtPassword.Text;


                bool valid = false;
                if (CheckIfEmpty(_userInput.FirstName, _userInput.LastName, _userInput.PhoneNumber, _userInput.Email, _userInput.Password))
                {
                    valid = true;
                    if (!Checker.ValidateEmail(_userInput.Email))
                    {
                        valid = false;
                        MessageBox.Show("Invalid Email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (!Checker.ValidatePhoneNumber(_userInput.PhoneNumber))
                    {
                        valid = false;
                        MessageBox.Show("Invalid PhoneNumber", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (valid)
                {
                    this.Hide();
                    frmAccountType accountType = new frmAccountType(_authentication, _bankOperation, _userInput);
                    accountType.Show();
                }
            }
        }
        private bool CheckPassword()
        {
            if(this.txtPassword.Text == this.txtPassword1.Text)
            {
                return true;
            }
            return false;
        }
        private bool CheckIfEmpty(string firstName, string lastName, string phoneNumber, string Email, string password)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(password))

            {
                MessageBox.Show("All fields are required", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
