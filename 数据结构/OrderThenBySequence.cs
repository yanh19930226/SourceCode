using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 数据结构非泛型;

namespace 数据结构
{
    /*排序的思想：
     * OrderBy And ThenBy的多条件排序：降低时间复杂度，根据最后一个条件排序得到序列，如果得到的新的序列存在相同的位置那么在根据倒数第二个的条件对
     * 得到的新的序列进行排序在得到一个新的序列,以此类推。。。。。。
     * 
     * =====排序的总体的思路：排序的数据源；排序的条件，如果进行多次的排序
     * =====那么就需要保存多次的数据源和每一次的排序的条件，通过链表的思想把这些条件互相的关联
     * 
     *排序后得到的一个序列集合 
     * 成员：
     * 1.保存要排序的数据源 
     * 2.保存需要进行排序的字段
     * 3.如果要进行多条件排序，则需要保存上一次传入的排序的序列
     * 4.需要传入自定义的快排的比较器
     * 5.序列还需要提供对外界进行遍历的功能：GetEnumerator()  Or  whatever(只是一个名字而已)
     * 
     * =====进行遍历的时候创建排序的比较器：第一次遍历的时候传入的序列是最后一次创建的序列每一个序列通过链表的形式互相的关联起来
     * =====所以所对应的所有的初始的条件都是该序列相关的值
     * 
     * =====根据每一个序列创建的对应的sorter也是通过链表的形式进行相关联的，第一次创建的sorter是最后一个序列的sorter通过递归
     * 和链表的形式把所有的sorter连接起来
     * 
     *sorter类的成员(**************保存的key是从后往前的，也就是orderby=>thenby1=>thenby2=>。。。。key[thenby2]=>key[thenby1]=>orderby)
     * 一个Key数组用来保存要排序字段执行方法之后的值
     * 一个next用来保存如果根据第一次排序存在相同的位置那么就调用上一个比较器对相等的元素进行排序
     * 在根据要排序的元素的个数生成一个保存Key数组的下标的数组
     * 
     * 最后，还是根据快排的思想根据传入的比较器比较Key数组保存的数据
     * 
     * 
     * =====泛型参数喜欢怎么定义就怎么定义,不要被一些概念什么的所拘束
     * 
     */
    public class OrderThenBySequence<TSource,TKey>:系统内置接口.IOrderThenBy<TSource>
    {
        #region 假设不成立以后再来实现吧
        //====假设这个保存执行之后的数组是存放在自己的类中的=====
        /// <summary>
        /// 用来保存执行过keyselector之后的元素
        /// </summary>
        //TKey[] _keyarray; 
        #endregion

        #region 私有字段成员
        /// <summary>
        /// 用来存储需要排序的数据源
        /// </summary>
        internal 数据结构.IEnumerable<TSource> source;
        /// <summary>
        /// 进行排序字段的筛选方法
        /// </summary>
        private 内置委托.Func<TSource, TKey> keyselector;
        /// <summary>
        /// 记录上一次创建的序列
        /// </summary>
        private OrderThenBySequence<TSource, TKey> parent;
        /// <summary>
        /// 排序的比较器
        /// </summary>
        private 系统内置接口.IComparer<TKey> comparer; 
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keyselector"></param>
        public OrderThenBySequence(数据结构.IEnumerable<TSource> source, 内置委托.Func<TSource, TKey> keyselector,系统内置接口.IComparer<TKey>comparer)
        {
            if (source == null) throw new Exception("需要排序的数据源不能为空");
            if (keyselector == null) throw new Exception("需要排序的字段不能为空");
            this.comparer = comparer;
            this.source = source;
            this.keyselector = keyselector;
            this.parent = null;//如果是orderby那么就说明只需要创建一个序列，也就没有了父级序列
            //如果用户没有定义默认的比较器就使用系统默认的比较器
            if (this.comparer == null)
            {
                数据结构.Comparer<TKey> comparerclass = new Comparer<TKey>();
                this.comparer = comparerclass.Default;
            }
        }
        #endregion

