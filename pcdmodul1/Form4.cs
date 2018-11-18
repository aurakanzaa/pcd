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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void hscGamma_ValueChanged(object sender, EventArgs e)
        {
            tbGamma.Text = Convert.ToString(hscGamma.Value * 0.01);
        }

        private void tbGamma_TextChanged(object sender, EventArgs e)
        {
            //if ((tbGamma.Text == "") || (tbGamma.Text == "-"))
            //{
            //    hscGamma.Value = 0;
            //    tbGamma.Text = "0";
            //}
            //else if ((Convert.ToInt16(tbGamma.Text) <= 8) && (Convert.ToInt16(tbGamma.Text) >= 0))
            //{
            //    hscGamma.Value = Convert.ToInt16(tbGamma.Text);
            //}
            //else
            //{
            //    MessageBox.Show("Omput nilai Error");
            //    tbGamma.Text = "0";
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            tbGamma.Text = hscGamma.Value.ToString();
        }
    }
}
