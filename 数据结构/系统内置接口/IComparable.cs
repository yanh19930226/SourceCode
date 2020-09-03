using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构.系统内置接口
{
    public interface IComparable<T>
    {
        int CompareTo(T obj);
    }
}
