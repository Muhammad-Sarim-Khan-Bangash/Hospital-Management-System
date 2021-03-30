using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginCheck info = new LoginCheck();
            info.Verify(txtUsername.Text, txtPassword.Text);
        }
    }
}

