using System;
using 数据结构非泛型;

namespace 数据结构
{

    //(Contains方法的实现的原理)
    //参考资料：http://www.cnblogs.com/yyjj/p/4086791.html
    public class MyList<T>:IEnumerable<T>,IEnumerable
    {
        #region 私有字段
        //私有数组
        private T[] _array;
        //数组中实际存储的元素的个数
        private int _count;
        /// <summary>
        /// 属性，MyList中的元素的个数
        /// </summary>
        public int Count
        {
            get { return _count; }
        }
        //数组的默认容量
        private int _defaultcapacity = 4; 
        #endregion

        #region 无参构造函数+MyList()
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public MyList()
        {
            _array = new T[0];
        } 
        #endregion

        #region 有参构造函数，用户指定MyList的长度+MyList(int Capacity)
        /// <summary>
        /// 有参构造函数，用户指定MyList的长度
        /// </summary>
        /// <param name="Capacity">指定长度</param>
        public MyList(int Capacity)
        {
            if (Capacity < 0)
            {
                throw new Exception("指定的长度不能小于0");
            }
            if (Capacity < _defaultcapacity)
            {
                Capacity = _defaultcapacity;
            }
            _array = new T[Capacity];
        }
        #endregion

        #region 将枚举类型的数据源直接转换为MyList+MyList(数据结构.IEnumerable<T> source)
        /// <summary>
        /// 将枚举类型的数据源直接转换为MyList
        /// </summary>
        /// <param name="source"></param>
        public MyList(数据结构.IEnumerable<T> source)
        {
            if (source != null)
            {
                数据结构.IEnumerator<T> tor = source.GetEnumerator();
                while (tor.MoveNext())
                {
                    this.Add(tor.Current);
                }
            }
        } 
        #endregion

