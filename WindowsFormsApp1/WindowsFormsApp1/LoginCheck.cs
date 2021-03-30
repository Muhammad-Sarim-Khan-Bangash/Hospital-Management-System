using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    class LoginCheck
    {
        private OleDbConnection connection = new OleDbConnection();
        public void Verify(string username, string password)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\OOP Project\WindowsFormsApp1\Database1.accdb;Persist Security Info=False;";

            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * from LoginDB where UserName='" + username + "' and Password ='" + password + "'";
            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                WindowsFormsApp1.LoginPage.ActiveForm.Hide();
                Dashboard db = new Dashboard();
                db.Show();
            }
            else
            {
                MessageBox.Show("Username OR Password is Incorrect", "Invalid Login",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error);
            }
            connection.Close();
        }
    }
}

