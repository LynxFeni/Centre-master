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
    public partial class GenerateBarcode : Form
    {
        public GenerateBarcode()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Random slumpGenerator = new Random();
            int tal = slumpGenerator.Next(0, 100012345);
            txtGenerate.Text = tal.ToString();
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            string barcodeTest = txtBarcode.Text;

            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            var barcodeImage = barcode.Draw(barcodeTest, 60);

            var resultImage = new Bitmap(barcodeImage.Width, barcodeImage.Height + 20); // 20 is bottom padding, adjust to your text

            using (var graphics = Graphics.FromImage(resultImage))
            using (var font = new Font("Consolas", 12))
            using (var brush = new SolidBrush(Color.Black))
            using (var format = new StringFormat()
            {
                Alignment = StringAlignment.Center, // Also, horizontally centered text, as in your example of the expected output
                LineAlignment = StringAlignment.Far
            })
            {
                graphics.Clear(Color.White);
                graphics.DrawImage(barcodeImage, 0, 0);
                graphics.DrawString(txtBarcode.Text, font, brush, resultImage.Width / 2, resultImage.Height, format);
            }

            pictureBox1.Image = resultImage;
            txtBarcode.Clear();
            txtBarcode.Focus();
        }
    }
}
