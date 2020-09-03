using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器模式
{
    public abstract class Aggregate
    {
        public abstract ConcreteIterator GetIterator();
    }
}
