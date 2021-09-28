using JohnBankAppADO.NET.Core.Interfaces;
using JohnBankAppADO.NET.Model;
using JohnBankAppADO.NET.UI.DTO;
using System;
using System.Windows.Forms;

namespace BankApp.UI
{
    public partial class frmAccountType : Form
    {
        //fields


        UserInput _userInput;
        private readonly IAuthentication _authentication;
        private readonly IBankOperation _bankOperation;
        public frmAccountType(IAuthentication authentication, IBankOperation bankOperation, UserInput userInput)
        {
            _userInput = userInput;
            _bankOperation = bankOperation;
            _authentication = authentication;
            InitializeComponent();
        }

        private void frmAccountType_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                FirstName = _userInput.FirstName,
                LastName = _userInput.LastName,
                Email = _userInput.Email,
                PhoneNumber = _userInput.PhoneNumber
            };
            


            try
            {
               // _authentication.Register(_user, _user.Password);
                decimal amount = default;
                if (this.rdioCurrent.Checked)
                {
                    if (string.IsNullOrEmpty(txtDeposit.Text))
                    {
                        throw new Exception("You must make an initial deposit");
                    }

                    amount = decimal.Parse(txtDeposit.Text);
                    if (amount < 0)
                    {
                        throw new InvalidOperationException("Amount cannot be negative");
                    }

                    var newAccount = new CurrentAccount();
                    _bankOperation.MakeDeposit(newAccount.AccountNumber.ToString(), amount, "Initial Deposit", "Deposit");
                    user.UserAccounts.Add(newAccount);
                    _authentication.Register(user, _userInput.Password);
                    MessageBox.Show("Your Registeration was successfull", "Successful", MessageBoxButtons.OK);
                    this.Hide();
                }
                else if (this.rdioSavings.Checked)
                {
                    if (string.IsNullOrEmpty(txtDeposit.Text))
                    {
                        throw new Exception("You must make an initial deposit");
                    }

                    bool success = decimal.TryParse(txtDeposit.Text, out amount);

                    if (!success)
                    {
                        throw new ArgumentException("Invalid Input Format");
                    }

                    if (amount < 1000)
                    {
                        throw new InvalidOperationException("Minimum deposit for a savings account is 1000");
                    }

                    var newAccount = new SavingAccount();
                    _bankOperation.MakeDeposit(newAccount.AccountNumber.ToString(), amount, "Initial Deposit", "Deposit");
                    user.UserAccounts.Add(newAccount);
                    _authentication.Register(user, _userInput.Password);
                    MessageBox.Show("Your Registeration was successfull", "Successful", MessageBoxButtons.OK);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please select an account type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //catch (FormatException)
            //{
            //    MessageBox.Show("Please enter valid input for amount", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
