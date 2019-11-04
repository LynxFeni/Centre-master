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
    public partial class MembershipType : Form
    {

        string connectionString = ConfigurationManager.ConnectionStrings["XpressionsEntities"].ConnectionString;

        public MembershipType()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string MembershipType = txtMemType.Text;

            try
            {
                string query = "insert into MembershipType(MembershipType ) Values( @MembershipType)";

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {

                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = query;

                        cmd.Parameters.AddWithValue("@MembershipType", MembershipType);

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("User Successfully added");
                        this.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
            }
        }
    }
}
