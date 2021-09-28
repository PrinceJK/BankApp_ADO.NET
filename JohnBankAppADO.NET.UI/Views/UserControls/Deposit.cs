using JohnBankAppADO.NET.Core.Interfaces;
using JohnBankAppADO.NET.Model;
using JohnBankAppADO.NET.UI;
using System;
using System.Windows.Forms;

namespace BankApp.UI
{
    public partial class Deposit : UserControl
    {
        //private injected variable
        private readonly IBankOperation _operation;
        private readonly IAccountRepository _accountRepository;
        private readonly User _user;
        private readonly ITransactionRespository _transactionRespository;
        public Deposit(ITransactionRespository transactionRespository, IBankOperation operations,IAccountRepository accountRepository, User user)
        {
            _accountRepository = accountRepository;
            _operation = operations;
            _user = user;
            _transactionRespository = transactionRespository;
            InitializeComponent();
        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            cboAccountSelect.Items.Add("");
            foreach (var item in _user.UserAccounts)
            {
                this.cboAccountSelect.Items.Add(item.AccountNumber);
            }

        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            decimal amount = default;
            try
            {
                amount = decimal.Parse(this.txtAmount.Text);
                if (amount < 1)
                {
                    MessageBox.Show("Deposit must be greater than 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var note = this.txtNote.Text;
                    var accountNumber = cboAccountSelect.Text;

                    if (CheckEmpty(this.txtNote.Text,note,accountNumber))
                    {
                        throw new Exception("All fields are required");
                    }

                    _operation.MakeDeposit(accountNumber, amount, note, "Deposit");
                    MessageBox.Show("Deposit was succesfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                    ControlClass.ShowControl(new Dashboard(_transactionRespository, _accountRepository, _user), this.Parent);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ControlClass.ShowControl(new Dashboard(_transactionRespository, _accountRepository, _user), this.Parent);

        }


        //Check if values are empty
        private bool CheckEmpty(string amount, string accNum, string note)
        {
            if (string.IsNullOrEmpty(amount) || string.IsNullOrEmpty(accNum) || string.IsNullOrEmpty(note))
                return true;
            return false;
        }
    }
}
