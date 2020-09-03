using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 数据结构.系统内置接口;
using 数据结构非泛型;

namespace 数据结构
{
    /*
     * ==Lookup类是对实现了IEnumerable接口的枚举==
     * 
     * Lookup是对Grouping进行枚举
     * Grouping则是对组内的元素进行枚举
     * 字段和方法
     * Grouping[]:数组用来保存所有的组
     * lastGrouping:对Lookup类中的所有的Grouping形成一个循环链表时起作用
     * count:Lookup类中保存的不同的组的个数
     * 迭代获取每一个组
     * 根据Key来获取指定的组
     * 根据Key来迭代对应的组的每一个元素
     * 索引器：根据Key来获取对应的组
    */
    public  class MyLookup<TKey, TElement> : 系统内置接口.ILookup<TKey, TElement>
    {
        #region 私有字段
        //私有数组用来保存不同的键值Key得所有的Grouping
        private MyGrouping<TKey, TElement>[] groupings;
        //最后添加的一个Grouping
        private MyGrouping<TKey, TElement> lastGroup;
        //Lookup类中所保存的不同的组的个数
        private int count;
        //比较器用来确保传入进来的是否是相同的Key
        private 系统内置接口.IEqualityComparer<TKey> comparer;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="comparer"></param>
        internal MyLookup(系统内置接口.IEqualityComparer<TKey> comparer)
        {
            //如果没有传入比较器，那么就调用默认的比较器，默认的比较器是要根据传入的TKey的类型来去创建
            if (comparer == null)
            {
                数据结构.EqualityComparer<TKey> defaultcomparer = new EqualityComparer<TKey>();
                this.comparer = defaultcomparer.Default;
            }
            //设置grouping[]的默认的初始的大小
            groupings = new MyGrouping<TKey, TElement>[7];
        }
        #endregion

        #region 根据键来创建组+Create()
        internal void Create<TSource>(数据结构.IEnumerable<TSource> source, 内置委托.Func<TSource, TKey> keyselector, 内置委托.Func<TSource, TElement> elementselector)
        {
            //对数据集合每个元素进行遍历
            IEnumerator<TSource> tor = source.GetEnumerator();
            while (tor.MoveNext())
            {
                GetGrouping(keyselector(tor.Current), true).Add(elementselector(tor.Current));
            }
        } 
        #endregion

        #region 根据键计算出HashCode的值+InitialHashCode()
        /// <summary>
        /// 获取Key的HashCode的值,因为Key的HashCode值有可能是负数所有与0x7FFFFFFF进行与操作确保hashcode值为正数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int InitialHashCode(TKey key)
        {
            return (key == null) ? 0 : comparer.GetHashCode(key) & 0x7FFFFFFF;
        }
        /// <summary>
        /// 自定义获取HashCode的值的方法,取每一个Key的HashCode的绝对值的方法
        /// </summary>
        /// <returns></returns>
        public int MyInitialHashCode(TKey key)
        {
            return (key == null) ? 0 : Math.Abs(comparer.GetHashCode(key));
        }
        #endregion

        /// <summary>
        /// 对已经分完组的每一个组进行统计操作
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="resultselector"></param>
        /// <returns></returns>


#warning 这个地方还可以改进(换成自己的集合的返回的类型)
        public System.Collections.Generic.IEnumerable<TResult> StaticResult<TResult>(Func<TKey, System.Collections.Generic.IEnumerable<TElement>,TResult>resultselector)
        {
            MyGrouping<TKey,TElement> g = lastGroup;
            if (g != null)
            {
                do
                {
                    g = g.next;
                    if (g.count != g.temp.Length) { Array.Resize<TElement>(ref g.temp, g.count); }
                    yield return resultselector(g.key, g.temp);
#warning 这个地方为什么是不等于？
                } while (g != lastGroup);
                //while (g == lastGroup);
            }
        }

        #region 根据键值来获取对应的组或者创建对应的组+GetGrouping(TKey key, bool create)
        /// <summary>
        /// 根据键值来获取对应的组或者创建对应的组
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="create">是否创建新的组</param>
        /// <returns></returns>
        internal 数据结构.MyGrouping<TKey,TElement> GetGrouping(TKey key, bool create)
        {
            //1.根据每个对象的分组字段的值计算hashcode
            //2.根据hashcode获取这个对象在grouping[]中的索引
            //3.判断这个索引的位置是否存在元素(①：存在元素判断hashcode的值并根据比较器比较Key和当前的Key是否相等②:不存在元素，那么就创建一个新的组)
            //int hashCode = InitialHashCode(key);
            int hashCode = MyInitialHashCode(key);
            int index = hashCode % groupings.Length;
            for (MyGrouping<TKey, TElement> g = groupings[index]; g != null; g = g.hashNext)
            {
                if (g != null)
                    if (g.hashcode == hashCode && comparer.Equal(g.Key, key))
                        return g;
            }
            //在已有的存在的grouping的数组中都没有找到就创建对应的Grouping
            if (create)
            {
                //所有具有相同的HashCode、不同键的值得数据形成一条单链表
                //调用MyGrouping类的默认的容量来初始化Telement[] 数组的大小
                MyGrouping<TKey, TElement> newGrouping = new MyGrouping<TKey, TElement>();
                newGrouping.key = key;
                newGrouping.hashcode = hashCode;
                newGrouping.hashNext = groupings[index];
                groupings[index] = newGrouping;
                //使所有的元素形成一条循环链表
                if (lastGroup == null)
                {
                    newGrouping.next = newGrouping;
                    lastGroup = newGrouping;
                }
                else
                {
                    newGrouping.next = lastGroup.next;
                    lastGroup.next = newGrouping;
                    lastGroup = newGrouping;
                }
                this.count++;
                return newGrouping;
            }
            return null;
        } 
        #endregion

        #region 获取Lookup类中的组的个数+GetCount()
        /// <summary>
        /// 获取Lookup类中的所有的组的个数
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return this.count;
        }
        #endregion

        #region 根据键TKey获取对应的组的所有的元素
        /// <summary>
        /// 索引器根据键TKey获取对应的组
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal IEnumerable<TElement> this[TKey key]
        {
            get {
                MyGrouping<TKey, TElement> grouping = GetGrouping(key, false);
                if (grouping != null) return grouping;
                return null;
            }
        }
        
        #endregion

        #region 迭代器用来获取每一个Grouping+GetEnumerator()
        /// <summary>
        /// 迭代器用来获取每一个Grouping
        /// </summary>
        /// <returns></returns>
        public IEnumerator<系统内置接口.IGrouping<TKey, TElement>> GetEnumerator()
        {
            return new 数据结构.Enumerator<系统内置接口.IGrouping<TKey, TElement>>(groupings, this.count);
        }

        public 数据结构.IEnumerable<系统内置接口.IGrouping<TKey, TElement>>GetPerGroup()
        {
            MyList<系统内置接口.IGrouping<TKey, TElement>> list = new MyList<系统内置接口.IGrouping<TKey, TElement>>();
            MyGrouping<TKey, TElement> g = lastGroup;
            if (g != null)
            {
                do
                {
                    g = g.next;
                    list.Add(g);
                } while (g != lastGroup);
            }
            return list;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
