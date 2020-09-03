using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //IEnumerable<int> li= list.Where(q => q > 3);
            IEnumerable<int> li = list.Skip(2);
            IEnumerator<int> tor = li.GetEnumerator();
            while (tor.MoveNext())
            {
                Console.WriteLine(tor.Current.ToString());
            }
            Console.ReadKey();
            //List<string> list = new List<string>();
            ////List<int> i = new List<int>();
            //var all = new List<string>();
            //for (long i = 0; i < 9999999999; i++)
            //{
            //    var b = new List<string>();
            //    for (var j = 0; j < 1000; j++)
            //    {
            //        b.Add(new Guid().ToString());
            //        try
            //        {
            //            all.AddRange(b);
            //        }
            //        catch (Exception)
            //        {
            //            Console.WriteLine(all.Count);
            //        }
            //    }
            //}
            //Console.WriteLine(all.Count);
            //List<string> s = new List<string>();
            //Console.WriteLine(s.Capacity.ToString());
            //Console.ReadKey();
            //Stack<string> numbers = new Stack<string>();
            //numbers.Push("one");
            //numbers.Push("two");
            //numbers.Push("three");
            //numbers.Push("four");
            //numbers.Push("five");

            //Console.WriteLine(numbers.Peek());

            //// A stack can be enumerated without disturbing its contents.
            //foreach (string number in numbers)
            //{
            //    Console.WriteLine(number);
            //}

            //Console.WriteLine("\nPopping '{0}'", numbers.Pop());
            //Console.WriteLine("Peek at next item to destack: {0}",
            //    numbers.Peek());
            //Console.WriteLine("Popping '{0}'", numbers.Pop());

            //// Create a copy of the stack, using the ToArray method and the
            //// constructor that accepts an IEnumerable<T>.
            //Stack<string> stack2 = new Stack<string>(numbers.ToArray());

            //Console.WriteLine("\nContents of the first copy:");
            //foreach (string number in stack2)
            //{
            //    Console.WriteLine(number);
            //}

            //// Create an array twice the size of the stack and copy the
            //// elements of the stack, starting at the middle of the 
            //// array. 
            //string[] array2 = new string[numbers.Count * 2];
            //numbers.CopyTo(array2, numbers.Count);

            //// Create a second stack, using the constructor that accepts an
            //// IEnumerable(Of T).
            //Stack<string> stack3 = new Stack<string>(array2);

            //Console.WriteLine("\nContents of the second copy, with duplicates and nulls:");
            //foreach (string number in stack3)
            //{
            //    Console.WriteLine(number);
            //}

            //Console.WriteLine("\nstack2.Contains(\"four\") = {0}",
            //    stack2.Contains("four"));

            //Console.WriteLine("\nstack2.Clear()");
            //stack2.Clear();
            //Console.WriteLine("\nstack2.Count = {0}", stack2.Count);
        }
    }


    //public class Person
    //{
    //    public virtual void Get()
    //    {
    //        Console.WriteLine("我是父类的方法");
    //    }
    //}
    //public class Student : Person
    //{
    //    public void Get(int str)
    //    {
    //        Console.WriteLine("我是子类的方法");
    //    }
    //    public override void Get()
    //    {
    //        Console.WriteLine("我是父类的重写方法");
    //    }
    //}
}
