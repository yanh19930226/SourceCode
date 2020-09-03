using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构.系统内置接口
{
    public interface IComparer<T>
    {
        /// <summary>
        /// 比较两个对象，如果x大于y返回1，如果x等于y返回0，如果x小于y返回-1
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        int Compare(T x,T y);
    }
}
