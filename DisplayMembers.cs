using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DisplayMembers : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["XpressionsEntities"].ConnectionString;

        public DisplayMembers()
        {
            InitializeComponent();
            refreshdata();
        }

        private void refreshdata()
        {

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from MemReg", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;

        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ContractNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ContractNo"].Value.ToString());

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from MemReg Where ContractNo = " + ContractNo + " ";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            using (EditOrDelete member = new EditOrDelete())
            {

                member.txtContractNo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                member.txtFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                member.txtLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                member.txtIDNo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                member.txtGender.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                member.txtHomeNo.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                member.txtWorkNo.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                member.txtCellNo.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                member.rTxtAdress.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                member.txtMembershipType.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                member.txtStartDate.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                member.txtEndDate.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                member.txtBankName.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                member.txtBranchCode.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                member.txtAccountNo.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                member.txtAccountType.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
                member.txtDOD.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
                member.txtBxnxtOfkeenName.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
                member.txtbxNexofkeenSurname.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
                member.txtbxNxtofkeenNo.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();
                member.txtbxRelationship.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
                member.txtPayerID.Text = dataGridView1.CurrentRow.Cells[22].Value.ToString();
                member.txtPayerName.Text = dataGridView1.CurrentRow.Cells[23].Value.ToString();
                member.txtPayerSurname.Text = dataGridView1.CurrentRow.Cells[24].Value.ToString();
                member.txtContactNoPayer.Text = dataGridView1.CurrentRow.Cells[25].Value.ToString();

                member.ShowDialog();



            }

        }
        private void TxtID_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("Select * from MemReg Where idNo like '" + txtBoxIDNO.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
