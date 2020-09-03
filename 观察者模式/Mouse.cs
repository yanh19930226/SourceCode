using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    class Mouse : Iobserver
    {
        public void Run()
        {
            Console.WriteLine("老鼠跑");
        }

        public void Action()
        {
            this.Run();
        }
    }
}
