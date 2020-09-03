using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构
{
    public class Comparer<T> : 系统内置接口.IComparer<T>
    {
        /// <summary>
        /// 属性
        /// </summary>
        public 系统内置接口.IComparer<T> Default { get; set; }
        public int Compare(T x, T y)
        {
            throw new NotImplementedException();
        }
    }
}
