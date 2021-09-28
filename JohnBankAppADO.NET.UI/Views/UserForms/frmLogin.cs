using BankApp.UI;
using Commons;
using JohnBankAppADO.NET.Core.Interfaces;
using JohnBankAppADO.NET.Model;
using System;
using System.Windows.Forms;

namespace JohnBankAppADO.NET.UI.Views.UserForms
{
    public partial class frmLogin : Form
    {
        private User _user = new User();
        private readonly IAuthentication _authentication;
        private readonly IBankOperation _bankOperation;
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRespository _transactionRepository;
        //private readonly IUserRepository _userRepository;
        public frmLogin(IAuthentication authentication, IBankOperation bankOperation, IAccountRepository accountRepository, ITransactionRespository transactionRespository)
        {
            _authentication = authentication;
            _bankOperation = bankOperation;
            _accountRepository = accountRepository;
            _transactionRepository = transactionRespository;
           // _userRepository = userRepository;
            InitializeComponent();
        }

        

        private void lblClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void bankName_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            var email = txtEmail.Text;
            var password = txtPassword.Text;
            bool valid = false;
            if (CheckNotEmpty(email, password))
            {
                valid = true;
                if (!Checker.ValidateEmail(email))
                {
                    valid = false;
                    MessageBox.Show("Invalid Email format", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (valid)
            {
                try
                {
                    _user = _authentication.Login(email, password);
                    if (_user != null)
                    {
                        TopMost = false;
                        txtEmail.Text = string.Empty;
                        txtPassword.Text = string.Empty;
                        
                        new frmDashboard(_user, _bankOperation, _accountRepository, _transactionRepository).Show();
                        Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
         private bool CheckNotEmpty(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("All fields are required", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            frmRegister newFrmRegister = new frmRegister(_bankOperation, _authentication);
            newFrmRegister.Show();
        }
    }
}
