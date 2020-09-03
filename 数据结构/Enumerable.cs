using System;
using 数据结构非泛型;

namespace 数据结构
{
    /// <summary>
    /// 既然是对IEnumerable类型的扩展，那么这个类中的所有的方法都可以使用foreach
    /// 由于是自己写的，编译器不认识，所以使用for或者是没有实现语法糖的foreach
    /// </summary>
    public static class Enumerable
    {
        #region Where扩展方法
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, 内置委托.Func<TSource, bool> predicate)
        {
            if (source == null) throw new Exception("源数据不能为空");
            if (predicate == null) throw new Exception("条件不能为空");
            return WhereIterator(source, predicate);
        }
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, 内置委托.Func<TSource, int, bool> predicate)
        {
            if (source == null) throw new Exception("源数据不能为空");
            if (predicate == null) throw new Exception("条件不能为空");
            return WhereAndIndexIterator(source, predicate);
        }
        /// <summary>
        /// Where筛选，Func中的参数是当前元素
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        static IEnumerable<TSource> WhereIterator<TSource>(IEnumerable<TSource> source, 内置委托.Func<TSource, bool> predicate)
        {
            MyList<TSource> list = new MyList<TSource>();
            IEnumerator<TSource> tor = source.GetEnumerator();
            while (tor.MoveNext())
            {
                if (predicate(tor.Current))
                {
                    list.Add(tor.Current);
                    //yield return tor.Current;//应该是不能使用yield return,本来是这么写的，代码更加的优雅
                }
            }
            return list;
        }
        /// <summary>
        /// Where筛选，Func中的参数是当前遍历到的元素和当前遍历到的元素的索引值
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        static IEnumerable<TSource> WhereAndIndexIterator<TSource>(IEnumerable<TSource> source, 内置委托.Func<TSource, int, bool> predicate)
        {
            MyList<TSource> list = new MyList<TSource>();
            IEnumerator<TSource> tor = source.GetEnumerator();
            int index = -1;
            while (tor.MoveNext())
            {
                checked { index++; }
                if (predicate(tor.Current, index))
                {
                    list.Add(tor.Current);
                }
            }
            return list;
        }
        #endregion

        #region Select扩展方法
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null) throw new Exception("源数据不能为空");
            if (selector == null) throw new Exception("条件不能为空");
            return SelectIterator<TSource, TResult>(source, selector);
        }
        public static IEnumerable<TSource> Select<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> selector)
        {
            if (source == null) throw new Exception("源数据不能为空");
            if (selector == null) throw new Exception("条件不能为空");
            return SelectAndIndexIterator(source, selector);
        }
        /// <summary>
        /// Select筛选，筛选符合条件的元素返回列表
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> SelectIterator<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            MyList<TResult> list = new MyList<TResult>();
#warning 实现不了获取当前元素的索引
            //使用接口中的GetCount方法
            //for (int i = 0; i < source.GetCount(); i++)
            //{
            //    if (selector(source[i]))//无法使用索引器，那么只能在接口中定义一个,获取不到当前元素的索引
            //    {

            //    }
            //}
            IEnumerator<TSource> tor = source.GetEnumerator();
            while (tor.MoveNext())
            {
                list.Add(selector(tor.Current));
            }
            return list;
        }
        /// <summary>
        /// Select筛选，筛选符合条件的元素返回列表，参数是当前的元素和索引
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> SelectAndIndexIterator<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> selector)
        {
            MyList<TSource> list = new MyList<TSource>();
            IEnumerator<TSource> tor = list.GetEnumerator();
            int index = -1;
            while (tor.MoveNext())
            {
                checked { index++; }
                if (selector(tor.Current, index))
                {
                    list.Add(tor.Current);
                }
            }
            return list;
        }
        #endregion

        #region SelectMany扩展方法
        public static IEnumerable<TSource> SelectMany<TSource>(this IEnumerable<TSource> source)
        {
            return new MyList<TSource>();
        } 
        #endregion

        #region Take扩展方法
        /// <summary>
        /// 顺序的获取指定的数量的数据
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null) throw new Exception("源数据不能为空");
            return TakeIterator(source, count);
        }
        public static IEnumerable<TSource> TakeIterator<TSource>(this IEnumerable<TSource> source, int count)
        {
            MyList<TSource> list = new MyList<TSource>();
            IEnumerator<TSource> tor = source.GetEnumerator();
            if (count > 0)
            {
                while (tor.MoveNext())
                {
                    list.Add(tor.Current);
                    count--;
                    if (count <= 0)
                        break;
                }
            }
            return list;
        }
        #endregion

        #region Skip扩展方法
        /// <summary>
        /// 跳过count个数据取得后面的所有数据
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null) throw new Exception("源数据不能为空");
            return SkipIterator(source, count);
        }
        public static IEnumerable<TSource> SkipIterator<TSource>(this IEnumerable<TSource> source, int count)
        {
            MyList<TSource> list = new MyList<TSource>();
            IEnumerator<TSource> tor = list.GetEnumerator();
            //count>0，那么就使游标的位置向下移动一个位置,并且保证下一个位置是有元素存在
            if (count > 0)
            {
                while (tor.MoveNext())
                {
                    count--;
                    if (count <= 0)
                    {
                        while (tor.MoveNext())
                        {
                            list.Add(tor.Current);
                        }
                    }
                }
            }
            //while (count > 0 && tor.MoveNext())
            //{
            //    count--;
            //}
            //while (count <= 0 && tor.MoveNext())
            //{
            //    list.Add(tor.Current);
            //}
            return list;
        }
        #endregion

        #region Cast扩展方法
        public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source)
        {
            if (source == null) throw new Exception("源数据不能为空");
            return  CastIterator<TResult>(source);
        }
        public static IEnumerable<TResult>CastIterator<TResult>(this IEnumerable source)
        {
            return new MyList<TResult>();
        }
        #endregion

        #region OfType扩展方法
        /// <summary>
        /// 获取聚合中类型是TResult的所有的元素
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source)
        {
            if (source == null) throw new Exception("源数据不能为空");
            return OfTypeIterator<TResult>(source);
        } 
        public static IEnumerable<TResult>OfTypeIterator<TResult>(this IEnumerable source)
        {
            MyList<TResult> list = new MyList<TResult>();
            var tor = source.GetEnumerator();
            while (tor.MoveNext())
            {
                if (tor.Current is TResult) list.Add((TResult)tor.Current);
            }
            return new MyList<TResult>();
        }
        #endregion

