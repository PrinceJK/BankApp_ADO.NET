using JohnBankAppADO.NET.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JohnBankAppADO.NET.UI
{
    public class ControlClass
    {
        private readonly IAccountRepository _accountRepository;

        public ControlClass(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public static void ShowControl(Control control, Control content)
        {
            content.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Focus();

            content.Controls.Add(control);
        }
    }
}
