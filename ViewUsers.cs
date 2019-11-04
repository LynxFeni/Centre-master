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
    public partial class ViewUsers : Form
    {

        string connectionString = ConfigurationManager.ConnectionStrings["XpressionsEntities"].ConnectionString;
        public ViewUsers()
        {
            InitializeComponent();
            refreshdata();
        }

        private void refreshdata()
        {

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from Users", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            staffListView.DataSource = dt;
            staffListView.ReadOnly = true;

        }
        private void StaffListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int ID = Convert.ToInt32(staffListView.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtUsername.Text = staffListView.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtFulName.Text = staffListView.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtLastName.Text = staffListView.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBxRole.Text = staffListView.Rows[e.RowIndex].Cells[5].Value.ToString();
           
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string UserName = txtUsername.Text;
            string FullName = txtFulName.Text;
            string LastName = txtLastName.Text;
            string Password = txtPasword.Text;
            string Role = " ";
            if (comboBxRole.SelectedIndex >= 0)
                Role = comboBxRole.Items[comboBxRole.SelectedIndex].ToString();
            try
            {

                string query = "insert into Users(UserName, FullName, LastName, Password,Role) Values( @UserName, @FullName, @LastName, @Password,@Role)";

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {

                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = query;

                        cmd.Parameters.AddWithValue("@UserName", UserName);
                        cmd.Parameters.AddWithValue("@FullName", FullName);
                        cmd.Parameters.AddWithValue("@LastName", LastName);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@Role", Role);

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("User Successfully added");
                        refreshdata();
                    }

                }
            }
            catch (SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            string Password = txtPasword.Text;
            string UserName = txtUsername.Text;
            string FullName = txtFulName.Text;
            string LastName = txtLastName.Text;

            string query = "UPDATE Users SET Password = @Password where UserName = @UserName";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@FullName", FullName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record Updated Successfully");
                    refreshdata();
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string id = string.Empty;
            string query = "Delete from MemReg where ContractNo = @id";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@ContractNo", id);
                    //cmd.Parameters.AddWithValue("@HomeNo", HomeNo);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record Updated Successfully");
                    this.Close();

                }
            }
        }

        private void TxtFulName_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

