
namespace BankApp.UI.Views.UserControls
{
    partial class Transfer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transfer));
            this.cboTransferFrom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTransferFrom = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdioThirdParty = new System.Windows.Forms.RadioButton();
            this.rdioInTrans = new System.Windows.Forms.RadioButton();
            this.cboTransferTo = new System.Windows.Forms.ComboBox();
            this.lblTransferTo = new System.Windows.Forms.Label();
            this.lblThirdParty = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtThirdPartyAccNum = new System.Windows.Forms.TextBox();
            this.lblTransferType = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboTransferFrom
            // 
            this.cboTransferFrom.AllowDrop = true;
            resources.ApplyResources(this.cboTransferFrom, "cboTransferFrom");
            this.cboTransferFrom.FormattingEnabled = true;
            this.cboTransferFrom.Name = "cboTransferFrom";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(3)))), ((int)(((byte)(51)))));
            this.btnTransfer.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnTransfer, "btnTransfer");
            this.btnTransfer.ForeColor = System.Drawing.Color.White;
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.TabStop = false;
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(3)))), ((int)(((byte)(51)))));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabStop = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTransferFrom
            // 
            resources.ApplyResources(this.lblTransferFrom, "lblTransferFrom");
            this.lblTransferFrom.ForeColor = System.Drawing.Color.White;
            this.lblTransferFrom.Name = "lblTransferFrom";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(3)))), ((int)(((byte)(51)))));
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtAmount, "txtAmount");
            this.txtAmount.ForeColor = System.Drawing.Color.White;
            this.txtAmount.HideSelection = false;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdioThirdParty);
            this.panel2.Controls.Add(this.rdioInTrans);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // rdioThirdParty
            // 
            resources.ApplyResources(this.rdioThirdParty, "rdioThirdParty");
            this.rdioThirdParty.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.rdioThirdParty.Name = "rdioThirdParty";
            this.rdioThirdParty.TabStop = true;
            this.rdioThirdParty.UseVisualStyleBackColor = true;
            this.rdioThirdParty.CheckedChanged += new System.EventHandler(this.rdioThirdParty_CheckedChanged);
            // 
            // rdioInTrans
            // 
            resources.ApplyResources(this.rdioInTrans, "rdioInTrans");
            this.rdioInTrans.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.rdioInTrans.Name = "rdioInTrans";
            this.rdioInTrans.TabStop = true;
            this.rdioInTrans.UseVisualStyleBackColor = true;
            this.rdioInTrans.CheckedChanged += new System.EventHandler(this.rdioInTrans_CheckedChanged);
            // 
            // cboTransferTo
            // 
            this.cboTransferTo.AllowDrop = true;
            resources.ApplyResources(this.cboTransferTo, "cboTransferTo");
            this.cboTransferTo.FormattingEnabled = true;
            this.cboTransferTo.Name = "cboTransferTo";
            // 
            // lblTransferTo
            // 
            resources.ApplyResources(this.lblTransferTo, "lblTransferTo");
            this.lblTransferTo.ForeColor = System.Drawing.Color.White;
            this.lblTransferTo.Name = "lblTransferTo";
            // 
            // lblThirdParty
            // 
            resources.ApplyResources(this.lblThirdParty, "lblThirdParty");
            this.lblThirdParty.ForeColor = System.Drawing.Color.White;
            this.lblThirdParty.Name = "lblThirdParty";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // txtThirdPartyAccNum
            // 
            this.txtThirdPartyAccNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(3)))), ((int)(((byte)(51)))));
            this.txtThirdPartyAccNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtThirdPartyAccNum, "txtThirdPartyAccNum");
            this.txtThirdPartyAccNum.ForeColor = System.Drawing.Color.White;
            this.txtThirdPartyAccNum.HideSelection = false;
            this.txtThirdPartyAccNum.Name = "txtThirdPartyAccNum";
            this.txtThirdPartyAccNum.TabStop = false;
            // 
            // lblTransferType
            // 
            resources.ApplyResources(this.lblTransferType, "lblTransferType");
            this.lblTransferType.ForeColor = System.Drawing.Color.White;
            this.lblTransferType.Name = "lblTransferType";
            // 
            // Transfer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(3)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.txtThirdPartyAccNum);
            this.Controls.Add(this.lblThirdParty);
            this.Controls.Add(this.cboTransferTo);
            this.Controls.Add(this.lblTransferTo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cboTransferFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTransferType);
            this.Controls.Add(this.lblTransferFrom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Name = "Transfer";
            this.Load += new System.EventHandler(this.Transfer_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTransferFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTransferFrom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdioThirdParty;
        private System.Windows.Forms.RadioButton rdioInTrans;
        private System.Windows.Forms.ComboBox cboTransferTo;
        private System.Windows.Forms.Label lblTransferTo;
        private System.Windows.Forms.Label lblThirdParty;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtThirdPartyAccNum;
        private System.Windows.Forms.Label lblTransferType;
    }
}
