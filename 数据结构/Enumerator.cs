using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 数据结构非泛型;

namespace 数据结构
{
    public class Enumerator<T>:IEnumerator,IEnumerator<T>
    {
        /// <summary>
        /// 要进行迭代的聚合
        /// </summary>
        private T[] _temp;
        /// <summary>
        /// 索引初始位置
        /// </summary>
        private int index = -1;

        private int count;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="temp"></param>
        public Enumerator(T[] temp,int count)
        {
            this._temp = temp;
            this.count = count;
        }
        /// <summary>
        /// 获取迭代的当前的元素
        /// </summary>
        public T Current
        {
            get { return _temp[index]; }
        }

        object IEnumerator.Current
        {
            get { return _temp[index]; }
        }

        /// <summary>
        /// 获取当前的元素的索引值
        /// </summary>
        int IEnumerator<T>.index
        {
            get
            {
                return this.index;
            }
        }
        /// <summary>
        /// 判断是否有下一个元素
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            index++;
            if (index < this.count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
