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
    public partial class HistoryOverwrite : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["XpressionsEntities"].ConnectionString;

        public HistoryOverwrite()
        {
            InitializeComponent();
            refreshdata();
        }

        private void HistoryOverwrite_Load(object sender, EventArgs e)
        {

        }

        private void refreshdata()
        {

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select  m.FirstName,m.LastName, m.ID, m.Note  from MembershipType m  left join MemReg n on m.ID = n.idNo ", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            HistoryNotesGrid.DataSource = dt;
            con.Close();

        }
        private void HistoryNotesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ContractNo = Convert.ToInt32(HistoryNotesGrid.Rows[e.RowIndex].Cells["ContractNo"].Value.ToString());

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select MemberFName,MemberLName,idNo from MemReg Where ContractNo = " + ContractNo + " ";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            using (MemberAccess member = new MemberAccess())
            {

                member.txtBxContractNo.Text = HistoryNotesGrid.CurrentRow.Cells[0].Value.ToString();
                member.txtBxFirstName.Text = HistoryNotesGrid.CurrentRow.Cells[1].Value.ToString();
                member.txtSurname.Text = HistoryNotesGrid.CurrentRow.Cells[2].Value.ToString();
                member.txtBxID.Text = HistoryNotesGrid.CurrentRow.Cells[3].Value.ToString();
               
                member.ShowDialog();



            }
        }
    }
}
