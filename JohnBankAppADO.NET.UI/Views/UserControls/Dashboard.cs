using JohnBankAppADO.NET.Core.Interfaces;
using JohnBankAppADO.NET.Model;
using System;
using System.Windows.Forms;

namespace BankApp.UI
{
    public partial class Dashboard : UserControl
    {
        //Fields
        private readonly IAccountRepository _accountRepository;
        private readonly User _user;
        private readonly ITransactionRespository _transactionRespository;
        public Dashboard(ITransactionRespository transactionRepository, IAccountRepository accountRepository,User user)
        {
            _accountRepository = accountRepository;
            _transactionRespository = transactionRepository;
            _user = user;
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            _user.UserAccounts = _accountRepository.GetAUserAccounts(_user.Id);
            if (_user.UserAccounts.Count > 1)
            {
                foreach (var item in _user.UserAccounts)
                {
                    if (item.AccountType == "savings")
                    {
                        this.lblSaveAccNo.Text = item.AccountNumber.ToString();
                        this.lblSavingsBal.Text = _accountRepository.GetAccountByAccountNumber(item.AccountNumber).Balance.ToString();
                    }

                    if (item.AccountType == "current")
                    {
                        this.lblCurrentAccNo.Text = item.AccountNumber.ToString();
                        this.lblCurrentBal.Text = _accountRepository.GetAccountByAccountNumber(item.AccountNumber).Balance.ToString();
                    }
                }
            }
            else
            {

                if (_user.UserAccounts[0].AccountType == "savings")
                {
                    HideCurrent();

                    this.lblSaveAccNo.Text = _user.UserAccounts[0].AccountNumber.ToString();
                    this.lblSavingsBal.Text = _accountRepository.GetAccountByAccountNumber(_user.UserAccounts[0].AccountNumber).Balance.ToString();

                }

                if (_user.UserAccounts[0].AccountType == "current")
                {
                    HideSavings();

                    this.lblCurrentAccNo.Text = _user.UserAccounts[0].AccountNumber.ToString();
                    this.lblCurrentBal.Text = _accountRepository.GetAccountByAccountNumber(_user.UserAccounts[0].AccountNumber).Balance.ToString();
                }

            }

            try
            {
                if(_user.UserAccounts.Count> 1)
                {
                    var accountList = _transactionRespository.GetRecentTransactions(_user.UserAccounts[0].AccountNumber, _user.UserAccounts[1].AccountNumber);
                    this.transactionsGrid.DataSource = accountList;
                    this.transactionsGrid.Columns["AccountNumber"].Visible = false;
                    this.transactionsGrid.Columns["Id"].Visible = false;
                }
               

            }
            catch (NullReferenceException ex)
            {

                MessageBox.Show(ex.Message, "warning",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void HideCurrent()
        {
            this.lblCurrentBal.Visible = false;
            this.lblCurrentAccNo.Visible = false;
            this.crtBalLbl.Visible = false;
            this.crtNumLbl.Visible = false;
        }
        private void HideSavings()
        {
            this.lblSaveAccNo.Visible = false;
            this.lblSavingsBal.Visible = false;
            this.savBalLba.Visible = false;
            this.savinAcLbl.Visible = false;
        }

        private void lblSaveAccNo_Click(object sender, EventArgs e)
        {

        }

        private void lblSavingsBal_Click(object sender, EventArgs e)
        {

        }
    }
}
