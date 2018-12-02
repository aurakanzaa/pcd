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
                progressBar1.Visible = true;
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
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;
                this.efek1.Image = b;
                label3.Visible = true;
                
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
                    progressBar1.Visible = true;
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
                        progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                    }
                    progressBar1.Visible = false;
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
                    progressBar1.Visible = true;
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
                        progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                    }
                    progressBar1.Visible = false;
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
                    progressBar1.Visible = true;
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
                        progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                    }
                    progressBar1.Visible = false;
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
                progressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int grayAvg = (c1.R + c1.G + c1.B) / 3;
                        b.SetPixel(i, j, Color.FromArgb(grayAvg, grayAvg, grayAvg));
                    }
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;
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
                progressBar1.Visible = true;
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
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;
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
                progressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int gLum = Convert.ToInt16((0.21 * c1.R) + (0.72 * c1.G) + (0.07 * c1.B));
                        b.SetPixel(i, j, Color.FromArgb(gLum, gLum, gLum));
                    }
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;
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
                progressBar1.Visible = true;
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
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;
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
                progressBar1.Visible = true;
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
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;
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
                progressBar1.Visible = true;
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
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;
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
                progressBar1.Visible = true;
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
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;
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
                progressBar1.Visible = true;
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
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;
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
                progressBar1.Visible = true;
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
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;
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
                progressBar1.Visible = true;
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
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;
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
                progressBar1.Visible = true;
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
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;
                this.pbOutput.Image = b;
            }
        }

        private void tentangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Syafri Wira Wicaksana | TI4E | 1541180215");
        }

        private void hscBrightness_ValueChanged(object sender, EventArgs e)
        {

            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                tbBrightness.Text = hscBrightness.Value.ToString();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
            int nilaiBrightness = Convert.ToInt16(tbBrightness.Text);
            double C = Convert.ToDouble(tbContrast.Text);
            double F = (259 * (C + 255)) / 255 * (259 - C);
            progressBar1.Visible = true;
            for (int i = 0; i < b.Width; i++)
            {
                //for (int j = 0;j < b.Height; j++)
                //{
                //    Color c1 = b.GetPixel(i, j);
                //    int r1 = truncate(c1.R + nilaiBrightness);
                //    int g1 = truncate(c1.G + nilaiBrightness);
                //    int b1 = truncate(c1.B + nilaiBrightness);
                //    b.SetPixel(i, j, Color.FromArgb(r1, g1, b1));
                //}
                for (int j = 0; j < b.Height; j++)
                {
                    Color c1 = b.GetPixel(i, j);
                    int r1 = Convert.ToInt16(truncated((F * (truncate(c1.R + nilaiBrightness) - 128)) + 128));
                    int g1 = Convert.ToInt16(truncated((F * (truncate(c1.G + nilaiBrightness) - 128)) + 128));
                    int b1 = Convert.ToInt16(truncated((F * (truncate(c1.B + nilaiBrightness) - 128)) + 128));

                    b.SetPixel(i, j, Color.FromArgb(r1, g1, b1));
                }
                progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
            }
            this.pbOutput.Image = b;
        }

        private void hscContrast_Scroll(object sender, ScrollEventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                tbContrast.Text = hscContrast.Value.ToString();
            }
        }

        private void averageDenoisingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            if (folderDlg.ShowDialog() == DialogResult.OK)
            {
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
            List<Image> pictureArray = new List<Image>();
            foreach (string item in
                Directory.GetFiles(folderDlg.SelectedPath, "*.jpg", SearchOption.AllDirectories))
            {
                Image _image = Image.FromFile(item);
                pictureArray.Add(_image);

            }
            pbInput.Image = pictureArray[0];
            Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
            Bitmap c = new Bitmap((Bitmap)this.pbInput.Image);
            statusStrip1.Text = "Res. Citra: " + pbInput.Image.Width + " x " + pbInput.Image.Height;
            progressBar1.Visible = true;
            int R, G, B, newR, NewG, newB;
            //nilai 50 berikut menunjukkan jumlah citra, yang diproses adalah 50 citra
            int jumGambar = 50;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    R = 0; G = 0; B = 0;
                    for (int k = 0; k < jumGambar - 1; k++)
                    {
                        b = (Bitmap)pictureArray[k];
                        Color c1 = b.GetPixel(i, j);
                        R = R + c1.R;
                        G = G + c1.G;
                        B = B + c1.B;

                    }
                    c.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
                progressBar1.Value = Convert.ToInt16(100 * (i + 1) / c.Width);
            }
            progressBar1.Visible = false;
            this.pbOutput.Image = c;

        }

        private void warnaTerdekatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                double baru;
                //ser warna pallete: hitam, merah, hijau,kuning,biru,cyan,magenta,putih
                int[,] palletColor = new int[,]
                {
               {0,0,0 },{255,0,0 },{0,128,0 },{255,255,0 },{0,0,255 },{0,255,255 },{255,0,255 },{255,255,255 },
                };
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                this.pbOutput.Image = b;
                progressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        baru = warnaTerdekat(c1.R, c1.G, c1.B);
                        int R = Convert.ToInt16(baru);
                        int G = Convert.ToInt16(baru);
                        int B = Convert.ToInt16(baru);
                        b.SetPixel(i, j, Color.FromArgb(palletColor[(int)baru, 0], palletColor[(int)baru, 1],
                            palletColor[(int)baru, 2]));
                    }
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;
                this.pbOutput.Image = b;

            }
        }

        private static double warnaTerdekat(int pValueR, int pValueG, int pValueB)
        {
            double minDistance = (255 * 255) + (255 * 255) + (255 * 255);
            int palColor, rDiff, gDiff, bDiff;
            double pValueR1 = 0;
            double distance;
            //ser warna pallete: hitam, merah, hijau,kuning,biru,cyan,magenta,putih
            int[,] palletColor = new int[,]
            {
                {0,0,0 },{255,0,0 },{0,128,0 },{255,255,0 },{0,0,255 },{0,255,255 },{255,0,255 },{255,255,255 },
            };
            for (palColor = 0; palColor <= palletColor.GetLength(0) - 1; palColor++)
            {
                rDiff = pValueR - palletColor[palColor, 0];
                gDiff = pValueG - palletColor[palColor, 1];
                bDiff = pValueB - palletColor[palColor, 2];
                distance = rDiff * rDiff + gDiff * gDiff + bDiff * bDiff;
                if (distance < minDistance)
                {
                    minDistance = distance;
                    pValueR1 = palColor;

                }
            }
            return pValueR1;


        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                int horizon;
                double vertcial;

                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                Form5 frm5 = new Form5();
            }
        }

        private void grayscaleInversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                progressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int grayAvg = (c1.R + c1.G + c1.B) / 3;
                        b.SetPixel(i, j, Color.FromArgb(grayAvg, grayAvg, grayAvg));
                    }
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;
                this.pbInput.Image = b;

                Bitmap c = new Bitmap((Bitmap)this.pbInput.Image);
                progressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = c.GetPixel(i, j);
                        int r1 = 255 - c1.R;
                        int g1 = 255 - c1.G;
                        int b1 = 255 - c1.B;
                        c.SetPixel(i, j, Color.FromArgb(r1, g1, b1));
                    }
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / c.Width);
                }
                progressBar1.Visible = false;
                this.pbOutput.Image = c;
            }
        }

        private void inversToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yang akan diolah");
            }
            else
            {
                {
                    Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                    progressBar1.Visible = true;
                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            Color c1 = b.GetPixel(i, j);
                            int r1 = 255 - c1.R;
                            int g1 = 255 - c1.G;
                            int b1 = 255 - c1.B;
                            b.SetPixel(i, j, Color.FromArgb(r1, g1, b1));
                        }
                        progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                    }
                    progressBar1.Visible = false;
                    this.pbOutput.Image = b;
                }
            }
        }

        private void gambarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormTambahGambar frmtambah = new FormTambahGambar();
            if (frmtambah.ShowDialog() == DialogResult.OK)
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);

            }
        }

        private void inputToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null) MessageBox.Show("Tidak ada citra yang akan diolah");
            else
            {
                double[] HistoR = new double[256];
                double[] HistoG = new double[256];
                double[] HistoB = new double[256];
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                histoGray frmgray = new histoGray();
                histoRGB frmrgb = new histoRGB();
                for (int i = 0; i < 255; i++)
                {
                    HistoR[i] = 0;
                    HistoG[i] = 0;
                    HistoB[i] = 0;
                }
                for (int i = 0; i <= 255; i++)
                {
                    for (int j = 0; j <= 255; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int merah = c1.R;
                        int hijau = c1.G;
                        int biru = c1.B;
                        HistoR[merah]++;
                        HistoG[hijau]++;
                        HistoB[biru]++;
                    }
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;

                Double sumR = 0; for (int i = 0; i < 255; i++) { if (HistoG[i] == HistoB[i]) { sumR++; } }

                if (sumR == 255)
                {
                    frmgray.chart1.Series["Series1"].Color = Color.Gray;
                    frmgray.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frmgray.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstR in HistoR)
                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frmgray.chart1.Series["Series1"].Points.AddXY(i, (HistoR[i] + HistoG[i] + HistoB[i]) / 3);
                        }
                    }
                    frmgray.ShowDialog();
                }
                else
                {
                    frmrgb.chart1.Series["Series1"].Color = Color.Red;
                    frmrgb.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frmrgb.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstR in HistoR)
                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frmrgb.chart1.Series["Series1"].Points.AddXY(i, HistoR[i]);
                        }
                    }

                    frmrgb.chart2.Series["Series1"].Color = Color.Green;
                    frmrgb.chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frmrgb.chart2.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstG in HistoG)
                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frmrgb.chart2.Series["Series1"].Points.AddXY(i, HistoG[i]);
                        }
                    }

                    frmrgb.chart3.Series["Series1"].Color = Color.Blue;
                    frmrgb.chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frmrgb.chart3.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstB in HistoB)
                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frmrgb.chart3.Series["Series1"].Points.AddXY(i, HistoB[i]);
                        }
                    }
                    frmrgb.ShowDialog();
                }
            }
        }

        private void outputToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pbOutput.Image == null) MessageBox.Show("Tidak ada citra yang akan diolah");
            else
            {
                double[] HistoR = new double[256];
                double[] HistoG = new double[256];
                double[] HistoB = new double[256];
                Bitmap b = new Bitmap((Bitmap)this.pbOutput.Image);
                histoGray frmgray = new histoGray();
                histoRGB frmrgb = new histoRGB();
                for (int i = 0; i < 255; i++)
                {
                    HistoR[i] = 0;
                    HistoG[i] = 0;
                    HistoB[i] = 0;
                }
                for (int i = 0; i <= 255; i++)
                {
                    for (int j = 0; j <= 255; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int merah = c1.R;
                        int hijau = c1.G;
                        int biru = c1.B;
                        HistoR[merah]++;
                        HistoG[hijau]++;
                        HistoB[biru]++;
                    }
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;

                Double sumR = 0; for (int i = 0; i < 255; i++)
                {
                    if (HistoG[i] == HistoB[i])
                    {
                        sumR++;
                    }
                }

                if (sumR == 255)
                {
                    frmgray.chart1.Series["Series1"].Color = Color.Gray;
                    frmgray.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frmgray.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstR in HistoR)
                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frmgray.chart1.Series["Series1"].Points.AddXY(i, (HistoR[i] + HistoG[i] + HistoB[i]) / 3);
                        }
                    }
                    frmgray.ShowDialog();
                }
                else
                {
                    frmrgb.chart1.Series["Series1"].Color = Color.Red;
                    frmrgb.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frmrgb.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstR in HistoR)
                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frmrgb.chart1.Series["Series1"].Points.AddXY(i, HistoR[i]);
                        }
                    }

                    frmrgb.chart2.Series["Series1"].Color = Color.Green;
                    frmrgb.chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frmrgb.chart2.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstG in HistoG)
                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frmrgb.chart2.Series["Series1"].Points.AddXY(i, HistoG[i]);
                        }
                    }

                    frmrgb.chart3.Series["Series1"].Color = Color.Blue;
                    frmrgb.chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;

                    frmrgb.chart3.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstB in HistoB)
                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frmrgb.chart3.Series["Series1"].Points.AddXY(i, HistoB[i]);
                        }
                    }
                    frmrgb.ShowDialog();
                }
            }
        }

        private void inputDanOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null) MessageBox.Show("Tidak ada citra yang akan diolah");
            else
            {
                double[] HistoR = new double[256];
                double[] HistoG = new double[256];
                double[] HistoB = new double[256];
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                histoGray frmgray= new histoGray();
                histoRGB frmrgb = new histoRGB(); for (int i = 0; i < 255; i++) { HistoR[i] = 0; HistoG[i] = 0; HistoB[i] = 0; }
                for (int i = 0; i <= 255; i++)
                {
                    for (int j = 0; j <= 255; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int merah = c1.R;
                        int hijau = c1.G;
                        int biru = c1.B;
                        HistoR[merah]++;
                        HistoG[hijau]++;
                        HistoB[biru]++;
                    }
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;

                Double sumR = 0; for (int i = 0; i < 255; i++)
                {
                    if (HistoG[i] == HistoB[i])
                    {
                        sumR++;
                    }
                }

                if (sumR == 255)
                {
                    frmgray.chart1.Series["Series1"].Color = Color.Gray;
                    frmgray.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frmgray.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstR in HistoR)
                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frmgray.chart1.Series["Series1"].Points.AddXY(i, (HistoR[i] + HistoG[i] + HistoB[i]) / 3);
                        }
                    }
                    frmgray.Text = "Grayscale Histogram Input";
                    frmgray.ShowDialog();
                }
                else
                {
                    frmrgb.chart1.Series["Series1"].Color = Color.Red;
                    frmrgb.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frmrgb.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstR in HistoR) {
                        for (int i = 0; i <= 255; i++) {
                            frmrgb.chart1.Series["Series1"].Points.AddXY(i, HistoR[i]); } }

                    frmrgb.chart2.Series["Series1"].Color = Color.Green;
                    frmrgb.chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frmrgb.chart2.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstG in HistoG) {
                        for (int i = 0; i <= 255; i++) {
                            frmrgb.chart2.Series["Series1"].Points.AddXY(i, HistoG[i]); } }

                    frmrgb.chart3.Series["Series1"].Color = Color.Blue;
                    frmrgb.chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frmrgb.chart3.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstB in HistoB) {
                        for (int i = 0; i <= 255; i++) {
                            frmrgb.chart3.Series["Series1"].Points.AddXY(i, HistoB[i]); } }
                    frmrgb.Text = "RGB Histogram Input";
                    frmrgb.ShowDialog();
                }
            }

            if (pbOutput.Image == null) MessageBox.Show("Tidak ada citra yang akan diolah");
            else
            {
                double[] HistoR = new double[256];
                double[] HistoG = new double[256];
                double[] HistoB = new double[256];
                Bitmap b = new Bitmap((Bitmap)this.pbOutput.Image);
                histoGray frmgray= new histoGray();
                histoRGB frmrgb = new histoRGB();
                for (int i = 0; i < 255; i++)
                {
                    HistoR[i] = 0;
                    HistoG[i] = 0;
                    HistoB[i] = 0;
                }
                for (int i = 0; i <= 255; i++)
                {
                    for (int j = 0; j <= 255; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int merah = c1.R;
                        int hijau = c1.G;
                        int biru = c1.B;
                        HistoR[merah]++;
                        HistoG[hijau]++;
                        HistoB[biru]++;
                    }
                    progressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                }
                progressBar1.Visible = false;

                Double sumR = 0; for (int i = 0; i < 255; i++)
                {
                    if (HistoG[i] == HistoB[i])
                    {
                        sumR++;
                    }
                }

                if (sumR == 255)
                {
                    frmgray.chart1.Series["Series1"].Color = Color.Gray;
                    frmgray.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frmgray.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstR in HistoR)
                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frmgray.chart1.Series["Series1"].Points.AddXY(i, (HistoR[i] + HistoG[i] + HistoB[i]) / 3);
                        }
                    }
                    frmgray.Text = "Grayscale Histogram Input";
                    frmgray.ShowDialog();
                }
                else
                {
                    frmrgb.chart1.Series["Series1"].Color = Color.Red;
                    frmrgb.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frmrgb.chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstR in HistoR)
                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frmrgb.chart1.Series["Series1"].Points.AddXY(i, HistoR[i]);
                        }
                    }

                    frmrgb.chart2.Series["Series1"].Color = Color.Green;
                    frmrgb.chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frmrgb.chart2.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstG in HistoG)
                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frmrgb.chart2.Series["Series1"].Points.AddXY(i, HistoG[i]);
                        }
                    }

                    frmrgb.chart3.Series["Series1"].Color = Color.Blue;
                    frmrgb.chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                    frmrgb.chart3.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;

                    foreach (Double HstB in HistoB)
                    {
                        for (int i = 0; i <= 255; i++)
                        {
                            frmrgb.chart3.Series["Series1"].Points.AddXY(i, HistoB[i]);
                        }
                    }
                    frmrgb.Text = "RGB Histogram Output"; frmrgb.ShowDialog();
                }
            }
        }

        private void motionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormMotion frmmotion = new FormMotion();
            if (frmmotion.ShowDialog() == DialogResult.OK)
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.efek1.Image);
            this.pbOutput.Image = b;
        }

        private void efek2_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.efek2.Image);
            this.pbOutput.Image = b;
        }

        private void efek3_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.efek3.Image);
            this.pbOutput.Image = b;
        }

        private void sephiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                progressBar1.Visible = true;
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        Color new_w = Color.FromArgb((byte)(c1.R), (byte)(c1.R * 0.82), (byte)(c1.R * 0.28));
                        b.SetPixel(i, j, new_w);
                    }
                }
                progressBar1.Visible = false;
                // this.pbOutput.Image = b;
                this.efek3.Image = b;
                label5.Visible = true;
            }
        }
        

        private void hscBrightness_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void biruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                int cr;

                Bitmap vertikal = new Bitmap((Bitmap)this.pbInput.Image);
                progressBar1.Visible = true;
                for (int i = 0; i < vertikal.Width; i++)
                {
                    for (int j = 0; j < vertikal.Height; j++)
                    {
                        Color c1 = vertikal.GetPixel(i, j);
                        cr = c1.B;
                        Color new_w = Color.FromArgb(0,0,cr);
                        vertikal.SetPixel(i, j, new_w);
                    }
                }
                progressBar1.Visible = false;
                // this.pbOutput.Image = b;
                this.efek2.Image = vertikal;
                label4.Visible = true;
            }
        }

        private void hijauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                int cr;

                Bitmap horizontal = new Bitmap((Bitmap)this.pbInput.Image);
                progressBar1.Visible = true;
                for (int i = 0; i < horizontal.Width; i++)
                {
                    for (int j = 0; j < horizontal.Height; j++)
                    {
                        Color c1 = horizontal.GetPixel(i, j);
                        cr = c1.G;
                        Color new_w = Color.FromArgb(0, cr, 0);
                        horizontal.SetPixel(i, j, new_w);
                    }
                }
                progressBar1.Visible = false;
                // this.pbOutput.Image = b;
                this.efek4.Image = horizontal;
                label6.Visible = true;

            }
        }

        private void pbOutput_Click(object sender, EventArgs e)
        {

        }

        private void efek4_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.efek4.Image);
            this.pbOutput.Image = b;
        }

        private void efek5_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.efek5.Image);
            this.pbOutput.Image = b;
        }

        private void efek6_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.efek6.Image);
            this.pbOutput.Image = b;
        }

        private void efek7_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.efek7.Image);
            this.pbOutput.Image = b;
        }

        private void efek8_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.efek8.Image);
            this.pbOutput.Image = b;
        }

        private void merahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                int cr;

                Bitmap horizontal = new Bitmap((Bitmap)this.pbInput.Image);
                progressBar1.Visible = true;
                for (int i = 0; i < horizontal.Width; i++)
                {
                    for (int j = 0; j < horizontal.Height; j++)
                    {
                        Color c1 = horizontal.GetPixel(i, j);
                        cr = c1.R;
                        Color new_w = Color.FromArgb(cr, 0, 0);

                        Color w = horizontal.GetPixel(i, j);
                        horizontal.SetPixel(i, j, new_w);
                    }
                }
                progressBar1.Visible = false;
                // this.pbOutput.Image = b;
                this.efek5.Image = horizontal;
                label7.Visible = true;

            }
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap horizontal = new Bitmap((Bitmap)this.pbInput.Image);
            progressBar1.Visible = true;
            for (int i = 0; i < horizontal.Width; i++)
            {
                for (int j = 0; j < horizontal.Height; j++)
                {
                    
                    Color w = horizontal.GetPixel(i, j);
                    horizontal.SetPixel(i, horizontal.Height-1-j, w);
                }
            }
            progressBar1.Visible = false;
            // this.pbOutput.Image = b;
            this.pbOutput.Image = horizontal;
        }
    }
}

