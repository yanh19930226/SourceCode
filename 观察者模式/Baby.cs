using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    class Baby : Iobserver
    {
        public void Cry()
        {
            Console.WriteLine("baby哭了");
        }

        public void Action()
        {
            this.Cry();
        }
    }
}
