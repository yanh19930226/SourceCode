﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            obj.BackColor = Color.Red;
            string msg = this.textBox1.Text;
            Form2 f2 = new Form2(msg, setText);
            f2.Show();
        }
        public void setText(string msg)
        {
            this.textBox1.Text = msg;
        }
    }
}
