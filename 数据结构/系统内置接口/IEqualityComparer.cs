using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构.系统内置接口
{
    public interface IEqualityComparer<T>
    {
        //判断是否相等:true表示相等,false表示不相等
        bool Equal(T x,T y);
        //获取hash值
        int GetHashCode(T obj);
    }
}
