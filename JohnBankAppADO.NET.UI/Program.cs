using JohnBankAppADO.NET.UI.Views.UserForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JohnBankAppADO.NET.UI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GlobalConfig.AddInstance();
            var authenticationInstance = GlobalConfig.Authentication;
            var bankOperationInstance = GlobalConfig.BankOperation;
            var accountRepositoryInstance = GlobalConfig.AccountRepository;
            var transactionRepositoryInstance = GlobalConfig.TransactionRespository;
           // var userResponsitoryInstance = GlobalConfig.UserRepository;
            Application.Run(new frmLogin(authenticationInstance, bankOperationInstance, accountRepositoryInstance, transactionRepositoryInstance));
            //Application.Run(new Form1());
        }
    }
}
