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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void hscBrightness_ValueChanged(object sender, EventArgs e)
        {
            tbBrightness.Text = hscBrightness.Value.ToString();
                
        }

        private void tbBrightness_TextChanged(object sender, EventArgs e)
        {
            if ((tbBrightness.Text == "") || (tbBrightness.Text == "-"))
            {
                hscBrightness.Value = 0;
                tbBrightness.Text = "0";
            }
            else if ((Convert.ToInt16(tbBrightness.Text) <= 127) && (Convert.ToInt16(tbBrightness.Text) >= -127))
            {
                hscBrightness.Value = Convert.ToInt16(tbBrightness.Text);
            }
            else
            {
                MessageBox.Show("Omput nilai Error");
                tbBrightness.Text = "0";
            }
        }

        private void tbContrast_TextChanged(object sender, EventArgs e)
        {
            if ((tbContrast.Text == "") || (tbContrast.Text == "-"))
            {
                hscContrast.Value = 0;
                tbContrast.Text = "0";
            }
            else if ((Convert.ToInt16(tbContrast.Text) <= 127) && (Convert.ToInt16(tbContrast.Text) >= -127))
            {
                hscContrast.Value = Convert.ToInt16(tbContrast.Text);
            }
            else
            {
                MessageBox.Show("Omput nilai Error");
                tbContrast.Text = "0";
            }
        }

        private void tbOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            tbBrightness.Text = hscBrightness.Value.ToString();
            tbContrast.Text = hscContrast.Value.ToString();
        }

        private void hscContrast_ValueChanged(object sender, EventArgs e)
        {
            tbContrast.Text = hscContrast.Value.ToString();
        }
    }
}
