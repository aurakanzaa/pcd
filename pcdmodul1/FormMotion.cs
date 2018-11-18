using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pcdmodul1
{
    public partial class FormMotion : Form
    {
        public FormMotion()
        {
            InitializeComponent();
        }

        private void pilihGambarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog bukaFile = new OpenFileDialog();
            bukaFile.Filter = "image File (*.bmp,*.jpg,*.jpeg)|*.bmp;*.jpg;*.jpeg";
            if (DialogResult.OK == bukaFile.ShowDialog())
            {
                if (pbInput1.Image == null)
                {
                    this.pbInput1.Image = new Bitmap(bukaFile.FileName);
                    statusStrip1.Text = bukaFile.FileName;
                    //toolStripStatusLabel2.Text = this.pbInput.Image.PhysicalDimension.ToString();
                }
                else
                {
                    this.pbInput2.Image = new Bitmap(bukaFile.FileName);
                    this.pbOutput.Image = new Bitmap(bukaFile.FileName);
                    statusStrip2.Text = bukaFile.FileName;
                    //toolStripStatusLabel2.Text = this.pbInput.Image.PhysicalDimension.ToString();
                }

            }
        }

        private void btnTmbh_Click(object sender, EventArgs e)
        {
            if (pbInput1.Image == null)
            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                double nilaiR=0, nilaiG = 0, nilaiB = 0;
                Bitmap b = new Bitmap((Bitmap)this.pbInput1.Image);
                Bitmap c = new Bitmap((Bitmap)this.pbInput2.Image);
                Bitmap temp = new Bitmap((Bitmap)this.pbOutput.Image);
                progressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        Color c2 = c.GetPixel(i, j);
                        double R = truncate(Math.Abs(c1.R - c2.R) );
                        double G = truncate(Math.Abs(c1.G - c2.G) );
                        double B = truncate(Math.Abs(c1.B - c2.B) );
                        temp.SetPixel(i, j, Color.FromArgb(Convert.ToInt16(R), Convert.ToInt16(G), Convert.ToInt16(B)));
                  
                    }

                  
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }

                for (int a = 0; a < temp.Width; a++)
                {
                    int lebar = 0,tinggi =0;
                    for (int j = 0; j < temp.Height; j++)
                    {

                        Color c3 = temp.GetPixel(a, j);
                        double Rcek = c3.R;
                        double Gcek = c3.G;
                        double Bcek = c3.B;

                        nilaiR += Rcek;
                        nilaiG += Gcek;
                        nilaiB += Bcek;
                        tinggi++;
                    }
                    lebar++;
                    nilaiR = nilaiR / (lebar * tinggi);
                    nilaiG = nilaiG / (lebar * tinggi);
                    nilaiB = nilaiB / (lebar * tinggi);
                }
                toolStripStatusLabel1.Visible = true;
                toolStripStatusLabel2.Visible = true;
                toolStripStatusLabel3.Visible = true;
                toolStripStatusLabel1.Text = "Rata2 R :" + Convert.ToString(nilaiR);
                toolStripStatusLabel2.Text = "Rata2 G :" + Convert.ToString(nilaiG);
                toolStripStatusLabel3.Text = "Rata2 B :" + Convert.ToString(nilaiB);
                progressBar1.Visible = false;
                this.pbOutput.Image = temp;
            }
        }
        private static int truncate(int x)
        {
            if (x > 255) x = 255;
            else if (x < 0) x = 0;
            return x;
        }
    }
}

