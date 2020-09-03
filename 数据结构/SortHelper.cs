using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构
{
    //快速排序参考地址：http://blog.csdn.net/chinalwb/article/details/9271535
    public class SortHelper<T>
    {
        #region 私有数组以及初始化
        /// <summary>
        /// 私有数组
        /// </summary>
        private T[] _array;
        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="_array"></param>
        public SortHelper(T[] _array)
        {
            this._array = _array;
        } 
        #endregion

        #region 快速排序+QuickSort(T[] _array, int start, int last, 系统内置接口.IComparer<T> comparer)
        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="_array">私有数组</param>
        /// <param name="start">开始位置</param>
        /// <param name="last">结束位置</param>
        /// <param name="comparer">比较器</param>
        public void QuickSort(T[] _array, int start, int last, 系统内置接口.IComparer<T> comparer)
        {
            //如果用户没有传入比较器，则调用默认的比较器
            if (comparer==null)
            {
                comparer = defaultComparer<T>.CreateComparer();
            }
            if (start < last)
            {
                int indexer = Devide(_array, start, last, comparer);
                QuickSort(_array, start, indexer - 1, comparer);
                QuickSort(_array, indexer + 1, last, comparer);
            }
        }
        /// <summary>
        /// 分治法===以第一个元素作为比较标准
        /// </summary>
        /// <param name="_array">数组</param>
        /// <param name="start">开始位置</param>
        /// <param name="last">结束位置</param>
        /// <param name="comparer">比较器</param>
        /// <returns></returns>
        private int Devide(T[] _array, int start, int last, 系统内置接口.IComparer<T> comparer)
        {
            T _temp = default(T);
            T standard = _array[start];//比较标准--以数组的第一个元素作为标准
            int left = start + 1;//左侧开始位置
            int right = last;//右侧开始位置
            while (left < right)
            {
                //从右侧往左开始寻找小于标准数的元素
                while (left < right && comparer.Compare(_array[right], standard)==1)
                {
                    right--;
                }
                //从左侧开始往右开始寻找大于标准数的元素
                while (left < right && comparer.Compare(_array[left], standard)==-1)
                {
                    left++;
                }
                //交换元素的位置
                if (left < right)
                {
                    Swap(_array, left, right);
                    //_temp = _array[left];
                    //_array[left] = _array[right];
                    _array[right] = _temp;
                }
            }
            //从左右两侧比较之后指向同一个元素
            _temp = standard;
            if (comparer.Compare(_temp, _array[left]) ==-1)
            {
                Swap(_array, start, left - 1);
                //_array[start] = _array[left - 1];
                //_array[left - 1] = _temp;
                return left - 1;
            }
            else
            {
                //else if (comparer.Compare(_temp, _array[left]) > 0)
                Swap(_array, start, left);
                //_array[start] = _array[left];
                //_array[left] = _temp;
                return left;
            }
        }
        #endregion

        #region 冒泡排序
        public void BubbleSort()
        {

        }

        #endregion

        #region 插入排序
        public void InsertionSort()
        {

        } 
        #endregion

        #region 元素交换的方法+Swap(T[] _array, int i, int j)
        /// <summary>
        /// 元素交换的方法
        /// </summary>
        /// <param name="_array">私有数组</param>
        /// <param name="i">交换元素1索引</param>
        /// <param name="j">交换元素2索引</param>
        private void Swap(T[] _array, int i, int j)
        {
            T local = _array[i];
            _array[i] = _array[j];
            _array[j] = local;
        } 
        #endregion
    }
    #region 默认比较器+defaultComparer
    public class defaultComparer<T>
    {
        private static MydefaultComparer<T> instance;
        public static MydefaultComparer<T> CreateComparer()
        {
            if (instance==null)
            {
                return new MydefaultComparer<T>();
            }
            return instance;
        }
    }
    /// <summary>
    /// 默认的比较器  1.根据对象的hashcode的值进行比较作为默认的比较器（不一定完全正确）2.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MydefaultComparer<T> : 系统内置接口.IComparer<T>
    {
        public int Compare(T x, T y)
        {
            int int1 = x.GetHashCode();
            int int2 = y.GetHashCode();
            if (int1 > int2)
                return 1;
            else if (int1 == int2)
                return 0;
            else if (int1 < int2)
                return -1;
            else
                return 9999;
        }
    } 
    #endregion
}