#warning First和FirstOrDefault的区别在于：如果源数据没有数据Firs会抛出空异常，而FirstOrDefault会返回默认值
        #region First扩展方法 
        public static TSource First<TSource>(this IEnumerable<TSource> source)
        {
            return default(TSource);
        }
        public static TSource First<TSource>(this IEnumerable<TSource> source, 内置委托.Func<TSource, bool> predicate)
        {
            return default(TSource);
        } 
        #endregion

        #region FirstOrDefault扩展方法
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return default(TSource);
        }
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, 内置委托.Func<TSource, bool> predicate)
        {
            return default(TSource);
        } 
        #endregion

        #region Single扩展方法
        public static TSource Single<TSource>(this IEnumerable<TSource> source)
        {
            return default(TSource);
        }
        public static TSource Single<TSource>(this IEnumerable<TSource> source, 内置委托.Func<TSource, bool> predicate)
        {
            return default(TSource);
        }
        #endregion

        #region SingleOrDefault扩展方法
        public static TSorce SingleOrDefault<TSorce>(this IEnumerable<TSorce> source)
        {
            return default(TSorce);
        }
        public static TSorce SingleOrDefault<TSorce>(this IEnumerable<TSorce> source, 内置委托.Func<TSorce, bool> predicate)
        {
            return default(TSorce);
        }
        #endregion

        #region OrderBy扩展方法
        //public static IEnumerable<TSource> OrderBy<TSource,TKey>(this IEnumerable<TSource> source)
        //{

        //    return new OrderThenBySequence<TSource,TKey>()
        //}
        //public static IEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> source, 内置委托.Func<TSource, bool> predicate)
        //{
        //    return new MyList<TSource>();
        //} 
        #endregion

        #region OrderByDescending扩展方法
        public static IEnumerable<TSource> OrderByDescending<TSource>(this IEnumerable<TSource> source)
        {

            return new MyList<TSource>();
        }
        public static IEnumerable<TSource> OrderByDescending<TSource>(this IEnumerable<TSource> source, 内置委托.Func<TSource, bool> predicate)
        {

            return new MyList<TSource>();
        }
        #endregion
