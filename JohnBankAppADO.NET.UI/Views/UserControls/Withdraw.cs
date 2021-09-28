using JohnBankAppADO.NET.Core.Interfaces;
using JohnBankAppADO.NET.Model;
using JohnBankAppADO.NET.UI;
using System;
using System.Windows.Forms;

namespace BankApp.UI.Views.UserControls
{
    public partial class Withdraw : UserControl
    {
        //Fields
        private readonly IBankOperation _bankOperation;
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRespository _transactionRespository;
        private readonly User _user;


        public Withdraw(ITransactionRespository transactionRespository, IBankOperation bankOperation,IAccountRepository accountRepository, User user)
        {
            _bankOperation = bankOperation;
            _accountRepository = accountRepository;
            _transactionRespository = transactionRespository;
            _user = user;
            InitializeComponent();
        }

        private void Withdraw_Load(object sender, EventArgs e)
        {
            cboWithdraw.Items.Add("");
            foreach (var item in _user.UserAccounts)
            {
                this.cboWithdraw.Items.Add(item.AccountNumber);
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            try
            {
                var account = _user.UserAccounts[cboWithdraw.SelectedIndex - 1];



                decimal amount = decimal.Parse(this.txtAmount.Text);

                if (amount < 1)
                {
                    MessageBox.Show("Withdrawn amount must be greater than 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (account.Balance - amount < account.MinimumBalance)
                {
                    MessageBox.Show("Insufficient funds", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var description = this.txtNote.Text;
                    var accountNumber = cboWithdraw.Text;

                    if (CheckEmpty(this.txtNote.Text, description, accountNumber))
                    {
                        throw new Exception("All fields are required");
                    }

                    _bankOperation.MakeWithdrawal(accountNumber, amount, description, "Withdrawal");
                    MessageBox.Show("Withdraw was succesfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                    ControlClass.ShowControl(new Dashboard(_transactionRespository, _accountRepository, _user), this.Parent);
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Please enter a valid input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select an account to withdraw from", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ControlClass.ShowControl(new Dashboard(_transactionRespository, _accountRepository, _user), this.Parent);
        }


        //Check if values are empty
        private bool CheckEmpty(string amount, string accountNumber, string note)
        {
            if (string.IsNullOrEmpty(amount) || string.IsNullOrEmpty(accountNumber) || string.IsNullOrEmpty(note))
                return true;
            return false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
