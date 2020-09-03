using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自己写的泛型
{
    public class GenericList<T>:IEnumerable
    {
        #region 私有字符串数组
        /// <summary>
        /// 私有字符串数组
        /// </summary>
        private T[] _obj = new T[4]; 
        #endregion

        #region 数组中实际存储的个数+count
        int count = 0;
        /// <summary>
        /// 数组中实际存储的个数
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        #endregion

        #region 新增+Add(T obj)
        /// <summary>
        /// 新增
        /// </summary>
        public void Add(T obj)
        {
            //如果当前的数组存储的个数等于数组的长度那么数组就扩容
            if (count == _obj.Length)
            {
                //新建一个数组
                T[] _newobj = new T[_obj.Length * 2];
                //把旧数组中的所有的数据复制到新的数组中
                _obj.CopyTo(_newobj, 0);
                //重新指定数组的引用
                _obj = _newobj;
            }
            _obj[count] = obj;
            count++;
        }
        //public void add(string str)
        //{
        //    //往数组中添加元素，判断是否为空，为空就放入这个位置，跳出循环
        //    //for (int i = 0; i < _str.Length; i++)
        //    //{
        //    //    if (_str[i]!=null)
        //    //    {
        //    //        _str[i] = str;
        //    //        break;
        //    //    }
        //    //}
        //    if (count==_str.Length)
        //    {
        //        string[] temp=new string[_str.Length*2];
        //        _str.CopyTo(temp, 0);
        //        _str = temp;
        //    }
        //    _str[count]=str;
        //    count++;

        //}
        #endregion

        #region 根据指定的下标删除数组中的数据+RemoveAt(int index)
        /// <summary>
        /// 根据索引删除数组中的元素
        /// </summary>
        /// <param name="index">数组索引</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index > _obj.Length)
            {
                throw new Exception("数组越界了");
            }
            Array.Copy(_obj, index + 1, _obj, index, _obj.Length - index - 1);

        }
        #endregion

        #region 索引器，编辑获取指定下标数据+string this[int index]
        /// <summary>
        /// 通过索引器来获取数组中的值和修改数组中的值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > _obj.Length)
                {
                    throw new Exception("数组越界了");
                }
                return _obj[index];
            }
            set
            {
                if (index < 0 || index > _obj.Length)
                {
                    throw new Exception("数组越界了");
                }
                else
                {
                    _obj[index] = value;
                }
            }
        }
        #endregion

        #region 查找符合的条件的单个实体+Find(Predicate<T> match)
        /// <summary>
        /// 查找符合的条件的单个实体
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public T Find(Predicate<T> match)
        {
            if (match==null)
            {
                throw new Exception("查询条件不能为空");
            }
            for (int i = 0; i < this.count; i++)
            {
                if (match(this._obj[i]))
                {
                    return this._obj[i];
                }
            }
            //如果没有找到就返回默认的值
            return default(T);
        } 
        #endregion

        #region 返回符合条件的集合+FindAll(Predicate<T> match)
        /// <summary>
        /// 判断集合中是否有符合条件的数据，返回符合条件的集合
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public GenericList<T> FindAll(Predicate<T> match)
        {
            GenericList<T> list = new GenericList<T>();
            if (match==null)
            {
                throw new Exception("条件不能为空");
            }
            //当前的数组中存储的实际元素的个数
            for (int i = 0; i < this.count; i++)
            {
                if (match(this._obj[i]))
                {
                    list.Add(this._obj[i]);
                }
            }
            return list;
        } 
        #endregion

        #region 从集合的指定的位置开始查找指定的个数中符合条件的元素的索引+FindIndex(int startIndex, int searchCount, Predicate<T> match)
        /// <summary>
        /// 从集合的指定的位置开始查找指定的个数中符合条件的元素的索引
        /// </summary>
        /// <param name="startIndex">开始查找的位置</param>
        /// <param name="searchCount">查找的个数</param>
        /// <param name="match">查找的条件</param>
        /// <returns></returns>
        public int FindIndex(int startIndex, int searchCount, Predicate<T> match)
        {
            return -1;
        } 

        /// <summary>
        /// 从集合的指定的开始的位置查找符合查找条件的第一个元素的索引的位置
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        public int FindIndex(int startIndex, Predicate<T> match)
        {
            return -1;
        }

        /// <summary>
        /// 从集合中查找符合查找条件的第一个元素的索引的位置
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public int FindIndex(Predicate<T> match)
        {
            return -1;
        }

        #endregion

        /*
         *自己写的泛型集合,为这个泛型类添加扩展方法
         * 1.Where的扩展方法的实现
         * 2.Cast的扩展方法的实现//类型约束
         * 3.枚举器的实现
         */

        #region 枚举器+GetEnumerator()
        public IEnumerator GetEnumerator()
        {
            return new MyGenericEnumerator<T>(this._obj, this.count);
        } 
        #endregion
    }
}
