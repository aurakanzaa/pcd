using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace pcdmodul1
{
    public partial class Form1 : Form
    {
        PictureBox p1 = new PictureBox();
        PictureBox p2 = new PictureBox();
        PictureBox p3 = new PictureBox();
        PictureBox p4 = new PictureBox();
        PictureBox p5 = new PictureBox();
        PictureBox p6 = new PictureBox();
        PictureBox p7 = new PictureBox();
        public Form1()
        {
            InitializeComponent();
        }

        private void simpanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog bukaFile = new OpenFileDialog();
            bukaFile.Filter = "image File (*.bmp,*.jpg,*.jpeg)|*.bmp;*.jpg;*.jpeg";
            if (DialogResult.OK == bukaFile.ShowDialog())
            {
                this.pbInput.Image = new Bitmap(bukaFile.FileName);
                toolStripStatusLabel1.Text = bukaFile.FileName;
                toolStripStatusLabel2.Text = this.pbInput.Image.PhysicalDimension.ToString();

                //test
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                int nilaiBrightness = 50;
                double C = 0;
                double F = (259 * (C + 255)) / 255 * (259 - C);
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int r1 = Convert.ToInt16(truncated((F * (truncate(c1.R + nilaiBrightness) - 128)) + 128));
                        int g1 = Convert.ToInt16(truncated((F * (truncate(c1.G + nilaiBrightness) - 128)) + 128));
                        int b1 = Convert.ToInt16(truncated((F * (truncate(c1.B + nilaiBrightness) - 128)) + 128));

                        b.SetPixel(i, j, Color.FromArgb(r1, g1, b1));
                    }
                }
                //biru
                int cr;

                Bitmap biru = new Bitmap((Bitmap)this.pbInput.Image);
                for (int i = 0; i < biru.Width; i++)
                {
                    for (int j = 0; j < biru.Height; j++)
                    {
                        Color c1 = biru.GetPixel(i, j);
                        cr = c1.B;
                        Color new_w = Color.FromArgb(0, 0, cr);
                        biru.SetPixel(i, j, new_w);
                    }
                }
              
                p1.Image = biru;

                //sephia
                Bitmap sephia = new Bitmap((Bitmap)this.pbInput.Image);
                for (int i = 0; i < sephia.Width; i++)
                {
                    for (int j = 0; j < sephia.Height; j++)
                    {
                        Color c1 = sephia.GetPixel(i, j);
                        Color new_w = Color.FromArgb((byte)(c1.R), (byte)(c1.R * 0.82), (byte)(c1.R * 0.28));
                        sephia.SetPixel(i, j, new_w);
                    }
                }
               
                p2.Image = sephia;

                //hijau
                
                Bitmap hijau = new Bitmap((Bitmap)this.pbInput.Image);
                for (int i = 0; i < hijau.Width; i++)
                {
                    for (int j = 0; j < hijau.Height; j++)
                    {
                        Color c1 = hijau.GetPixel(i, j);
                        cr = c1.G;
                        Color new_w = Color.FromArgb(0, cr, 0);
                        hijau.SetPixel(i, j, new_w);
                    }
                }
                p3.Image = hijau;

                //merah
                Bitmap merah = new Bitmap((Bitmap)this.pbInput.Image);
                for (int i = 0; i < merah.Width; i++)
                {
                    for (int j = 0; j < merah.Height; j++)
                    {
                        Color c1 = merah.GetPixel(i, j);
                        cr = c1.R;
                        Color new_w = Color.FromArgb(cr, 0, 0);

                        Color w = merah.GetPixel(i, j);
                        merah.SetPixel(i, j, new_w);
                    }
                }
                
                p4.Image = merah;
                //solarised
                int Rt = 10, Gt = 10, Bt = 10;
                Bitmap solaris = new Bitmap((Bitmap)this.pbInput.Image);
                for (int i = 0; i < solaris.Width; i++)
                {
                    for (int j = 0; j < solaris.Height; j++)
                    {
                        Color c1 = solaris.GetPixel(i, j);
                        int r = c1.R;
                        int g = c1.G;
                        int bl = c1.B;
                        if (c1.R < Rt)
                        {
                            r = truncate(255 - c1.R);
                        }

                        if (c1.G < Gt)
                        {
                            g = truncate(255 - c1.G);
                        }

                        if (c1.B < Bt)
                        {
                            bl = truncate(255 - c1.B);
                        }


                        solaris.SetPixel(i, j, Color.FromArgb(r, g, bl));
                    }
                }
                p6.Image = solaris;

                //p4.Image = merah;

                //buat nampilin flowlayout
                flowLayoutPanel1.Visible = true;
                control();
            }
        }

        private void simpanToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (pbOutput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan disimpan");
            }
            else
            {
                SaveFileDialog simpanFIle = new SaveFileDialog();
                simpanFIle.Title = "Simpan File Citra";
                simpanFIle.Filter = "Image File (*.bmp,*.jpg,*.jpeg)|*.bmp;*.jpg;*.jpeg";
                if (DialogResult.OK == simpanFIle.ShowDialog())
                    this.pbOutput.Image.Save(simpanFIle.FileName);
            }
        }

        private void keluarAplikasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Bitmap copy = new Bitmap((Bitmap)this.pbInput.Image);
            olahCitra.keBrightness(copy);
            this.pbOutput.Image = copy;
        }

        private void brightnessContrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                Form2 frm2 = new Form2();
                if (frm2.ShowDialog() == DialogResult.OK)
                {
                    Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                    int nilaiBrightness = Convert.ToInt16(frm2.tbBrightness.Text);
                    double C = Convert.ToDouble(frm2.tbContrast.Text);
                    double F = (259 * (C + 255)) / 255 * (259 - C);
                     
                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            Color c1 = b.GetPixel(i, j);
                            int r1 = Convert.ToInt16(truncated((F * (truncate(c1.R + nilaiBrightness) - 128)) + 128));
                            int g1 = Convert.ToInt16(truncated((F * (truncate(c1.G + nilaiBrightness) - 128)) + 128));
                            int b1 = Convert.ToInt16(truncated((F * (truncate(c1.B + nilaiBrightness) - 128)) + 128));

                            b.SetPixel(i, j, Color.FromArgb(r1, g1, b1));
                        }
 
                    }
 
                    this.pbOutput.Image = b;
                }
            }
        }


        private static int truncate(int x)
        {
            if (x > 255) x = 255;
            else if (x < 0) x = 0;
            return x;
        }
        private static double truncated(double x)
        {
            if (x > 255) x = 255;
            else if (x < 0) x = 0;
            return x;
        }

        private void resetToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            pbOutput.Image = null;
        }

        private void inversToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logBrightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                Form3 frm3 = new Form3();
                if (frm3.ShowDialog() == DialogResult.OK)
                {
                    Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                    double nilaiBrightness = Convert.ToDouble(frm3.tbLog.Text);
                     
                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            Color c1 = b.GetPixel(i, j);
                            double r1 = nilaiBrightness * Math.Log(1 + c1.R);
                            double g1 = nilaiBrightness * Math.Log(1 + c1.G);
                            double b1 = nilaiBrightness * Math.Log(1 + c1.B);
                            int r = truncate(Convert.ToInt16(r1));
                            int g = truncate(Convert.ToInt16(g1));
                            int blue = truncate(Convert.ToInt16(b1));
                            b.SetPixel(i, j, Color.FromArgb(r, g, blue));
                        }
 
                    }
 
                    this.pbOutput.Image = b;
                }
            }
        }

        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                Form4 frm4 = new Form4();
                if (frm4.ShowDialog() == DialogResult.OK)
                {
                    Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                    double nilaiGamma = Convert.ToDouble(frm4.tbGamma.Text);
                     
                    double merah, hijau, biru;
                    int r1, g1, b1;
                    bool gray = false;
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (b.GetPixel(i, j).R == b.GetPixel(i, j).G && b.GetPixel(i, j).B == b.GetPixel(i, j).G)
                            {
                                gray = true;
                            }
                            else
                            {
                                gray = false;
                            }
                        }
                    }
                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            merah = b.GetPixel(i, j).R;
                            hijau = b.GetPixel(i, j).G;
                            biru = b.GetPixel(i, j).B;
                            if (gray == false)
                            {
                                r1 = Convert.ToInt16(255 * Math.Pow(merah / 255, 1 / nilaiGamma));
                                g1 = Convert.ToInt16(255 * Math.Pow(hijau / 255, 1 / nilaiGamma));
                                b1 = Convert.ToInt16(255 * Math.Pow(biru / 255, 1 / nilaiGamma));
                                b.SetPixel(i, j, Color.FromArgb(r1, g1, b1));
                            }
                            else
                            {
                                r1 = Convert.ToInt16(255 * Math.Pow(merah / 255, 1 / nilaiGamma));
                                b.SetPixel(i, j, Color.FromArgb(r1, r1, r1));
                            }
                        }
 
                    }
 
                    this.pbOutput.Image = b;
                }
            }
        }

        private void averageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                 
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int grayAvg = (c1.R + c1.G + c1.B) / 3;
                        b.SetPixel(i, j, Color.FromArgb(grayAvg, grayAvg, grayAvg));
                    }
 
                }
 
                this.pbOutput.Image = b;
            }
        }

        private void lightnessToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                 
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int nilaiMax = Math.Max(c1.R, Math.Max(c1.G, c1.B));
                        int nilaiMin = Math.Min(c1.R, Math.Min(c1.G, c1.B));
                        int gLight = (nilaiMax + nilaiMin) / 2;
                        b.SetPixel(i, j, Color.FromArgb(gLight, gLight, gLight));
                    }
 
                }
 
                this.pbOutput.Image = b;
            }
        }

        private void luminanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                 
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int gLum = Convert.ToInt16((0.21 * c1.R) + (0.72 * c1.G) + (0.07 * c1.B));
                        b.SetPixel(i, j, Color.FromArgb(gLum, gLum, gLum));
                    }
 
                }
 
                this.pbOutput.Image = b;
            }
        }
        private void bitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                double level = 255 / (Math.Pow(2, 1) - 1);
                 
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int R = Convert.ToInt16(Math.Round((c1.R / level)) * level);
                        int G = Convert.ToInt16(Math.Round((c1.G / level)) * level);
                        int B = Convert.ToInt16(Math.Round((c1.B / level)) * level);
                        b.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
 
                }
 
                this.pbOutput.Image = b;
            }
        }

        private void bitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                double level = 255 / (Math.Pow(2, 2) - 1);
                 
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int R = Convert.ToInt16(Math.Round((c1.R / level)) * level);
                        int G = Convert.ToInt16(Math.Round((c1.G / level)) * level);
                        int B = Convert.ToInt16(Math.Round((c1.B / level)) * level);
                        b.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
 
                }
 
                this.pbOutput.Image = b;
            }
        }

        private void bitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                double level = 255 / (Math.Pow(2, 3) - 1);
                 
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int R = Convert.ToInt16(Math.Round((c1.R / level)) * level);
                        int G = Convert.ToInt16(Math.Round((c1.G / level)) * level);
                        int B = Convert.ToInt16(Math.Round((c1.B / level)) * level);
                        b.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
 
                }
 
                this.pbOutput.Image = b;
            }
        }

        private void bitToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                double level = 255 / (Math.Pow(2, 4) - 1);
                 
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int R = Convert.ToInt16(Math.Round((c1.R / level)) * level);
                        int G = Convert.ToInt16(Math.Round((c1.G / level)) * level);
                        int B = Convert.ToInt16(Math.Round((c1.B / level)) * level);
                        b.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
 
                }
 
                this.pbOutput.Image = b;
            }
        }

        private void bitToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                double level = 255 / (Math.Pow(2, 5) - 1);
                 
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int R = Convert.ToInt16(Math.Round((c1.R / level)) * level);
                        int G = Convert.ToInt16(Math.Round((c1.G / level)) * level);
                        int B = Convert.ToInt16(Math.Round((c1.B / level)) * level);
                        b.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
 
                }
 
                this.pbOutput.Image = b;
            }
        }

        private void bitToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                double level = 255 / (Math.Pow(2, 6) - 1);
                 
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int R = Convert.ToInt16(Math.Round((c1.R / level)) * level);
                        int G = Convert.ToInt16(Math.Round((c1.G / level)) * level);
                        int B = Convert.ToInt16(Math.Round((c1.B / level)) * level);
                        b.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
 
                }
 
                this.pbOutput.Image = b;
            }
        }

        private void bitToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                double level = 255 / (Math.Pow(2, 7) - 1);
                 
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int R = Convert.ToInt16(Math.Round((c1.R / level)) * level);
                        int G = Convert.ToInt16(Math.Round((c1.G / level)) * level);
                        int B = Convert.ToInt16(Math.Round((c1.B / level)) * level);
                        b.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
 
                }
 
                this.pbOutput.Image = b;
            }
        }

        private void bitToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                double level = 255 / (Math.Pow(2, 8) - 1);
                 
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int R = Convert.ToInt16(Math.Round((c1.R / level)) * level);
                        int G = Convert.ToInt16(Math.Round((c1.G / level)) * level);
                        int B = Convert.ToInt16(Math.Round((c1.B / level)) * level);
                        b.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
 
                }
 
                this.pbOutput.Image = b;
            }
        }

   
        

        
        public void control()
        {
            
            p1.Height = 100;
            p1.Width  = 100;
            p1.SizeMode = PictureBoxSizeMode.StretchImage;
            p1.BackColor = Color.Black;
            p1.Click += P1_Click;
            flowLayoutPanel1.Controls.Add(p1);

            
            p2.Height = 100;
            p2.Width = 100;
            p2.SizeMode = PictureBoxSizeMode.StretchImage;
            p2.BackColor = Color.Black;
            p2.Click += P2_Click;
            flowLayoutPanel1.Controls.Add(p2);
            
            p3.Height = 100;
            p3.Width = 100;
            p3.SizeMode = PictureBoxSizeMode.StretchImage;
            p3.BackColor = Color.Black;
            p3.Click += P3_Click;
            flowLayoutPanel1.Controls.Add(p3);

            
            p4.Height = 100;
            p4.Width = 100;
            p4.SizeMode = PictureBoxSizeMode.StretchImage;
            p4.BackColor = Color.Black;
            p4.Click += P4_Click;
            flowLayoutPanel1.Controls.Add(p4);

            p5.Height = 100;
            p5.Width = 100;
            p5.SizeMode = PictureBoxSizeMode.StretchImage;
            p5.BackColor = Color.Black;
            p5.Click += P5_Click;
            flowLayoutPanel1.Controls.Add(p5);

            p6.Height = 100;
            p6.Width = 100;
            p6.SizeMode = PictureBoxSizeMode.StretchImage;
            p6.BackColor = Color.Black;
            p6.Click += P6_Click;
            flowLayoutPanel1.Controls.Add(p6);
        }

       

        private void P1_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.p1.Image);
            this.pbOutput.Image = b;
        }
        private void P2_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.p2.Image);
            this.pbOutput.Image = b;
        }
        private void P3_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.p3.Image);
            this.pbOutput.Image = b;
        }
        private void P4_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.p4.Image);
            this.pbOutput.Image = b;
        }      
        private void P5_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.p5.Image);
            this.pbOutput.Image = b;
        }
        private void P6_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.p6.Image);
            this.pbOutput.Image = b;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
          //  control();
        }

        private void tentangToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Syafri Wira Wicaksana | TI4E | 1541180215");
        }
    }
}

