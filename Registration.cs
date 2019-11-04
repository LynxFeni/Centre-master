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
    public partial class Registration : Form
    {
        OpenFileDialog fd1 = new OpenFileDialog();
        string connectionString = ConfigurationManager.ConnectionStrings["XpressionsEntities"].ConnectionString;
        SqlDataReader reader;

        public Registration()
        {
            InitializeComponent();
            comboFill();

            Application.DoEvents();
            {
                pnlBanking.Visible = false;
                PnlNextOfKeen.Visible = false;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            

            string MemberFName = txtFirstName.Text;
            string MemberLName = txtLastName.Text;
            string idNo = txtIDNo.Text;

            string Gender = "";
            if (comboBoxGender.SelectedIndex >= 0)
                Gender = comboBoxGender.Items[comboBoxGender.SelectedIndex].ToString();

            string MembershipType = "";
            if (comboBoxMemberType.SelectedIndex >= 0)
                MembershipType = comboBoxMemberType.Items[comboBoxMemberType.SelectedIndex].ToString();

            string HomeNo = txtHomeNo.Text;
            string WorkNo = txtWorkNo.Text;
            string CellNo = txtCellNo.Text;
            string Ad = rTxtAdress.Text;
            DateTime StartDate = dtPkStartDate.Value;
            DateTime EndDate = dtPkEndDate.Value;
            string Bankname = "";
            if (comboBxBank.SelectedIndex >= 0)
                Bankname = comboBxBank.Items[comboBxBank.SelectedIndex].ToString();
            string BranchCode = txtBxBranchCode.Text;
            string AccountType = "";
            if (comboBoxAccountType.SelectedIndex >= 0)
                AccountType = comboBoxAccountType.Items[comboBoxAccountType.SelectedIndex].ToString();
            string AccountNo = txtBxAccountNo.Text;
            string DODate = dateTimePickerdod.Text;

            string NameNextOfkeen = txtBxnxtOfkeenName.Text;
            string SurnamenextOfkeen = txtbxNexofkeenSurname.Text;
            string Relationship = txtbxRelationship.Text;
            string ContactNoNextOfkeen = txtbxNxtofkeenNo.Text;

            string PayerID = txtPayerID.Text;
            string PayerName = txtPayerName.Text;
            string PayerSurname = txtPayerSurname.Text;
            string ContactNoPayer = txtContactNoPayer.Text;
            string Barcode = txtBxBarcode.Text;

            string image = txtPicture.Text;
            Bitmap bmp = new Bitmap(image);
            FileStream fs = new FileStream(image, FileMode.Open, FileAccess.Read);
            byte[] Picture = new byte[fs.Length];
            fs.Read(Picture, 0, Convert.ToInt32(fs.Length));


            try
            {
              
                string query = "insert into MemReg(MemberFName,MemberLName,idNo,Gender,HomeNo,WorkNo,CellNo,Ad,MembershipType,StartDate,EndDate,Bankname,BranchCode,AccountNo,AccountType,DODate,NameNextOfkeen,SurnamenextOfkeen,Relationship,ContactNoNextOfkeen,PayerID,PayerName,PayerSurname,ContactNoPayer,Barcode, Picture) Values( @MemberFName,@MemberLName,@idNo,@Gender,@HomeNo,@WorkNo,@CellNo,@Ad,@MembershipType,@StartDate,@EndDate,@Bankname,@BranchCode,@AccountNo,@AccountType,@DODate,@NameNextOfkeen,@SurnamenextOfkeen,@Relationship,@ContactNoNextOfkeen,@PayerID,@PayerName,@PayerSurname,@ContactNoPayer,@Barcode,@Picture)";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = query;

                        cmd.Parameters.AddWithValue("@MemberFName", MemberFName);
                        cmd.Parameters.AddWithValue("@MemberLName", MemberLName);
                        cmd.Parameters.AddWithValue("@idNo", idNo);
                        cmd.Parameters.AddWithValue("@Gender", Gender);
                        cmd.Parameters.AddWithValue("@HomeNo", HomeNo);
                        cmd.Parameters.AddWithValue("@WorkNo", WorkNo);
                        cmd.Parameters.AddWithValue("@CellNo", CellNo);
                        cmd.Parameters.AddWithValue("@Ad", Ad);
                        cmd.Parameters.AddWithValue("@MembershipType", MembershipType);
                        cmd.Parameters.AddWithValue("@StartDate", StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", EndDate);
                        cmd.Parameters.AddWithValue("@Bankname", Bankname);
                        cmd.Parameters.AddWithValue("@BranchCode", BranchCode);
                        cmd.Parameters.AddWithValue("@AccountNo", AccountNo);
                        cmd.Parameters.AddWithValue("@AccountType", AccountType);
                        cmd.Parameters.AddWithValue("@DODate", DODate);
                        cmd.Parameters.AddWithValue("@NameNextOfkeen", NameNextOfkeen);
                        cmd.Parameters.AddWithValue("@SurnamenextOfkeen", SurnamenextOfkeen);
                        cmd.Parameters.AddWithValue("@Relationship", Relationship);
                        cmd.Parameters.AddWithValue("@ContactNoNextOfkeen", ContactNoNextOfkeen);
                        cmd.Parameters.AddWithValue("@PayerID", PayerID);
                        cmd.Parameters.AddWithValue("@PayerName", PayerName);
                        cmd.Parameters.AddWithValue("@PayerSurname", PayerSurname);
                        cmd.Parameters.AddWithValue("@ContactNoPayer", ContactNoPayer);
                        cmd.Parameters.AddWithValue("@Barcode", Barcode);
                        cmd.Parameters.AddWithValue("@Picture", Picture);


                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                MessageBox.Show("Member Successfully added");
            }
            catch (SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
            }
        }
        private void DtPkStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtPkStartDate.Format = DateTimePickerFormat.Custom;
            dtPkStartDate.CustomFormat = "dd/MM/yyyy";
        }

        private void DtPkEndDate_ValueChanged(object sender, EventArgs e)
        {
            dtPkEndDate.Format = DateTimePickerFormat.Custom;
            dtPkEndDate.CustomFormat = "dd/MM/yyyy";
        }

        private void RdBtnBanking_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnBanking.Checked)
            {
                pnlBanking.Visible = true;
                PnlNextOfKeen.Visible = false;
            }
            else if (rdBtnPayerDetails.Checked)
            {
                pnlBanking.Visible = true;
                PnlNextOfKeen.Visible = true;
            }
            else
            {
                pnlBanking.Visible = false;
                PnlNextOfKeen.Visible = false;
            }
        }

        private void ComboBoxMemberType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void comboFill()
        {
           
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("select * from MembershipType", con);
                con.Open();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxMemberType.Items.Add(reader["MembershipType"].ToString());
                }
            }
            catch { }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtPicture.Text = open.FileName;
            }

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RdBtnBanking_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdBtnBanking.Checked)
            {
                pnlBanking.Visible = true;
                PnlNextOfKeen.Visible = false;
            }
            else if (rdBtnPayerDetails.Checked)
            {
                pnlBanking.Visible = true;
                PnlNextOfKeen.Visible = true;
            }
            else
            {
                pnlBanking.Visible = false;
                PnlNextOfKeen.Visible = false;
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtPicture.Text = open.FileName;
            }
        }

        private void ComboBoxMemberType_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
