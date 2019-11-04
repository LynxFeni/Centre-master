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
    public partial class Login : Form
    {

        string connectionString = ConfigurationManager.ConnectionStrings["XpressionsEntities"].ConnectionString;
        SqlDataReader reader;
        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

           
            
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("Select * from Users where UserName=@UserName and Password=@Password", con);
                con.Open();
                cmd.Parameters.AddWithValue("@UserName", txtBoxUsername.Text.ToString());
                cmd.Parameters.AddWithValue("@Password", textboxPassword.Text.ToString());
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Password"].ToString().Equals(textboxPassword.Text.ToString(), StringComparison.InvariantCulture) && reader["ROLE"].ToString().Equals("Admin"))
                    {

                        Dashboard dash = new Dashboard();
                        dash.Show();
                        this.Hide();
                    }
                    else
                    {
                        DashboardUsers dash = new DashboardUsers();
                        dash.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password, Please try again");
                }
                reader.Close();
                cmd.Dispose();
                con.Close();
            }
            catch (SqlException ex)
            {
                string msg = "Login Error:";
                msg += ex.Message;
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
        
    

