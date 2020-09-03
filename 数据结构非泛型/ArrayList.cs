using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构非泛型
{
    public class ArrayList:IEnumerable
    {
        #region 私有数据
        /// <summary>
        /// 私有object数组
        /// </summary>
        private object[] _array;
        /// <summary>
        /// 默认ArrayList容量
        /// </summary>
        private int _defaultcapacity = 4;
        public int Defaultcapacity
        {
            get { return _array.Length; }
        }
        /// <summary>
        /// ArrayList实际存储的元素个数
        /// </summary>
        private int _count;
        public int Count
        {
            get { return _count; }
        } 
        #endregion

        #region 构造函数
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public ArrayList()
        {
            _array = new object[0];
        }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="capacity"></param>
        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new Exception("初始化长度不能小于0");
            }
            if (capacity < _defaultcapacity)
            {
                capacity = _defaultcapacity;
            }
            _array = new object[capacity];
        } 
        #endregion

        #region 索引器
        public object this[int index]
        {
            get { return ""; }
            set { ; }
        } 
        #endregion

        #region 添加+Add(object item)
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item"></param>
        public void Add(object item)
        {
            if (_count == _array.Length)
            {
                if (_count == 0)
                    _array = new object[_defaultcapacity];
                else
                {
                    //数组扩容
                    object[] temp = new object[_count * 2];
                    //复制数据
                    _array.CopyTo(temp, 0);
                    //重新指定旧数组的引用
                    _array = temp;
                }
            }
            _array[_count] = item;
            _count++;
        } 
        #endregion

        public void Remove(object item)
        {

        }

        #region 根据指定的下标删除元素+RemoveAt(int index)
        /// <summary>
        /// 根据指定的下标删除元素
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _array.Length)
            {
                throw new Exception("索引越界了");
            }
            Array.Copy(_array, index + 1, _array, index, _array.Length - 1 - index);
        } 
        #endregion

        #region 枚举器
        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this._array);
        } 
        #endregion
    }
}
