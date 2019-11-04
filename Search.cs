using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Search : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["XpressionsEntities"].ConnectionString;
        SqlDataReader reader;
        public Search()
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

            ViewSearchGrid.DataSource = dt;
            con.Close();

        }


        private void TxtBxName_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from MemReg Where MemberFName like '" + txtBxName.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ViewSearchGrid.DataSource = dt;
            con.Close();
        }

        private void TxtBxID_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from MemReg Where idNo like '" + txtBxID.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ViewSearchGrid.DataSource = dt;
            con.Close();
        }

        private void TxtBxSurname_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from MemReg Where MemberLName like '" + txtBxSurname.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ViewSearchGrid.DataSource = dt;
            con.Close();
        }

        private void TxtBxCellNo_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from MemReg Where CellNo like '" + txtBxCellNo.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ViewSearchGrid.DataSource = dt;
            con.Close();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewSearchGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int ContractNo = Convert.ToInt32(ViewSearchGrid.Rows[e.RowIndex].Cells["ContractNo"].Value.ToString());

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from MemReg Where ContractNo = " + ContractNo + " ";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);

            using (MemberAccess member = new MemberAccess())
            {

                member.txtBxContractNo.Text = ViewSearchGrid.CurrentRow.Cells[0].Value.ToString();
                member.txtBxFirstName.Text = ViewSearchGrid.CurrentRow.Cells[1].Value.ToString();
                member.txtSurname.Text = ViewSearchGrid.CurrentRow.Cells[2].Value.ToString();
                member.txtBxID.Text = ViewSearchGrid.CurrentRow.Cells[3].Value.ToString();
                member.txtBxHomeNo.Text = ViewSearchGrid.CurrentRow.Cells[6].Value.ToString();
                member.txtBxWorkNo.Text = ViewSearchGrid.CurrentRow.Cells[7].Value.ToString();
                member.txtBxCellNo.Text = ViewSearchGrid.CurrentRow.Cells[8].Value.ToString();

                member.txtBxAddress.Text = ViewSearchGrid.CurrentRow.Cells[9].Value.ToString();
                member.txtBoxMembershiptype.Text = ViewSearchGrid.CurrentRow.Cells[10].Value.ToString();
                member.txtBxStartDate.Text = ViewSearchGrid.CurrentRow.Cells[11].Value.ToString();
                member.txtBxEndDate.Text = ViewSearchGrid.CurrentRow.Cells[12].Value.ToString();
                if (reader.Read())
                {

                    if (reader["ContractNo"].ToString().Equals(member.txtBxContractNo.Text, StringComparison.InvariantCulture))
                    {
                        MemoryStream ms = new MemoryStream((byte[])reader["Picture"]);
                        member.pictureBox2.Image = new Bitmap(ms);
                    }
                }
                member.ShowDialog();



            }
            con.Close();
        }

        private void TxtBxID_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void ViewSearchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ContractNo = Convert.ToInt32(ViewSearchGrid.Rows[e.RowIndex].Cells["ContractNo"].Value.ToString());

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from MemReg Where ContractNo = " + ContractNo + " ";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);

            using (MemberAccess member = new MemberAccess())
            {

                member.txtBxContractNo.Text = ViewSearchGrid.CurrentRow.Cells[0].Value.ToString();
                member.txtBxFirstName.Text = ViewSearchGrid.CurrentRow.Cells[1].Value.ToString();
                member.txtSurname.Text = ViewSearchGrid.CurrentRow.Cells[2].Value.ToString();
                member.txtBxID.Text = ViewSearchGrid.CurrentRow.Cells[3].Value.ToString();
                member.txtBxHomeNo.Text = ViewSearchGrid.CurrentRow.Cells[6].Value.ToString();
                member.txtBxWorkNo.Text = ViewSearchGrid.CurrentRow.Cells[7].Value.ToString();
                member.txtBxCellNo.Text = ViewSearchGrid.CurrentRow.Cells[8].Value.ToString();

                member.txtBxAddress.Text = ViewSearchGrid.CurrentRow.Cells[9].Value.ToString();
                member.txtBoxMembershiptype.Text = ViewSearchGrid.CurrentRow.Cells[10].Value.ToString();
                member.txtBxStartDate.Text = ViewSearchGrid.CurrentRow.Cells[11].Value.ToString();
                member.txtBxEndDate.Text = ViewSearchGrid.CurrentRow.Cells[12].Value.ToString();
                if (reader.Read())
                {

                    if (reader["ContractNo"].ToString().Equals(member.txtBxContractNo.Text, StringComparison.InvariantCulture))
                    {
                        MemoryStream ms = new MemoryStream((byte[])reader["Picture"]);
                        member.pictureBox2.Image = new Bitmap(ms);
                    }
                }
                member.ShowDialog();



            }
            con.Close();
        }
    }

}
