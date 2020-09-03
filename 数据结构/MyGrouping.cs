using System;
using 数据结构非泛型;

namespace 数据结构
{
    /*
     * 分组类
     * Grouping则是对组内的元素进行枚举
    */
    internal class MyGrouping<TKey, TElement> : 系统内置接口.IGrouping<TKey, TElement>
    {
        #region 组的私有的字段和属性
        //数组
        internal TElement[] temp;
        //默认的容量大小
        internal int _capacity = 3;
        //数组实际存储的元素的个数
        internal int count;
        //组的Key
        internal TKey key;
        //这个组的Key所对应的hashcode
        internal int hashcode;
        //这个组所保存的不同Key值但是相同hashcode的下一个组的引用
        internal MyGrouping<TKey, TElement> hashNext;
        //这个组所保存的相对于整个Lookup类的下一个的分组的引用
        internal MyGrouping<TKey, TElement> next;
        #endregion

        #region 构造函数+MyGrouping()
        /// <summary>
        /// 无参构造函数
        /// </summary>
        internal MyGrouping()
        {
            temp = new TElement[_capacity];
        }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="_capacity">容量大小</param>
        internal MyGrouping(int _capacity) : this()
        {
            checked
            {
                if (_capacity > 0)
                {
                    this._capacity = _capacity;
                }
            }
        }
        #endregion

        #region 添加+Add(TElement element)
        /// <summary>
        /// 往这个私有数组中添加元素的方法
        /// </summary>
        /// <param name="element"></param>
        internal void Add(TElement element)
        {
            //判断如果数组中的元素的个数等于数组的长度那么就进行扩容
            if (this.count == temp.Length)
            {
                int newSize = checked(this.count * 2);
                TElement[] newarray = new TElement[this.count * 2];
                temp.CopyTo(newarray, 0);
                temp = newarray;
            }
            temp[count] = element;
            count++;
        }
        #endregion

        #region 获取这个组的Key
        /// <summary>
        /// 获取这个组的键值
        /// </summary>
        internal TKey Key
        {
            get { return this.key; }
        }

        public int Hashcode
        {
            get
            {
                return hashcode;
            }

            set
            {
                hashcode = value;
            }
        }
        #endregion

        #region 获取这个组的元素的个数+GetCount()
        /// <summary>
        /// 获取这个组的元素的个数
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return this.count;
        }
        #endregion

        #region 枚举器+GetEnumerator()
        public IEnumerator<TElement> GetEnumerator()
        {
            return new 数据结构.Enumerator<TElement>(temp, this.count);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        } 
        #endregion

    }
}
