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
    public partial class DashboardUsers : Form
    {
        public DashboardUsers()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
            this.Hide();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            GenerateBarcode generateBarcode = new GenerateBarcode();
            generateBarcode.Show();
            this.Hide();
        }

        private void Access_Click(object sender, EventArgs e)
        {
            Access access = new Access();
            access.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DisplayMembers members = new DisplayMembers();
            members.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DashboardUsers_Load(object sender, EventArgs e)
        {

        }
    }
}