        #region 为外界提供的一个的枚举器+GetEveryElement()
        //为外界提供一个获取这个已经排序好的序列的方法
        public 数据结构.IEnumerable<TSource> GetEveryElement()
        {
            #region 假设以后再来实现吧
            //把本地的数据源转化成数组的形式，再调用数组的快排的方法(或者在sorthelper中定义一个新的快排的方法 as you like)

            //假设1:对序列的每一个元素执行Keyselector的方法，并且把它保存到一个Key的数组中，只有当外界对这个序列进行枚举的时候这个Key数组才会被初始化
            //假设2:对数据源中的每一个元素执行keyselector的方法,如果这个序列是需要进行多条件排序那么必须把每一次的排序的条件保存起来
            //保存的keyselector的数组是按照倒序的条件进行排序的
            //MyList<TSource> templist = this.source.ToList();
            //_keyarray = new TKey[templist.Count];
            //for (int i = 0; i < templist.Count; i++)
            //{
            //    _keyarray[i] = this.keyselector(templist[i]);
            //}
            ////用来保存Key数组的下标值
            //int[] map = new int[templist.Count];
            //for (int i = 0; i < templist.Count; i++)
            //{
            //    map[i] = i;
            //} 
            #endregion

            //把本地的数据源转化成数组的形式或者调用转化成List的形式
            ChangeSource<TSource> local = new ChangeSource<TSource>();
            local.SourceToArray(this.source);
            MyOrderThenBySorter<TSource, TKey> sorter = GetSorter(local._temp,null);
            int[] final=sorter.Sort();
            //根据final的数组的下标把元素遍历出来，实现最终的排序
            //[8,3,4,5,6,7,2]
            MyList<TSource> list = new MyList<TSource>();
            for (int i = 0; i < final.Length; i++)
            {
                list.Add(local._temp[final[i]]);
            }
            return list;
        }
        public MyOrderThenBySorter<TSource,TKey>GetSorter(TSource[] local,MyOrderThenBySorter<TSource, TKey> next)
        {
            MyOrderThenBySorter<TSource, TKey> sorter = new MyOrderThenBySorter<TSource, TKey>(local, this.keyselector,next,this.comparer);
            if (this.parent != null) sorter = this.parent.GetSorter(local, sorter);
            return sorter;
        }
        #endregion

        


        #region 调用ThenBy的时候创建序列调用的方法
        /// <summary>
        ///当OrderBy之后进行ThenBy的序列的创建的时候调用的方法,接受必须进行OrderBy之后的参数(IOrderThenBy类型的参数)
        /// </summary>
        /// <param name="afterorderbysource">IOrderThenBy的数据类型</param>
        /// <param name="thenbyKeySelector">ThenBy需要执行的方法</param>
        /// <returns></returns>
        public 数据结构.OrderThenBySequence<TSource, TKey> CreateForThenBy(内置委托.Func<TSource, TKey> thenbyKeySelector,系统内置接口.IComparer<TKey>comparer)
        {
            数据结构.OrderThenBySequence<TSource, TKey> thenbysource = new OrderThenBySequence<TSource, TKey>(source, thenbyKeySelector, comparer);
            thenbysource.parent = this;//this表示的当前的类，某个类的实例的对象.方法,那么在这个方法中的this就是这个 实例对象
            return thenbysource;
        } 
        #endregion

