using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 控制台2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 12345678;
            int b = -12345678;
            int c = a & 0x7FFFFFFF;
            int d=b & 0x7FFFFFFF;
            Console.WriteLine(c.ToString());
            Console.WriteLine(d.ToString());
            Console.ReadKey();
        }
    }
    public class Grouping
    {


    }
}
