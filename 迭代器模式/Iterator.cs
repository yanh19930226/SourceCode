using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器模式
{
    public abstract class Iterator
    {
        public abstract object First();

        public abstract object Current();

        public abstract bool IsDone();

        public abstract object Next();

    }
}
