using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    class Neighboor : Iobserver
    {
        public void Anger()
        {
            Console.WriteLine("邻居愤怒");
        }

        public void Action()
        {
            this.Anger();
        }
    }
}
