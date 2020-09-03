using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器模式之yield
{
    class Program
    {
        static void Main(string[] args)
        {

            #region yield1
            //var theArray = GetPassedScores();
            ////如果GetPassedScores被执行了,  
            ////应该能在此WriteLine之前看到输出的字符.  
            //Console.ReadKey();
            //Console.WriteLine("Invoked...");

            //foreach (int n in theArray)
            //{
            //    Console.Write("{0},  ", n);
            //}
            //Console.WriteLine();

            //Console.ReadKey();  
            //HelloCollection h = new HelloCollection();
            ////IEnumerator tor=h.GetEnumerator();
            //foreach (var item in h)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            ////while (tor.MoveNext())
            ////{
            ////    Console.WriteLine(tor.Current.ToString());      
            ////}
            //Console.ReadKey(); 
            #endregion

            #region yield 返回IEnumerable<T>
            var a = GetIntList();
            var tor = (IEnumerator<int>)a;
            while (tor.MoveNext())
            {
                Console.WriteLine(tor.Current.ToString());
            } 
            #endregion

            #region yield 返回IEnumerator<T>
            //Collectionlist li = new Collectionlist();
            //var a = li.GetEnumerator();
            //while (a.MoveNext())
            //{
            //    Console.WriteLine(a.Current.ToString());
            //} 
            #endregion

            Console.ReadKey();
        }

        static IEnumerable<int> GetPassedScores()
        {
            Console.WriteLine("Invoking GetPassedScores()...");
            int[] scores = { 43, 78, 40, 2, 99, 100, 0, 30, 59, 64, 89 };

            foreach (int s in scores)
            {
                if (s >= 60)
                {
                    yield return s;
                }
            }  

    }

        #region yield 返回IEnumerable<T>类型的方法
        public static IEnumerable<int> GetIntList()
        {
            yield return 1;
            yield return 2;///这些数据是全部的存放到MoveNext的一个状态机里面的
            yield return 3;
        } 
        #endregion
    }

    #region yield 返回IEnumerator<T>
    public class Collectionlist
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "a";
            yield return "r";
            yield return "f";
        }
    } 
    #endregion

    #region yield1
    //public class HelloCollection
    //{
    //    public IEnumerator GetEnumerator()
    //    {
    //        yield return "Hello";
    //        yield return "World";
    //    }
    //}
    /// <summary>
    /// 具体的聚合类
    /// </summary>
    //public class HelloCollection
    //{
    //    public IEnumerator GetEnumerator()
    //    {
    //        Enumerator enumerator = new Enumerator(0);
    //        return enumerator;
    //    }
    //}
    //public class Enumerator : IEnumerator
    //{
    //    /// <summary>
    //    /// 状态机
    //    /// </summary>
    //    private int state;

    //    private object current;

    //    public Enumerator(int state)
    //    {
    //        this.state = state;
    //    }
    //    public bool MoveNext()
    //    {
    //        switch (state)
    //        {
    //            case 0:
    //                current = "Hello";
    //                state = 1;
    //                return true;
    //            case 1:
    //                current = "World";
    //                state = 2;
    //                return true;
    //            case 2:
    //                break;
    //        }
    //        return false;
    //    }
    //    public object Current
    //    {
    //        get { return current; }
    //    }
    //    public void Reset()
    //    {
    //        throw new NotImplementedException();
    //    }
    //} 
    #endregion


    ///yield的类型编译器会生成枚举器，这些值是靠里面的状态机来维护的
}
