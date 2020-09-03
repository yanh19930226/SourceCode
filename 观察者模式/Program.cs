using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{


    public class C<T, K, V>
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            //对主题感兴趣的观察者订阅该主题
            cat.Add(new Baby());
            cat.Add(new Mouse());
            cat.Add(new Neighboor());
           //猫叫了一声触发事件
            cat.Miao();
            Console.ReadKey();
        }
    }
}
