using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 数据结构非泛型;

namespace 数据结构
{
    public interface IEnumerable<T> : IEnumerable
    {
        IEnumerator<T> GetEnumerator();
        /// <summary>
        /// 获取聚合的元素个数
        /// </summary>
        /// <returns></returns>
        int GetCount();
    }
}
