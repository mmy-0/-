using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electricity
{
    public partial class ElecSuccess : UserControl
    {
        private static ElecSuccess Success = new ElecSuccess();
        public static ElecSuccess getInstance()
        {
            return Success;
        }
        public ElecSuccess()
        {
            InitializeComponent();
        }

        private void ElecSuccess_Paint(object sender, PaintEventArgs e)
        {
            this.label7.Text =Convert.ToString( Login.getInstance().Card);
            this.label9.Text = MainPage.getInstance().label1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(PayElectricity.getInstance());
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
