using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构非泛型
{
    public interface IEnumerator
    {
        /// <summary>
        /// 获取当前值
        /// </summary>
        object Current { get; }
        /// <summary>
        /// 判断是否有下一个值
        /// </summary>
        /// <returns></returns>
        bool MoveNext();
        /// <summary>
        ///重置
        /// </summary>
        void Reset();
    }
}
