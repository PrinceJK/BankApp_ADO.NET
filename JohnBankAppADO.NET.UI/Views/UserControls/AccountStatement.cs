using JohnBankAppADO.NET.Core.Interfaces;
using JohnBankAppADO.NET.Model;
using JohnBankAppADO.NET.UI;
using System;
using System.Windows.Forms;

namespace BankApp.UI.Views.UserControls
{
    public partial class AccountStatement : UserControl
    {
        
        private readonly ITransactionRespository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        User _user;


        public AccountStatement(User user, ITransactionRespository transactionRepository, IAccountRepository accountRepository)
        {
            _user = user;
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            InitializeComponent();
        }

        private void AccountStatement_Load(object sender, EventArgs e)
        {
            //cboAccounts.Items.Add("");
            foreach (var item in _user.UserAccounts)
            {
                this.cboAccounts.Items.Add(item.AccountNumber);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ControlClass.ShowControl(new Dashboard(_transactionRepository, _accountRepository, _user), this.Parent);
        }

        private void btnViewStatement_Click(object sender, EventArgs e)
        {
            var accountNumber = this.cboAccounts.Text;

            try
            {
                if (string.IsNullOrEmpty(accountNumber))
                {
                    throw new Exception("Please select account to view");
                }

                var accountList = _transactionRepository.GetAllAccountTransactions(accountNumber);


                this.dtgStatement.DataSource = accountList;
                //this.dtgStatement.Columns["AccountNumber"].Visible = false;
                this.dtgStatement.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "warning", MessageBoxButtons.OK);
            }
            

        }
    }
}
