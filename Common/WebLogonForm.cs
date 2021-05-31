using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace Pronto.Common
{
    public partial class WebLogonForm : Form
    {
        List<LoginDetails> loginTypes = new List<LoginDetails>();
        

      public  LoginType loginMode
        {
            get
            {
                LoginDetails curLogin = (LoginDetails)UserCombo.SelectedItem;
                if(curLogin != null)
                {
                    return curLogin.loginType;
                }
                else
                { return LoginType.User; }
            }
        }

        public WebLogonForm(string Message = null)
        {
            InitializeComponent();
            if(!string.IsNullOrEmpty(Message))
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = Message;
            }

            //loginTypes.Add(new LoginDetails() { loginType = LoginType.Admin, Password = "Administrator@#" });
            //loginTypes.Add(new LoginDetails() { loginType = LoginType.User, Password = "User1#@" });

            
        }

        private void WebAuth_Load(object sender, EventArgs e)
        {
//#if DEBUG
//            txtPassword.Text = "Administrator@#";
//#endif
            loginTypes = DataAccessFactory.GetUserList();
            this.ActiveControl = txtPassword;
            UserCombo.DataSource = loginTypes;
            UserCombo.DisplayMember = "UserName";
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text.Trim()) || string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
                btnLogin.Enabled = false;
            if (!string.IsNullOrWhiteSpace(txtPassword.Text.Trim()) && !string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
                btnLogin.Enabled = true;
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text.Trim()) || string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
                btnLogin.Enabled = false;
            if (!string.IsNullOrWhiteSpace(txtPassword.Text.Trim()) && !string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
                btnLogin.Enabled = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginDetails curLogin = (LoginDetails)UserCombo.SelectedItem;
            if (txtPassword.Text == curLogin.Password)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                lblErrorMsg.Visible = true;
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