#warning 第一类的GroupBy:GroupBy还有一些需要完善的地方

        #region 第一类的GroupBy
        public static 数据结构.IEnumerable<系统内置接口.IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, 内置委托.Func<TSource, TKey> keyselector)
        {
            MyLookup<TKey, TSource> lookup = new MyLookup<TKey, TSource>(null);
            lookup.Create(source, keyselector, IdentityFunction<TSource>.Instance);
            return lookup.GetPerGroup();
        }
        public static 数据结构.IEnumerable<系统内置接口.IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, 内置委托.Func<TSource, TKey> keyselector, 内置委托.Func<TSource, TSource> elementselector)
        {
            MyLookup<TKey, TSource> lookup = new MyLookup<TKey, TSource>(null);
            lookup.Create(source, keyselector, elementselector);
            return lookup.GetPerGroup();
        }
        public static 数据结构.IEnumerable<系统内置接口.IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, 内置委托.Func<TSource, TKey> keyselector, 系统内置接口.IEqualityComparer<TKey> comparer)
        {
            MyLookup<TKey, TSource> lookup = new MyLookup<TKey, TSource>(comparer);
            lookup.Create(source, keyselector, IdentityFunction<TSource>.Instance);
            return lookup.GetPerGroup();
        }
        public static 数据结构.IEnumerable<系统内置接口.IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, 内置委托.Func<TSource, TKey> keyselector, 内置委托.Func<TSource, TSource> elementselector, 系统内置接口.IEqualityComparer<TKey> comparer)
        {
            MyLookup<TKey, TSource> lookup = new MyLookup<TKey, TSource>(comparer);
            lookup.Create(source, keyselector, elementselector);
            return lookup.GetPerGroup();
        }

        public static System.Collections.Generic.IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source, 内置委托.Func<TSource, TKey> keyselector, 内置委托.Func<TSource, TElement> elementselector, Func<TKey, System.Collections.Generic.IEnumerable<TElement>,TResult>resultselector)
        {
            MyLookup<TKey, TElement> lookup = new MyLookup<TKey, TElement>(null);
            lookup.Create(source, keyselector, elementselector);
            return lookup.StaticResult(resultselector);
        }
        public static System.Collections.Generic.IEnumerable<TResult> GroupBy<TSource, TKey,TResult>(this IEnumerable<TSource> source, 内置委托.Func<TSource, TKey> keyselector, Func<TKey, System.Collections.Generic.IEnumerable<TSource>, TResult> resultselector)
        {
            MyLookup<TKey, TSource> lookup = new MyLookup<TKey, TSource>(null);
            lookup.Create(source, keyselector, IdentityFunction<TSource>.Instance);
            return lookup.StaticResult(resultselector);
        }
        #endregion


