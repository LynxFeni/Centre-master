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
   
    public partial class AccessView : Form
    {

        private int a = 0;
        string connectionString = ConfigurationManager.ConnectionStrings["XpressionsEntities"].ConnectionString;

        public AccessView()
        {
            InitializeComponent();
            txtBoxVisits.Text = this.a.ToString("D5");
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            a++;
            txtBoxVisits.Text = this.a.ToString("");
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

        private void PicPictureBox_Click(object sender, EventArgs e)
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
                picPictureBox.Image = new Bitmap(ms);
            }
            con.Close();
        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
