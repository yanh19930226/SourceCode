using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型的逆变和协变
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<DerivedClass> d = new List<DerivedClass>();
            IEnumerable<BaseClass> b = d;
        }
    }
    public class BaseClass
    {
        //...
    }
    public class DerivedClass : BaseClass
    {
        //...
    }
}
