using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.myButton3._buttonDelegate = () => { MessageBox.Show("我被点击了2次"); };
            this.myButton3.add(() => { MessageBox.Show("委托私有化的点击2次"); });
            this.myButton3.add(()=>{MessageBox.Show("委托私有化添加");});
            //this.myButton3.remove(delegate() { });
            //this.
            this.myButton11._delegate += myButton11__delegate;
        }

        void myButton11__delegate()
        {
            MessageBox.Show("事件的点击事件");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void myButton2_Click(object sender, EventArgs e)
        {
        }
    }
}
