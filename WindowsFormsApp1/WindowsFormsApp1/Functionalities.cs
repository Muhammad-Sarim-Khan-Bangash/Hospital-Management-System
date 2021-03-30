using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    class Functionalities
    {
        private OleDbConnection connection = new OleDbConnection();

        public void AddPatient(Label labelIndicator1, Label labelIndicator2, Label labelIndicator3, Label labelIndicator4, Panel panel1, Panel panel2, Panel panel3, Panel panel4)
        { 
            labelIndicator1.ForeColor = System.Drawing.Color.Green;
            labelIndicator2.ForeColor = System.Drawing.Color.Black;
            labelIndicator3.ForeColor = System.Drawing.Color.Black;
            labelIndicator4.ForeColor = System.Drawing.Color.Black;

            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }
        public void AddDiagnosis(Label labelIndicator1, Label labelIndicator2, Label labelIndicator3, Label labelIndicator4, Panel panel1, Panel panel2, Panel panel3, Panel panel4)
        {
            labelIndicator2.ForeColor = System.Drawing.Color.Green;
            labelIndicator1.ForeColor = System.Drawing.Color.Black;
            labelIndicator3.ForeColor = System.Drawing.Color.Black;
            labelIndicator4.ForeColor = System.Drawing.Color.Black;

            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
        }
        public void FullHistory(Label labelIndicator1, Label labelIndicator2, Label labelIndicator3, Label labelIndicator4, Panel panel1, Panel panel2, Panel panel3, Panel panel4)
        {
            labelIndicator3.ForeColor = System.Drawing.Color.Green;
            labelIndicator1.ForeColor = System.Drawing.Color.Black;
            labelIndicator2.ForeColor = System.Drawing.Color.Black;
            labelIndicator4.ForeColor = System.Drawing.Color.Black;

            panel3.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
        }
        public void HospitalInfo(Label labelIndicator1, Label labelIndicator2, Label labelIndicator3, Label labelIndicator4, Panel panel1, Panel panel2, Panel panel3, Panel panel4)
        {
            labelIndicator4.ForeColor = System.Drawing.Color.Green;
            labelIndicator1.ForeColor = System.Drawing.Color.Black;
            labelIndicator2.ForeColor = System.Drawing.Color.Black;
            labelIndicator3.ForeColor = System.Drawing.Color.Black;

            panel4.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }
        public void SaveData(TextBox Name, TextBox Address, TextBox ContactNo, TextBox Age, ComboBox comboGender, TextBox BloodGroup, TextBox Any, TextBox PID)
        {
            try
            {
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\OOP Project\WindowsFormsApp1\Database1.accdb;Persist Security Info=False;";

                if (Name.Text != "" && Address.Text != "" && ContactNo.Text != "" && Age.Text != "" && comboGender.Text != "" && BloodGroup.Text != "" && Any.Text != "" && PID.Text != "")
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "insert into Patients_Info([Name],[Address],[Contact],[Age],[Gender], [Blood_Group],[Major_Disease],[Pid]) values('" + Name.Text + "','" + Address.Text + "','" + ContactNo.Text + "','" + Age.Text + "','" + comboGender.Text + "','" + BloodGroup.Text + "','" + Any.Text + "','" + PID.Text + "')";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data has been Save", "Database",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Please Fill All the Fields", "Erorr",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            Name.Clear();
            Address.Clear();
            ContactNo.Clear();
            Age.Clear();
            BloodGroup.Clear();
            Any.Clear();
            PID.Clear();
            comboGender.ResetText();

            connection.Close();
        }
        public void ShowData(TextBox textBox1, DataGridView dataGridView1)
        {
            if (textBox1.Text != "")
            {
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\OOP Project\WindowsFormsApp1\Database1.accdb;Persist Security Info=False;";

                int pid = Convert.ToInt32(textBox1.Text);
               
                connection.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * from Patients_Info where Pid='" + pid + "'";
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
                connection.Close();
            }
            else
            {
                MessageBox.Show("Kindly Enter Pid..", "Required Field",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Exclamation);
            }
        }
        public void SaveOtherInfo(TextBox textBox1, TextBox txtSymtoms, TextBox txtDiagnosis, TextBox txtMedicines, ComboBox comboWardReq, ComboBox comboWardType)
        {
            try
            {
                if (textBox1.Text != "" && txtSymtoms.Text != "" && txtDiagnosis.Text != "" && txtMedicines.Text != "" && comboWardReq.Text != "" && comboWardType.Text != "")
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "insert into Patient_MoreInfo([Pid],[Symtoms],[Diagnosis],[Medicines],[Ward], [Ward_Type]) values('" + textBox1.Text + "','" + txtSymtoms.Text + "','" + txtDiagnosis.Text + "','" + txtMedicines.Text + "','" + comboWardReq.Text + "','" + comboWardType.Text + "')";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data has been Save into the Database", "Database",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Please Fill All the Fields", "Erorr",
                       MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            txtSymtoms.Clear();
            txtDiagnosis.Clear();
            txtMedicines.Clear();
            comboWardReq.ResetText();
            comboWardType.ResetText();
        }
        public void ShowHistory(DataGridView dataGridView2)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\OOP Project\WindowsFormsApp1\Database1.accdb;Persist Security Info=False;";
            connection.Open();
            OleDbCommand command = new OleDbCommand("select * from Patients_Info", connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView2.DataSource = dt;
            connection.Close();
        }
    }
}

