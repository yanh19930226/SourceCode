using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托和事件的练习
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher p = new Publisher();
            Subscribe1 s1 = new Subscribe1();
            Subscribe2 s2 = new Subscribe2();
            Subscribe3 s3 = new Subscribe3();
            p.myEnvent += s1.Action;
            p.myEnvent += s2.Action;
            p.myEnvent += s3.Action;
            p.returnEvent += s1.T;
            p.returnEvent += s2.T;
            p.returnEvent += s3.T;
            List<string>list=p.OnExcute1();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("==========================================");
            p.OnExcute();
            Console.ReadKey();
        }

        //static void p_myEnvent()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