        #region 数据结构.IEnumerable的接口的方法
        public IEnumerator<TSource> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
    /// <summary>
    /// 排序的比较器
    /// 成员:
    /// 1.筛选排序的条件的方法keyselector
    /// 2.一个用来保存执行方法后的key的数组
    /// 3.用来保存下一个比较器的私有的字段
    /// 4.计算排序条件链表的方法
    /// 5.排序的最基本算法快排
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public class MyOrderThenBySorter<TMySource, TMyKey>
    {
        #region 私有字段成员
        private TMySource[] needtoexcute;
        /// <summary>
        /// 私有数组
        /// </summary>
        private TMyKey[] keys;
        /// <summary>
        /// 比较条件筛选方法
        /// </summary>
        private 内置委托.Func<TMySource, TMyKey> keyselector;
        /// <summary>
        /// 下一个比较器的引用
        /// </summary>
        private MyOrderThenBySorter<TMySource, TMyKey> next;
        /// <summary>
        /// sorter比较器
        /// </summary>
        private 系统内置接口.IComparer<TMyKey> comparer;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="needtoexcute">把已经转化成数组形式的数据源传入执行条件筛选形成key数组</param>
        /// <param name="keyselector">条件筛选方法</param>
        /// <param name="next">比较器的下一个引用</param>
        /// <param name="comparer">这个sorter的比较器</param>
        public MyOrderThenBySorter(TMySource[] needtoexcute, 内置委托.Func<TMySource, TMyKey> keyselector, MyOrderThenBySorter<TMySource, TMyKey> next,系统内置接口.IComparer<TMyKey>comparer)
        {
            this.needtoexcute = needtoexcute;
            this.keyselector = keyselector;
            this.next = next;
            this.comparer = comparer;
        }
        #endregion
        public int[] Sort()
        {
            MyComputeKey();
            //生成对应的key的下标的数组
            int[] map = new int[this.keys.Length];
            for (int i = 0; i < this.keys.Length; i++)
            {
                map[i] = i;
            }
            //调用快速排序需要传入当前比较器的keys数组
            QuickSort(map, 0, map.Length - 1);
            //比较完的map集合现在就是元素的排序的下标
            return map;

        }
        /// <summary>
        /// 计算所有的根据keySelector组成的数组
        /// </summary>
        public void MyComputeKey()
        {
            keys = new TMyKey[needtoexcute.Length];
            //对本地的数据源或者数组执行筛选的方法
            for (int i = 0; i < needtoexcute.Length; i++)
            {
                this.keys[i] = this.keyselector(needtoexcute[i]);
            }
            if (this.next != null)
            {
                this.next.MyComputeKey();
            }
        }
        /// <summary>
        /// 对筛选的key的数组中的两个值进行对比,返回的结果有:1,-1,大于0,小于0;如果两个数相等并且存在下一个比较器，就调用下一个比较器,如果不存在下一个比较器,就使用key的两个下标值进行相减
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public int MyCompareKey(int index1,int index2)
        {
            int result = this.comparer.Compare(keys[index1], keys[index2]);
            //如果根据比较器这两个结果是相等的
            if (result==0)
            {
                //这个比较器已经是最后一个比价器了
                if (this.next == null) return index1 - index2;
                   return  this.next.MyCompareKey(index1, index2);
            }
            return result;
        }

        public void QuickSort(int[] _array, int start, int last)
        {
            if (start < last)
            {
                int _keyindex = Devide(_array, start, last);
                QuickSort(_array, start, _keyindex - 1);
                QuickSort(_array, _keyindex + 1, last);
            }
        }
        /// <summary>
        /// 以第一个元素为基准的快速排序
        /// </summary>
        /// <param name="_temp"></param>
        /// <param name="start"></param>
        /// <param name="last"></param>
        public int Devide(int[] _array, int start, int last)
        {
            int left = start + 1;//左边计数
            int right = last;//右边计数
            int standard = _array[start];//排序标准值，已数组的第一个元素作为标准值
            int _temp;
            while (left < right)
            {
                //从右侧往左走，找到比基准元素小的位置(把这个地方换成比较器的比较的方法)
                while (left < right && MyCompareKey(_array[right], standard)>0)
                {
                    right--;
                }
                //从左侧往右走，找到比基准元素大的位置(把这个地方换成比较器的比较的方法)
                //为什么这里是小于等于呢？
                while (left < right && MyCompareKey(_array[left], standard)<=0)
                {
                    left++;
                }
                //如果左位置小于右位置进行交换
                if (left < right)
                {
                    _temp = _array[right];
                    _array[right] = _array[left];
                    _array[left] = _temp;
                }
            }
            //经过while的循环实现了left=right
            _temp = standard;
            if (MyCompareKey(_temp,_array[left])>0)
            {
                //把这个相等的数和基准数交换
                _array[start] = _array[left];
                _array[left] = _temp;
                return left;
            }
            else
            {
                //如果_temp小于这个坐标相等的数那么就插入这个相等的数的前面
                _array[start] = _array[left - 1];
                _array[left - 1] = _temp;
                return left - 1;
            }
        }


        #region 第二种快速排序
        //public static void QuickSort(int[] _array, int start, int last)
        //{
        //    if (start < last)
        //    {
        //        int _keyindex = Devide(_array, start, last);
        //        QuickSort(_array, start, _keyindex - 1);
        //        QuickSort(_array, _keyindex + 1, last);
        //    }
        //}
        ///// <summary>
        ///// 以第一个元素为基准的快速排序
        ///// </summary>
        ///// <param name="_temp"></param>
        ///// <param name="start"></param>
        ///// <param name="last"></param>
        //public static int Devide(int[] _array, int start, int last)
        //{
        //    int left = start + 1;//左边计数
        //    int right = last;//右边计数
        //    int standard = _array[start];//排序标准值，已数组的第一个元素作为标准值
        //    int _temp;
        //    while (left < right)
        //    {
        //        //从右侧往左走，找到比基准元素小的位置(把这个地方换成比较器的比较的方法)
        //        while (left < right && _array[right] > standard)
        //        {
        //            right--;
        //        }
        //        //从左侧往右走，找到比基准元素大的位置(把这个地方换成比较器的比较的方法)
        //        while (left < right && _array[left] <= standard)
        //        {
        //            left++;
        //        }
        //        //如果左位置小于右位置进行交换
        //        if (left < right)
        //        {
        //            _temp = _array[right];
        //            _array[right] = _array[left];
        //            _array[left] = _temp;
        //        }
        //    }
        //    //经过while的循环实现了left=right
        //    _temp = standard;
        //    if (_temp > _array[left])
        //    {
        //        //把这个相等的数和基准数交换
        //        _array[start] = _array[left];
        //        _array[left] = _temp;
        //        return left;
        //    }
        //    else
        //    {
        //        //如果_temp小于这个坐标相等的数那么就插入这个相等的数的前面
        //        _array[start] = _array[left - 1];
        //        _array[left - 1] = _temp;
        //        return left - 1;
        //    }
        //} 
        #endregion

        #region 泛型快排
        //public void QuickSort(int[] _array, int start, int last, 系统内置接口.IComparer<TMySource> comparer)
        //{
        //    //如果用户没有传入比较器，则调用默认的比较器
        //    if (comparer == null)
        //    {
        //        comparer = defaultComparer<TMySource>.CreateComparer();
        //    }
        //    if (start < last)
        //    {
        //        int indexer = Devide(_array, start, last, comparer);
        //        QuickSort(_array, start, indexer - 1, comparer);
        //        QuickSort(_array, indexer + 1, last, comparer);
        //    }
        //}
        ///// <summary>
        ///// 分治法===以第一个元素作为比较标准
        ///// </summary>
        ///// <param name="_array">数组</param>
        ///// <param name="start">开始位置</param>
        ///// <param name="last">结束位置</param>
        ///// <param name="comparer">比较器</param>
        ///// <returns></returns>
        //private int Devide(TMyKey[] _array, int start, int last, 系统内置接口.IComparer<TMySource> comparer)
        //{
        //    TMySource _temp = default(TMySource);
        //    TMySource standard = _array[start];//比较标准--以数组的第一个元素作为标准
        //    int left = start + 1;//左侧开始位置
        //    int right = last;//右侧开始位置
        //    while (left < right)
        //    {
        //        //从右侧往左开始寻找小于标准数的元素
        //        while (left < right && comparer.Compare(_array[right], standard) == 1)
        //        {
        //            right--;
        //        }
        //        //从左侧开始往右开始寻找大于标准数的元素
        //        while (left < right && comparer.Compare(_array[left], standard) == -1)
        //        {
        //            left++;
        //        }
        //        //交换元素的位置
        //        if (left < right)
        //        {
        //            Swap(_array, left, right);
        //            _array[right] = _temp;
        //        }
        //    }
        //    //从左右两侧比较之后指向同一个元素
        //    _temp = standard;
        //    if (comparer.Compare(_temp, _array[left]) == -1)
        //    {
        //        Swap(_array, start, left - 1);
        //        return left - 1;
        //    }
        //    else
        //    {
        //        Swap(_array, start, left);
        //        return left;
        //    }
        //}

        //#region 元素交换的方法+Swap(T[] _array, int i, int j)
        ///// <summary>
        ///// 元素交换的方法
        ///// </summary>
        ///// <param name="_array">私有数组</param>
        ///// <param name="i">交换元素1索引</param>
        ///// <param name="j">交换元素2索引</param>
        //private void Swap(TMySource[] _array, int i, int j)
        //{
        //    TMySource local = _array[i];
        //    _array[i] = _array[j];
        //    _array[j] = local;
        //} 
        #endregion
    }
        /// <summary>
        /// 把一个IEnumerable数据类型的源数据转化为数组形式的数据源的帮助类
        /// 类的成员：
        /// 一个接收数组的私有字段
        /// 一个把 源数据转化为数组形式的方法
        /// </summary>
        /// <typeparam name="TNeedChange"></typeparam>
        internal class ChangeSource<TNeedChange>
    {
        /// <summary>
        ///用来接收数据的数组
        /// </summary>
        internal TNeedChange[] _temp;
        
        public void SourceToArray(数据结构.IEnumerable<TNeedChange>changesource)
        {
            //微软源代码数据转化的方法：1.如果数据源实现了ICollection 的接口则可以把数据进行
            //根据数组的方法的形式进行转化 2.另一个方法是通用的一种转化的方法
            //====自定义的数据没有自定义的ICollection的接口
            MyList<TNeedChange> templist = new MyList<TNeedChange>();
            templist = changesource.ToList();
            if (templist.Count>0)
            {
                this._temp = new TNeedChange[templist.Count];
                for (int i = 0; i < templist.Count; i++)
                {
                    _temp[i] = templist[i];
                }
            }
        }
    }
}
