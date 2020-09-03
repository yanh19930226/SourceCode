using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public class MyButton:Button
    {
        public MyButton()
        {
            base.Click += MyButton_Click;
        }
        private ButtonClickDelegate _buttonDelegate;

        public void add(ButtonClickDelegate _userMethod)
        {
            if (this._buttonDelegate == null)
                this._buttonDelegate = _userMethod;
            else
                this._buttonDelegate += _userMethod;
        }
        public void remove(ButtonClickDelegate _userMethod)
        {
            if (this._buttonDelegate!=null)
                this._buttonDelegate -= _userMethod;
        }
        //点击计数器
        int count = 0;

        /// <summary>
        /// 自定义button的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MyButton_Click(object sender, EventArgs e)
        {
            if (count<1)
            {
                count++;
            }
            else
            {
                if (_buttonDelegate!=null)
                {
                    _buttonDelegate();
                    count = 0;
                }
                //MessageBox.Show("被点击了");
            }
        }
    }
}
