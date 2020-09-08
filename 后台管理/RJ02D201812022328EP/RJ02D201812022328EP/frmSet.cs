using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJ02D201812022328EP
{
    public partial class frmSet : Form
    {
        public frmSet()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnTnName_Click(object sender, EventArgs e)
        {
            frmSetnicheng f = new frmSetnicheng();

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show("ok");
                
            }
        }
    }
}
