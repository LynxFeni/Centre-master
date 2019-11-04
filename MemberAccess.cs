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
    public partial class MemberAccess : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["XpressionsEntities"].ConnectionString;

        public MemberAccess()
        {
            InitializeComponent();
        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnAccess_Click(object sender, EventArgs e)
        {
            //string Note = comboBoxNotes.Text;
            string Note = "";
            if (comboBoxNotes.SelectedIndex >= 0)
                Note = comboBoxNotes.Items[comboBoxNotes.SelectedIndex].ToString();

            string ContractNo = txtBxContractNo.Text;
            string FirstName = txtBxFirstName.Text;
            string LastName = txtSurname.Text;
            string ID = txtBxID.Text;



            try
            {

                string query = "insert into MembershipType(FirstName,LastName,ID,Note) Values(@FirstName,@LastName,@ID,@Note)";

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {

                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = query;

                        cmd.Parameters.AddWithValue("@FirstName", FirstName);
                        cmd.Parameters.AddWithValue("@LastName", LastName);
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@Note", Note);


                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                }

                MessageBox.Show("Access Granted");
                this.Close();
            }
            catch (SqlException ex)
            {
                string msg = "Error,Please try again:";
                msg += ex.Message;
            }
        }
        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public Image Base64ToImage(string base64String)
        {

            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
            imageBytes.Length);

            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "Select * From MemReg where idNo ='" + txtBxID + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count < 0)
            {
                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["Picture"]);
                pictureBox2.Image = new Bitmap(ms);
            }
            con.Close();
        }

        private void MemberAccess_Load(object sender, EventArgs e)
        {

        }
    }
}

