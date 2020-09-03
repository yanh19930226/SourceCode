using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自己写的泛型
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 字符串集合实现foreach
            //StringList list = new StringList();
            //list.Add("a");
            //list.Add("b");
            //list.Add("c");
            //list.Add("d");
            //list.Add("e");

            //MyIEnumrator tor = list.GetIEnumrator();
            //while (tor.MoveNext())
            //{
            //    Console.WriteLine(tor.Current);
            //}
            //Console.ReadKey(); 
            #endregion

            Console.WriteLine("================华丽的分割线===============");

            #region 泛型集合实现foreach+GenericList<T>
            //GenericList<string> _myList = new GenericList<string>();
            //_myList.Add("a");
            //_myList.Add("b");
            //_myList.Add("c");
            //_myList.Add("d");
            //_myList.Add("e");
            //GenericList<string> myList = new GenericList<string>();
            #warning 无法将系统的泛型集合转为自己写的泛型集合
            //myList = _myList.FindAll(a => a.Contains("a"));
            //IEnumerator tor = _myList.GetEnumerator();
            //while (tor.MoveNext())
            //{
            //    Console.WriteLine(tor.Current);
            //}
            //GenericList<int> _myList = new GenericList<int>();
            //_myList.Add(1);
            //_myList.Add(2);
            //_myList.Add(3);
            //_myList.Add(4);
            //_myList.Add(5);
            //foreach (var item in _myList)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            List<string> list = new List<string>();
            list.Add("aa");
            list.Add("as");
            list.Add("bb");
            foreach (var item in list.FindAll(q=>q.Contains("a")))
            {
                Console.WriteLine(item);
            }
            #endregion

            Console.WriteLine("================华丽的分割线===============");

            #region 扩展方法MyCast的测试
            //GenericList<Dog> doglist = new GenericList<Dog>();
            //doglist.Add(new ChildDog() { Age = 1, Name = "aa" });
            //doglist.Add(new ChildDog() { Age = 1, Name = "bb" });
            //doglist.Add(new ChildDog() { Age = 1, Name = "cc" });
            //GenericList<ChildDog> childList = doglist.MyCast<Dog, ChildDog>();
            //IEnumerator tor = childList.GetEnumerator();
            //while (tor.MoveNext())
            //{
            //    Console.WriteLine(((ChildDog)(tor.Current)).Name); 
            //} 
            #endregion

            Array aa = Array.CreateInstance(typeof(int), 4);
            aa.SetValue(4, 0);
            aa.SetValue(4, 1);
            aa.SetValue(4, 2);
            aa.SetValue(4, 3);
            aa.SetValue(4, 4);

            Console.ReadKey();
        }
    }
    class Dog
    {
        public int Age { get; set; }
    }
    class ChildDog:Dog
    {
        public string Name { get; set; }
    }
}
