using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构
{
    /// <summary>
    /// 参考资料：http://blog.jobbole.com/85766/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyStack<T>
    {
        #region 私有字段
        /// <summary>
        /// 私有数组
        /// </summary>
        private T[] _arry;
        /// <summary>
        /// 当前数组中存储的数据的个数
        /// </summary>
        private int _size;
        /// <summary>
        /// 默认容量大小
        /// </summary>
        private const int _defaultCapaciti = 4; 
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数，初始化数组的容量
        /// </summary>
        public MyStack()
        {
            this._arry = new T[0];
        }
        /// <summary>
        /// 有参构造函数，用户可以自定义初始化Stack的大小
        /// </summary>
        /// <param name="initialCapacity"></param>
        public MyStack(int initialCapacity)
        {
            if (initialCapacity<0)
            {
                throw new Exception("初始化的长度不能小于0");
            }
            if (initialCapacity<4)
            {
                initialCapacity = 4;
            }
            this._arry=new T[initialCapacity];
        }
        #endregion

        #region 入栈
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (_size == _arry.Length)
            {
                //第一次往栈里面添加数据的时候
                if (_size==0)
                {
                    _arry = new T[_defaultCapaciti];
                }
                else
                {
                    T[] temp = new T[_size * 2];
                    _arry.CopyTo(temp, 0);
                    //重新指向的索引
                    _arry = temp;
                }
            }
            _arry[_size] = item;
            _size++;
        } 
        #endregion

        #region 出栈
        public T Pop()
        {
            if (_size == 0)
            {
                throw new Exception("栈不能为空");
            }
            //最后一个数据的索引
            _size--;
            //出栈
            T result = _arry[_size];
            //最后一个数据出栈了，则就没有数据了，设为默认值default(T)
            _arry[_size] = default(T);
            return result;
        } 
        #endregion

        #region 返回栈的顶部的数据
        /// <summary>
        /// 返回栈的顶部的数据
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (_size <= 0)
            {
                throw new Exception("数组索引越界");
            }
            return _arry[_size - 1];
        } 
        #endregion
    }
}