        #region 索引器+this[int index]
        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _array.Length)
                    throw new Exception("索引越界了");
                else
                    return _array[index];
            }
            set
            {
                if (index < 0 || index > _array.Length)
                    throw new Exception("索引越界了");
                else
                    _array[index] = value;
            }
        } 
        #endregion

        #region  添加+Add(T item)
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            //说明数组容量已经满了或者是数组第一次添加数据，需要扩容
            if (_count==_array.Length)
            {
                if (_count==0)
                {
                    _array=new T[_defaultcapacity];
                }
                else
                {
                    //新建一个数组
                    T[] temp=new T[_count*2];
                    //把旧数组的数据复制到新的数组中
                    _array.CopyTo(temp, 0);
                    //重新指定原来数组的引用，指向新的数组的引用
                    _array = temp;
                }
            }
            _array[_count]=item;
            _count++;
        } 
        #endregion

        #region 往集合指定的位置插入元素+Insert(int index)
        /// <summary>
        /// 往集合指定的位置插入元素
        /// </summary>
        /// <param name="index"></param>
        public void Insert(int index)
        {

        } 
        #endregion

        #region 删除+Remove(T item)
        public void Remove(T item)
        {
            this.RemovAt(this.IndexOf(item));
        } 
        #endregion

        #region 根据索引进行删除+RemovAt(int index)
        public void RemovAt(int index)
        {
            if (index<0||index>=_array.Length)
            {
                throw new Exception("索引越界了");
            }
            else
            {
                Array.Copy(_array, index + 1, _array, index, _array.Length - index-1);
            }
        } 
        #endregion

        #region 从集合中从指定的索引出移除指定个数的元素+RemoveRange(int startindex, int count)
        /// <summary>
        /// 从集合中从指定的索引出移除指定个数的元素
        /// </summary>
        /// <param name="startindex"></param>
        /// <param name="count"></param>
        public void RemoveRange(int startindex, int count)
        {

        } 
        #endregion

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_array[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        #region 查找指定的元素的索引+IndexOf(T item)
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_array[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        } 
        #endregion

        #region 从后往前查找指定的元素+LastIndexOf(T item)
        public int LastIndexOf(T item)
        {
            for (int i = Count; i >= 0; i--)
            {
                if (_array[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion

        #region 查找符合条件的第一个匹配元素+Find(内置委托.Predicate<T> match)
        /// <summary>
        /// 查找符合条件的第一个匹配元素
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public T Find(内置委托.Predicate<T>match)
        {
            if (match == null)
            {
                throw new Exception("筛选条件不能为空");
            }
            for (int i = 0; i < this.Count; i++)
            {
                if (match(_array[i]))
                {
                    return _array[i];
                }
            }
            return default(T);
        }
        #endregion

        #region 查找所有符合条件的元素并返回一个IEnumerable类型+FindAll(内置委托.Predicate<T> match)
        /// <summary>
        /// 查找所有符合条件的元素并返回一个IEnumerable类型
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<T> FindAll(内置委托.Predicate<T> match)
        {
            if (match == null)
            {
                throw new Exception("条件不能为空");
            }
            for (int i = 0; i < this.Count; i++)
            {
                if (match(_array[i]))
                {
                    yield return _array[i];
                }
            }
        } 
        #endregion

        #region 从集合中查找符合条件的第一个元素的索引+FindIndex(Predicate<T> match)
        /// <summary>
        /// 从集合中查找符合条件的第一个元素的索引
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public int FindIndex(内置委托.Predicate<T> match)
        {
            return this.FindIndex(0, this.Count, match);
        }
        #endregion

        #region 从指定的位置开始符合条件的第一个元素的位置的索引+FindIndex(int startindex, 内置委托.Predicate<T> match)
        /// <summary>
        /// 从指定的位置开始符合条件的第一个元素的位置的索引
        /// </summary>
        /// <param name="startindex"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        public int FindIndex(int startindex, 内置委托.Predicate<T> match)
        {
            return this.FindIndex(startindex, this.Count - startindex, match);
        }
        #endregion

        #region 从指定的目标索引开始查找count个元素，找到符合条件的元素的索引+FindIndex(int startindex, int count, 内置委托.Predicate<T> match)
        /// <summary>
        /// 从指定的目标索引开始查找count个元素，找到符合条件的元素的索引
        /// </summary>
        /// <param name="startindex"></param>
        /// <param name="count"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        public int FindIndex(int startindex, int count, 内置委托.Predicate<T> match)
        {
            if (startindex > this.Count)
            {
                throw new Exception("开始索引不能大于集合中的元素的总的个数");
            }
            if (count < 0 || count > this.Count - startindex)
            {
                throw new Exception("查找个数不能小于0个或者集合中的元素个数自查找的索引器没有了要查找元素的个数");
            }
            if (match == null)
            {
                throw new Exception("条件不能为空");
            }
            int index = startindex + count;//开始出的索引加上要查找几个等于查找的索引的区间
            for (int i = 0; i < index; i++)
            {
                if (match(_array[i]))
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion

        #region 是否存在匹配指定条件的元素+Exists(内置委托.Predicate<T> match)
        /// <summary>
        /// 是否存在匹配指定条件的元素
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public bool Exists(内置委托.Predicate<T> match)
        {
            if (match == null)
            {
                throw new Exception("判断条件不能为空");
            }
            for (int i = 0; i < this.Count; i++)
            {
                if (match(_array[i]))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 对集合中的每一个元素执行同一个方法+ForEach(内置委托.Action<T> action)
        /// <summary>
        /// 对集合中的每一个元素执行同一个方法
        /// </summary>
        /// <param name="action"></param>
        public void ForEach(内置委托.Action<T> action)
        {
            if (action == null)
            {
                throw new Exception("执行方法不能为空");
            }
            for (int i = 0; i < this.Count; i++)
            {
                action(_array[i]);
            }
        }
        #endregion

        #region 排序+Sort()（基于快速排序）
        public void Sort()
        {
            this.Sort(0, this.Count-1, null);
        }
        public void Sort(系统内置接口.IComparer<T> comparer)
        {
            this.Sort(0, this.Count-1, comparer);
        }
        public void Sort(int start, int last,系统内置接口.IComparer<T> comparer)
        {
            SortHelper<T> sort = new SortHelper<T>(this._array);
            sort.QuickSort(_array, start, last,comparer);
        }
        #endregion

        #region 枚举器+GetEnumerator()
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this._array,this._count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取当前的聚合中的所有的元素的个数
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return this.Count;
        }
        #endregion
    }
}
