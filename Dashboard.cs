using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Access_Click(object sender, EventArgs e)
        {
            Access access = new Access();
            access.Show();
           // this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
            //this.Hide();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
           
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            GenerateBarcode generateBarcode = new GenerateBarcode();
            generateBarcode.Show();
            //this.Hide();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.Show();
            //this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DisplayMembers members = new DisplayMembers();
            members.ShowDialog();
            //this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MembershipType addUser = new MembershipType();
            addUser.ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ViewUsers viewUsers = new ViewUsers();
            viewUsers.Show();
        }

        private void BtnOverwriteHistory_Click(object sender, EventArgs e)
        {
            HistoryOverwrite historyOverwrite = new HistoryOverwrite();
            historyOverwrite.Show();
            //this.Hide();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
