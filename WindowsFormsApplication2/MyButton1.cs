using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public class MyButton1:Button
    {
        public MyButton1()
        {
            base.Click += MyButton1_Click;
        }
        public event ButtonClickDelegate _delegate;
        int count = 0;
        void MyButton1_Click(object sender, EventArgs e)
        {
            if (count < 2)
            {
                count++;
            }
            else
            {
                if (_delegate != null)
                {
                    _delegate();
                    count = 0;
                }
            }
        }
    }
}
