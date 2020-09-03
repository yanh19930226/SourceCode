using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构
{
    internal class EqualityComparer<T>: 系统内置接口.IEqualityComparer<T>
    {
        #region 私有字段和属性+Default
        /// <summary>
        /// 默认比较器私有字段
        /// </summary>
        private 系统内置接口.IEqualityComparer<T> _defaultComparer;
        /// <summary>
        /// 属性用来获取一个默认比较器
        /// </summary>
        public 系统内置接口.IEqualityComparer<T> Default
        {
            get
            {
                if (_defaultComparer == null)
                {
                    _defaultComparer = CreateDefaultComparer();
                }
                return _defaultComparer;
            }
        }
        #endregion

        #region 获取默认比较器
        public static 系统内置接口.IEqualityComparer<T> CreateDefaultComparer()
        {
            //创建整形的比较器
            if (typeof(T) == typeof(Int32))
            {
                return (系统内置接口.IEqualityComparer<T>)new ComaparerForInt();
            }
            //创建字符串类型的比较器
            else if (typeof(T) == typeof(string))
            {
                return (系统内置接口.IEqualityComparer<T>)new ComparerForString();
            }
            else
            {
                return null;
            }
        } 
        #endregion

        #region 不同类型的默认比较器
        /// <summary>
        /// 整形比较器
        /// </summary>
        public class ComaparerForInt : 系统内置接口.IEqualityComparer<int>
        {
            public bool Equal(int x, int y)
            {
                return x == y;
            }
            public int GetHashCode(int obj)
            {
                return obj.GetHashCode();
            }
        }
        /// <summary>
        /// 字符串比较器
        /// </summary>
        public class ComparerForString : 系统内置接口.IEqualityComparer<string>
        {
            public bool Equal(string x, string y)
            {
                return x.Equals(y);
            }
            public int GetHashCode(string obj)
            {
                return obj.GetHashCode();
            }
        }
        #endregion

        #region 外部实现接口
        /// <summary>
        /// 这两个接口为了当有比较器传入的时候进行重写的操作
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// 
        public bool Equal(T x, T y)
        {
            throw new NotImplementedException();
        }
        public int GetHashCode(T obj)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
