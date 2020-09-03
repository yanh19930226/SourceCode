using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构.内置委托
{
    public delegate bool Predicate<in T>(T t);
}
