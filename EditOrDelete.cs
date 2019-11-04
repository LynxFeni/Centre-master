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
    public partial class EditOrDelete : Form
    {

        string connectionString = ConfigurationManager.ConnectionStrings["XpressionsEntities"].ConnectionString;
        public EditOrDelete()
        {
            InitializeComponent();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

            string HomeNo = txtHomeNo.Text;
            string ContractNo = txtContractNo.Text;
            string WorkNo = txtWorkNo.Text;
            string CellNo = txtCellNo.Text;
            string Ad = rTxtAdress.Text;
            string MembershipType = txtMembershipType.Text;
            string Bankname = txtBankName.Text;
            string BranchCode = txtBranchCode.Text;
            string AccountNo = txtAccountNo.Text;
            string AccountType = txtAccountType.Text;
            string DODate = txtDOD.Text;
            string NameNextOfkeen = txtBxnxtOfkeenName.Text;
            string SurnamenextOfkeen = txtbxNexofkeenSurname.Text;
            string Relationship = txtbxRelationship.Text;
            string ContactNoNextOfkeen = txtbxNxtofkeenNo.Text;


            string query = "UPDATE MemReg SET HomeNo = @HomeNo, WorkNo = @WorkNo, CellNo = @CellNo,Ad = @Ad,MembershipType = @MembershipType,Bankname = @Bankname, BranchCode = @BranchCode,AccountNo = @AccountNo,DODate = @DODate,NameNextOfkeen = @NameNextOfkeen,SurnamenextOfkeen = @SurnamenextOfkeen,Relationship = @Relationship,ContactNoNextOfkeen = @ContactNoNextOfkeen where ContractNo = @ContractNo";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {

                     cmd.Connection = cn;
                     cmd.CommandType = CommandType.Text;
                     cmd.CommandText = query;
                     cmd.Parameters.AddWithValue("@ContractNo", ContractNo);
                     cmd.Parameters.AddWithValue("@HomeNo", HomeNo);
                     cmd.Parameters.AddWithValue("@WorkNo", WorkNo);
                     cmd.Parameters.AddWithValue("@CellNo", CellNo);
                     cmd.Parameters.AddWithValue("@Ad", Ad);
                     cmd.Parameters.AddWithValue("@MembershipType", MembershipType);
                     cmd.Parameters.AddWithValue("@Bankname", Bankname);
                     cmd.Parameters.AddWithValue("@BranchCode", BranchCode);
                     cmd.Parameters.AddWithValue("@AccountNo", AccountNo);
                     cmd.Parameters.AddWithValue("@AccountType", AccountType);
                     cmd.Parameters.AddWithValue("@DODate", DODate);
                     cmd.Parameters.AddWithValue("@NameNextOfkeen", NameNextOfkeen);
                     cmd.Parameters.AddWithValue("@SurnamenextOfkeen", SurnamenextOfkeen);
                     cmd.Parameters.AddWithValue("@Relationship", Relationship);
                     cmd.Parameters.AddWithValue("@ContactNoNextOfkeen", ContactNoNextOfkeen);
                     
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record Updated Successfully");
                    this.Close();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnDelete_Click_1(object sender, EventArgs e)
        {
            string ContractNo = txtContractNo.Text;

            string query = "Delete from MemReg where ContractNo = @ContractNo";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {

                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@ContractNo", ContractNo);


                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record Updated Successfully");
                    this.Close();

                }
            }
        }
    }
}
