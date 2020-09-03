using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构.内置委托
{
    public delegate void Action();

    public delegate void Action<in T1>(T1 t1);

    public delegate void Action<in T1, in T2>(T1 t1, T2 t2);

    public delegate void Action<in T1, in T2, in T3, in T4>(T1 t1, T2 t2, T3 t3, T4 t4);
}
