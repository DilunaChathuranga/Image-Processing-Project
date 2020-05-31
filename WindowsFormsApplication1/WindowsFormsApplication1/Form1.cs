using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        Filters fo = new Filters();

        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ofd.Title = "Select image file";
            ofd.Filter = "Images(*.BMP;*.JPG;*.GIF)|"
                + "*.BMP;*.JPG;*.GIF|"
                + "All files(*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
                String picPath = ofd.FileName.ToString();
                fo.LoadImage(picPath);
                pictureBox3.ImageLocation = picPath;
                pictureBox3.Load(ofd.FileName);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fo.Arithmetic();
            pictureBox4.ImageLocation = "2.jpg";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            fo.Geometric();
            pictureBox4.ImageLocation = "3.jpg";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            fo.Harmonic();
            pictureBox4.ImageLocation = "4.jpg";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            fo.ContraHarmonic();
            pictureBox4.ImageLocation = "5.jpg";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            fo.Median();
            pictureBox4.ImageLocation = "median.jpg";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            fo.Max();
            pictureBox4.ImageLocation = "max.jpg";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            fo.Min();
            pictureBox4.ImageLocation = "min.jpg";
        }
    }
}