#warning 为什么第一个方法的枚举器要释放
        #region Any扩展方法
        /// <summary>
        /// 判断聚合中是否存在元素
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool Any<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new Exception("源数据不能为空");
            IEnumerator<TSource> tor = source.GetEnumerator();
            while (tor.MoveNext())
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 判断是否存在符合至少一个符合条件的元素
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool Any<TSource>(this IEnumerable<TSource> source, 内置委托.Func<TSource, bool> predicate)
        {
            if (source == null) throw new Exception("源数据不能为空");
            if (predicate == null) throw new Exception("条件不能为空");
            IEnumerator<TSource> tor = source.GetEnumerator();
            while (tor.MoveNext())
            {
                if (predicate(tor.Current)) return true;
            }
            return false;
        }
        #endregion

        #region All扩展方法
        /// <summary>
        /// 判断某个集合中的所有的元素是否都匹配条件
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool All<TSource>(this IEnumerable<TSource> source, 内置委托.Func<TSource, bool> predicate)
        {
            if (source == null) throw new Exception("源数据不能为空");
            if (predicate == null) throw new Exception("条件不能为空");
            var tor = source.GetEnumerator();
            while (tor.MoveNext())
            {
                if (!predicate(tor.Current)) return false;
            }
            return true;
        }
        #endregion

        #region Count扩展方法
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {

            return 1;
        }

        public static int Count<TSource>(this IEnumerable<TSource> source, 内置委托.Func<TSource, bool> predicate)
        {
            return 1;
        }
        #endregion

        #region Sum扩展方法
        public static int Sum<TSource>(this IEnumerable<TSource> source)
        {
            return 1;
        }
        public static int Sum<TSource>(this IEnumerable<TSource> source, 内置委托.Func<TSource, bool> predicate)
        {
            return 1;
        } 
        #endregion

        #region Min扩展方法
        public static int Min<TSource>(this IEnumerable<TSource> source)
        {
            return 1;
        }
        public static int Min<TSource>(this IEnumerable<TSource> source, 内置委托.Func<TSource, bool> predicate)
        {
            return 1;
        } 
        #endregion

        #region Max扩展方法
        public static int Max<TSource>(this IEnumerable<TSource> source)
        {
            return 1;
        }
        public static int Max<TSource>(this IEnumerable<TSource> source, 内置委托.Func<TSource, bool> predicate)
        {
            return 1;
        } 
        #endregion

        #region ToList扩展方法
        public static MyList<TSource> ToList<TSource>(this IEnumerable<TSource> source)
        {
            return ToListIterator<TSource>(source);
        }
        public static MyList<TSource> ToListIterator<TSource>(this IEnumerable<TSource> source)
        {
            //调用MyList的构造函数
            return new MyList<TSource>(source);
        }
        #endregion

        #region ToLookup扩展方法

#warning 要明白最关键的一点事TKey和TElement是在调用ToLookup的时候确定的，TElement的类型是因为有了这个筛选的方法才确定了类型，如果没有就是原来的TSource
#warning ILookup<TKey, TSource>不对数据进行筛选，ILookup<TKey, TElement>对数据进行筛选

        #region ToLookup方法的重载
        public static 系统内置接口.ILookup<TKey, TSource> ToLookup<TKey, TSource>(this IEnumerable<TSource> source, 内置委托.Func<TSource, TKey> keyselector, 系统内置接口.IEqualityComparer<TKey> comparer)
        {
            MyLookup<TKey, TSource> lookup = new MyLookup<TKey, TSource>(comparer);
            lookup.Create(source, keyselector, 数据结构.IdentityFunction<TSource>.Instance);
            return lookup;
        }
        public static 系统内置接口.ILookup<TKey, TSource> ToLookup<TKey, TSource>(this IEnumerable<TSource> source, 内置委托.Func<TSource, TKey> keyselector)
        {
            return ToLookup(source, keyselector, IdentityFunction<TSource>.Instance, null);
        }

        public static 系统内置接口.ILookup<TKey, TElement> ToLookup<TKey, TSource, TElement>(this IEnumerable<TSource> source, 内置委托.Func<TSource, TKey> keyselector, 内置委托.Func<TSource, TElement> elementselector)
        {
            return ToLookup(source, keyselector, elementselector, null);
        } 
        #endregion

        #region 基本的ToLookup方法
        /// <summary>
        /// 基本的ToLookup方法
        /// </summary>
        /// <typeparam name="TKey">分组的键</typeparam>
        /// <typeparam name="TSource">数据源中的每一个实体</typeparam>
        /// <typeparam name="TElement">筛选后的数据</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="keyselector">选择分组键的方法</param>
        /// <param name="elementselector">筛选要选取的数据</param>
        /// <param name="comparer">用户定义的比较器</param>
        /// <returns></returns>
        public static 系统内置接口.ILookup<TKey, TElement> ToLookup<TKey, TSource, TElement>(this IEnumerable<TSource> source, 内置委托.Func<TSource, TKey> keyselector, 内置委托.Func<TSource, TElement> elementselector, 系统内置接口.IEqualityComparer<TKey> comparer)
        {
            MyLookup<TKey, TElement> lookup = new MyLookup<TKey, TElement>(comparer);
            lookup.Create(source, keyselector, elementselector);
            return lookup;
        }  
        #endregion

        #endregion
    }

    internal class IdentityFunction<TElement>
    {
        public static 内置委托.Func<TElement, TElement> Instance
        {
            get { return x => x; }
        }
    }
}
