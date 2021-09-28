using JohnBankAppADO.NET.Core.Interfaces;
using JohnBankAppADO.NET.Model;
using JohnBankAppADO.NET.UI;
using System;
using System.Windows.Forms;

namespace BankApp.UI.Views.UserControls
{
    public partial class Transfer : UserControl
    {
        //Injected fields
        private readonly IBankOperation _bankOperation;
        private readonly IAccountRepository _accountRepository;
        private readonly User _user;
        private readonly ITransactionRespository _transactionRepository;

        //Constructor
        public Transfer(ITransactionRespository transactionRespository,IBankOperation bankOperation,IAccountRepository accountRepository,User user)
        {
            _user = user;
            _bankOperation = bankOperation;
            _accountRepository = accountRepository;
            _transactionRepository = transactionRespository;
            InitializeComponent();
        }

        public void AlterDisplay()
        {

        }

        private void rdioInTrans_CheckedChanged(object sender, EventArgs e)
        {
            DisableThirdParty();

            EnableSelfTransfer();

        }

        private void Transfer_Load(object sender, EventArgs e)
        {

           
            cboTransferTo.Items.Add("");
            foreach (var item in _user.UserAccounts)
            {
                this.cboTransferTo.Items.Add(item.AccountNumber);
            }

            cboTransferFrom.Items.Add("");
            foreach (var item in _user.UserAccounts)
            {
                this.cboTransferFrom.Items.Add(item.AccountNumber);
            }

            DisableThirdParty();


            DisableSelfTransfer();

        }

        private void rdioThirdParty_CheckedChanged(object sender, EventArgs e)
        {


            DisableSelfTransfer();

            EnableThirdParty();

        }

        #region Helper
        //Hide the self transfer control
        private void DisableSelfTransfer()
        {
            this.lblTransferTo.Visible = false;
            this.cboTransferTo.Visible = false;
        }

        private void EnableSelfTransfer()
        {
            this.lblTransferTo.Visible = true;
            this.cboTransferTo.Visible = true;
        }

        private void EnableThirdParty()
        {
            this.lblThirdParty.Visible = true;
            this.txtThirdPartyAccNum.Visible = true;
            this.panel4.Visible = true;
        }

        private void DisableThirdParty()
        {
            this.lblThirdParty.Visible = false;
            this.txtThirdPartyAccNum.Visible = false;
            this.panel4.Visible = false;
        }
        #endregion

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                var amount = decimal.Parse(txtAmount.Text);
                var debitedAccount = cboTransferFrom.Text;

                var account = _user.UserAccounts[cboTransferFrom.SelectedIndex - 1];



                if (rdioThirdParty.Checked)
                {

                    #region Check for valid values, Throw exception on invalid
                    
                    if (amount < 1)
                    {
                        throw new Exception("Transfer amount must be greater than 0");
                    }
                    if (amount > account.Balance)
                    {
                        throw new Exception("Insufficient funds");
                    }

                    if (account.Balance - amount < account.MinimumBalance)
                    {
                        throw new Exception("Cannot transafer more than your minimum balance");
                    }

                    if (debitedAccount == txtThirdPartyAccNum.Text)
                    {
                        throw new Exception("Cannot transfer to same account");
                    }

                    if (string.IsNullOrEmpty(txtThirdPartyAccNum.Text))
                    {
                        throw new Exception("Input a valid account number");
                    }
                    #endregion 

                    var creditedAcc = txtThirdPartyAccNum.Text;
                    _bankOperation.MakeTransfer(debitedAccount, creditedAcc, amount);
                    MessageBox.Show("Transfer succesfull", "success", MessageBoxButtons.OK);

                    ControlClass.ShowControl(new Dashboard(_transactionRepository,_accountRepository, _user), this.Parent);

                }
                else if(rdioInTrans.Checked)
                {

                    #region Check for valid values, Throw exception on invalid
                    if (amount < 0)
                    {
                        throw new Exception("Transfer amount must be greater than 0");
                    }

                    if (amount > account.Balance)
                    {
                        throw new Exception("Insufficient funds");
                    }

                    if (amount - account.MinimumBalance < 0)
                    {
                        throw new Exception("Cannot withdraw more than your minimum balance");
                    }
                    if (debitedAccount == cboTransferTo.Text)
                    {
                        throw new Exception("Cannot transfer to same account");
                    }

                    if (string.IsNullOrEmpty(cboTransferTo.Text))
                    {
                        throw new Exception("Input a valid account number");
                    }
                    #endregion


                    var creditedAccount = cboTransferTo.Text;

                    _bankOperation.MakeTransfer(debitedAccount, creditedAccount, amount);
                    MessageBox.Show("Transfer succesfull", "success", MessageBoxButtons.OK);

                    ControlClass.ShowControl(new Dashboard(_transactionRepository,_accountRepository, _user), this.Parent);
                }
                else
                {
                    MessageBox.Show("Please select a transfer type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Please enter a valid input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select an account", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ControlClass.ShowControl(new Dashboard( _transactionRepository,_accountRepository, _user), this.Parent);
        }
    }
}
