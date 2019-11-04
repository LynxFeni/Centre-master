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
    public partial class Access : Form
    {

        string connectionString = ConfigurationManager.ConnectionStrings["XpressionsEntities"].ConnectionString;
        SqlDataReader reader;
        public Access()
        {
            InitializeComponent();
        }

        private void BtnAcess_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBarcode.Text))
            {
                MessageBox.Show("Please scan or enter barcode");
            }
            else
            {

                string Barcode = txtBarcode.Text;
                
                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                string query = "Select * from MemReg where Barcode = " + Barcode + " ";

                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();


                using (AccessView mem = new AccessView())
                {

                    if (reader.Read())
                    {

                        if (reader["Barcode"].ToString().Equals(txtBarcode.Text.ToString(), StringComparison.InvariantCulture))

                        mem.txtBxContractNo.Text = (reader["ContractNo"].ToString());
                        mem.txtBxFirstName.Text = reader["MemberFName"].ToString();
                        mem.txtSurname.Text = (reader["MemberLName"].ToString());
                        mem.txtBxID.Text = (reader["idNo"].ToString());
                        mem.txtBxCellNo.Text = (reader["CellNo"].ToString());
                        mem.txtBxStartDate.Text = (reader["StartDate"].ToString());
                        mem.txtBxEndDate.Text = (reader["EndDate"].ToString());

                        MemoryStream ms = new MemoryStream((byte[])reader["Picture"]);
                        mem.picPictureBox.Image = new Bitmap(ms);

                        mem.ShowDialog();
                    }

                }

                con.Close();
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
