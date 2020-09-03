using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件的标准用法1
{
    class Program
    {
        static void Main(string[] args)
        {
            Publicsher ap1 = new Publicsher(){
               Preice = 5288
            };


            //注册事件
            ap1.myEvent += PriceChanged;


            //调整价格，触发事件
            ap1.Preice = 3999;


            Console.ReadKey();
        }
        //事件响应程序
        static void PriceChanged(object sender, MyEventArgs e)
        {
             Console.WriteLine("年终大促销，iPhone 6 只卖 " + e.NewPrice + " 元， 原价 " + e.OldPrice + " 元，快来抢！");
        }
    }
}
