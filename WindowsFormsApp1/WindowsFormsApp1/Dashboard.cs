using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Dashboard : Form
    {
        Functionalities Function = new Functionalities();
        private OleDbConnection connection = new OleDbConnection();
        public Dashboard()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\OOP Project\WindowsFormsApp1\Database1.accdb;Persist Security Info=False;";
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {          
            Function.AddPatient(labelIndicator1, labelIndicator2, labelIndicator3, labelIndicator4, panel1, panel2, panel3, panel4);           
        }

        private void btnAddDiagnosis_Click(object sender, EventArgs e)
        {
            Function.AddDiagnosis(labelIndicator1, labelIndicator2, labelIndicator3, labelIndicator4, panel1, panel2, panel3, panel4);   
        }

        private void btnFullHistory_Click(object sender, EventArgs e)
        {
            Function.FullHistory(labelIndicator1, labelIndicator2, labelIndicator3, labelIndicator4, panel1, panel2, panel3, panel4);         
        }

        private void btnHospitalInfo_Click(object sender, EventArgs e)
        {
            Function.HospitalInfo(labelIndicator1, labelIndicator2, labelIndicator3, labelIndicator4, panel1, panel2, panel3, panel4);           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Function.SaveData(txtName, txtAddress, txtContactNumber, txtAge, comboGender, txtBloodGroup, txtAny, txtPID);          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Function.ShowData(textBox1, dataGridView1);          
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Function.SaveOtherInfo(textBox1,  txtSymtoms,  txtDiagnosis,  txtMedicines, comboWardReq, comboWardType);           
        }

        private void btn_ShowHistory_Click(object sender, EventArgs e)
        {
            Function.ShowHistory(dataGridView2);
        }
    }
}

