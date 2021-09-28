using JohnBankAppADO.NET.Core.Interfaces;
using JohnBankAppADO.NET.Model;
using JohnBankAppADO.NET.UI;
using System;
using System.Windows.Forms;

namespace BankApp.UI.Views.UserControls
{
    public partial class OpenAccount : UserControl
    {
        //Fields
        private readonly User _user;
        private readonly IAccountRepository _accountRepository;
        private readonly IBankOperation _bankOperation;
        private readonly ITransactionRespository _transactionRespository;

        public OpenAccount(IAccountRepository accountRepository, ITransactionRespository transactionRespository, IBankOperation bankOperation, User user)
        {
            _bankOperation = bankOperation;
            _accountRepository = accountRepository;
            _transactionRespository = transactionRespository;
            _user = user;
            InitializeComponent();
        }

        private void OpenAccount_Load(object sender, EventArgs e)
        {
            if (_user.UserAccounts.Count > 1)
            {
                MessageBox.Show("You have 2 accounts already", "Warning", MessageBoxButtons.OK);
                ControlClass.ShowControl(new Dashboard(_transactionRespository, _accountRepository, _user), this.Parent);
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ControlClass.ShowControl(new Dashboard(_transactionRespository, _accountRepository, _user), this.Parent);
        }


        //Open an account
        private void btnOpenAccount_Click(object sender, EventArgs e)
        {
            try
            {
                var amount = Convert.ToDecimal(this.txtInitialDeposit.Text);
                if (_user.UserAccounts[0].AccountType == "savings")
                {
                    if (amount < 0)
                    {
                        throw new Exception("Deposit amount must be greater than zero");
                    }


                    var newAccount = new CurrentAccount();
                    _bankOperation.MakeDeposit(newAccount.AccountNumber.ToString(), amount, "Initial Deposit", "Deposit");
                    _accountRepository.AddAccount(newAccount, _user.Id);
                }
                else
                {
                    if (amount < 1000)
                    {
                        throw new Exception("Minimum deposit for a Savings account is 1000");
                    }

                    var newAccount = new SavingAccount();
                    _bankOperation.MakeDeposit(newAccount.AccountNumber.ToString(), amount, "Initial Deposit", "Deposit");
                    _accountRepository.AddAccount(newAccount, _user.Id);
                }
                MessageBox.Show("Account opening Succesful", "Success", MessageBoxButtons.OK);
                ControlClass.ShowControl(new Dashboard( _transactionRespository,_accountRepository, _user), this.Parent);
            }
            catch(FormatException)
            {
                MessageBox.Show("Please enter a valid amount for initial deposit");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }


        }
    }
}
