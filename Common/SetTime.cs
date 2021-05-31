using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pronto.Common
{
    public partial class SetTime : Form
    {
        public SetTime()
        {
            InitializeComponent();
        }

        public DateTime DepTime
        {
            get
            {
                return DepartTime.Value;
            }
            set
            {
                DepartTime.Value = value;
            }
        }

        public DateTime ArTime
        {
            get
            {
                return ArivalTime.Value;
            }
            set
            { ArivalTime.Value = value; }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ArivalTime_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan ts = DepartTime.Value - ArivalTime.Value;
            TimeDiff.Text = string.Format("{0}:{1}", ts.Hours, ts.Minutes);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void SetTime_Load(object sender, EventArgs e)
        {

        }
    }
}
