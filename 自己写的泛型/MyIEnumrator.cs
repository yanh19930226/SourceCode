using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自己写的泛型
{
    public interface MyIEnumrator
    {
        /// <summary>
        /// 移动到下一位
        /// </summary>
        /// <returns></returns>
        bool MoveNext();
        /// <summary>
        /// 获取当前的字符串
        /// </summary>
        /// <returns></returns>
        string Current{get;}
        /// <summary>
        /// 重新回到第一位
        /// </summary>
        void Reset();
    }
}
