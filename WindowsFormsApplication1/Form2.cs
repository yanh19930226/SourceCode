using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string msg, SetTextDelegte dg)
        {
            InitializeComponent();
            this.label1.Text = msg;
            this.dd = dg;
        }
        private SetTextDelegte dd;
        private void button1_Click(object sender, EventArgs e)
        {
            if (dd != null)
            {
                dd.Invoke(this.textBox1.Text);
            }
        }
    }
}
