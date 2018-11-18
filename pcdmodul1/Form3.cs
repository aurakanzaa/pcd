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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void hscLog_ValueChanged(object sender, EventArgs e)
        {
            tbLog.Text = hscLog.Value.ToString();
        }

        private void tbLog_TextChanged(object sender, EventArgs e)
        {
            if ((tbLog.Text == "") || (tbLog.Text == "-"))
            {
                hscLog.Value = 0;
                tbLog.Text = "0";
            }
            else if ((Convert.ToInt16(tbLog.Text) <= 127) && (Convert.ToInt16(tbLog.Text) >= -127))
            {
                hscLog.Value = Convert.ToInt16(tbLog.Text);
            }
            else
            {
                MessageBox.Show("Omput nilai Error");
                tbLog.Text = "0";
            }
        }
    }
}
