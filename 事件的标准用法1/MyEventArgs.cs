using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件的标准用法1
{
    /// <summary>
    /// 事件参数
    /// </summary>
    public class MyEventArgs:EventArgs
    {
        public MyEventArgs(decimal newPrice, decimal oldPrice)
        {
            this.NewPrice = newPrice;
            this.OldPrice = oldPrice;
        }


        public readonly decimal NewPrice;
        public readonly decimal OldPrice;
    }
}
