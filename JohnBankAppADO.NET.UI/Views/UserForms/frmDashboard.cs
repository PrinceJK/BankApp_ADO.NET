using BankApp.UI.Views.UserControls;
using JohnBankAppADO.NET.Core.Interfaces;
using JohnBankAppADO.NET.Model;
using JohnBankAppADO.NET.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BankApp.UI
{
    public partial class frmDashboard : Form
    {
        private Button currentButton;
        User _user;
        private readonly IBankOperation _bankOperation;
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRespository _transactionRespository;

        public Panel panelController
        {
            get { return panelContainer; }
            set { panelContainer = value; }
        }

        //Constructor
        public frmDashboard(User user, IBankOperation bankOperation, IAccountRepository accountRepository, ITransactionRespository transactionRespository)
        {
            _user = user;
            _bankOperation = bankOperation;
            _accountRepository = accountRepository;
            _transactionRespository = transactionRespository;
            InitializeComponent();
            
        }


        private void frmDashboard_Load(object sender, EventArgs e)
        {
            this.lblFullname.Text = _user.FullName;
            Dashboard dashboard = new Dashboard(_transactionRespository, _accountRepository, _user);
            dashboard.Dock = DockStyle.Fill;

            panelContainer.Controls.Add(dashboard);
            ControlClass.ShowControl(dashboard, panelController);
        }


        private void ActiveButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = ColorTranslator.FromHtml("#24244F");
                    currentButton.ForeColor = Color.White;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control prevButton in panelMenu.Controls)
            {
                if(prevButton.GetType() == typeof(Button))
                {
                    prevButton.BackColor = Color.FromArgb(34, 36, 49);
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
           /* ActiveButton(sender);
            OpenAccount openAccount = new OpenAccount(_accountRepository, _transactionRespository, _bankOperation, _user);
            ControlClass.ShowControl(openAccount,panelController);*/
        }

        private void btnOpenAccount_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            OpenAccount openAccount = new OpenAccount(_accountRepository, _transactionRespository, _bankOperation, _user);
            panelController.Controls.Clear();
            ControlClass.ShowControl(openAccount, panelController);

        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
             ActiveButton(sender);
            Deposit deposit = new Deposit(_transactionRespository, _bankOperation, _accountRepository, _user);
            ControlClass.ShowControl(deposit, panelController);
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            panelController.Controls.Clear();
            Withdraw withdraw = new Withdraw(_transactionRespository, _bankOperation, _accountRepository, _user);
            ControlClass.ShowControl(withdraw, panelController);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            panelController.Controls.Clear();
            Transfer transfer = new Transfer(_transactionRespository, _bankOperation, _accountRepository, _user);
            ControlClass.ShowControl(transfer, panelController);
        }

        private void btnStatement_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            panelController.Controls.Clear();
            AccountStatement accountStatement = new AccountStatement(_user, _transactionRespository, _accountRepository);
            ControlClass.ShowControl(accountStatement, panelController);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelheader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
