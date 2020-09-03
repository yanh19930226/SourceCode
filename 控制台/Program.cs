using System;
using 数据结构;
using 数据结构.系统内置接口;

namespace 控制台
{
    class Program
    {
        static void Main(string[] args)
        {




            #region GroupBy测试
            //hashcode相同的字符串
            //Console.WriteLine("0.89265452879139".GetHashCode());
            //Console.WriteLine("0.280527401380486".GetHashCode());

            //Console.WriteLine("第三组".GetHashCode());
            //Console.WriteLine("第一组".GetHashCode());
            //Console.ReadKey();

            //MyList<Student> list = new MyList<Student>();
            //list.Add(new Student { GroupName = "第二组", Name = "小林", Age = 65, Gender = "女" });
            //list.Add(new Student { GroupName = "第二组", Name = "小严", Age = 36, Gender = "男" });
            //list.Add(new Student { GroupName = "第二组", Name = "小周", Age = 77, Gender = "女" });
            //list.Add(new Student { GroupName = "第一组",Name="小明", Age = 88, Gender = "男" });
            //list.Add(new Student { GroupName = "第一组",Name="小王", Age = 89, Gender = "男" });
            //list.Add(new Student { GroupName = "第一组",Name="小张", Age = 89, Gender = "女" });
            //list.Add(new Student { GroupName = "第三组",Name="小赵", Age = 52, Gender = "男" });
            //list.Add(new Student { GroupName = "第三组",Name="小刘", Age = 152,Gender = "女" });
            //list.Add(new Student { GroupName = "第三组",Name = "小黄", Age = 12, Gender = "男" });

            //list.Add(new Student { GroupName = "0.89265452879139",Name="小白", Age = 72, Gender = "男" });
            //list.Add(new Student { GroupName = "0.89265452879139",Name="小黑", Age = 72, Gender = "女" });
            //list.Add(new Student { GroupName = "0.89265452879139", Name = "小肖", Age = 82, Gender = "男" });

            //list.Add(new Student { GroupName = "0.280527401380486",Name="小李", Age = 52, Gender = "男" });
            //list.Add(new Student { GroupName = "0.280527401380486",Name="小华", Age = 92, Gender = "女" });
            //list.Add(new Student { GroupName = "0.280527401380486", Name = "小吴", Age = 32, Gender = "男" });

            //var group = list.GroupBy(q => q.Gender);

            //var tor = group.GetEnumerator();
            //while (tor.MoveNext())
            //{
            //    Console.WriteLine("分组功能(根据组名分组)");
            //    数据结构.IEnumerator<Student> ttor = tor.Current.GetEnumerator();

            //    while (ttor.MoveNext())
            //    {
            //        Console.WriteLine("所在的组为:" + ttor.Current.GroupName + ";  " + "姓名:" + ttor.Current.Name + ";  年龄:" + ttor.Current.Age.ToString() + ";  性别:" + ttor.Current.Gender);
            //    }
            //    Console.WriteLine("-----------------华丽的分割线-----------------");
            //} 
            #endregion

            #region Lookup测试
            //MyLookup<string, Student> lookup = (MyLookup<string, Student>)list.ToLookup(q => q.GroupName);
            //数据结构.IEnumerable<IGrouping<string, Student>> grouplist = lookup.GetPerGroup();
            //数据结构.IEnumerator<IGrouping<string, Student>> tor = grouplist.GetEnumerator();

            //MyLookup<string, Student> lookup1 = (MyLookup<string, Student>)list.ToLookup(q => q.Gender);
            //数据结构.IEnumerable<IGrouping<string, Student>> grouplist1 = lookup1.GetPerGroup();
            //数据结构.IEnumerator<IGrouping<string, Student>> tor1 = grouplist1.GetEnumerator();

            //while (tor.MoveNext())
            //{
            //    Console.WriteLine("分组功能(根据组名分组)");
            //        数据结构.IEnumerator<Student> ttor = tor.Current.GetEnumerator();

            //        while (ttor.MoveNext())
            //        {
            //            Console.WriteLine("所在的组为:" + ttor.Current.GroupName + ";  " + "姓名:" + ttor.Current.Name + ";  年龄:" + ttor.Current.Age.ToString() + ";  性别:" + ttor.Current.Gender);
            //        }
            //    Console.WriteLine("-----------------华丽的分割线-----------------");
            //}
            //Console.WriteLine("-----------------华丽的分割线-----------------");
            //while (tor1.MoveNext())
            //{
            //    Console.WriteLine("分组功能(根据性别分组)");
            //        数据结构.IEnumerator<Student> ttor = tor1.Current.GetEnumerator();

            //        while (ttor.MoveNext())
            //        {
            //            Console.WriteLine("所在的组为:" + ttor.Current.Gender + ";  " + "姓名:" + ttor.Current.Name + ";  年龄:" + ttor.Current.Age.ToString() + ";  性别:" + ttor.Current.Gender);
            //        }
            //    Console.WriteLine("-----------------华丽的分割线-----------------");
            //} 
            #endregion

            Console.ReadKey();

            #region 测试1
            //List<int> list = new List<int>();
            //list.Add(5);
            //list.Add(3);
            //list.Add(4);
            //list.Add(9);
            //list.Add(6);
            //foreach (var item in list)
            //{
            //    Console.WriteLine("姓名：" + item.Name + "======年龄:" + item.Age.ToString());
            //}
            //Console.ReadKey();
            //list.Sort();
            //foreach (var item in list)
            //{
            //    Console.WriteLine("姓名：" + item.Name + "======年龄:" + item.Age.ToString());
            //}
            //Console.ReadKey(); 
            #endregion

            #region 自定义集合排序
            //MyList<int> list = new MyList<int>();
            //list.Add(2);
            //list.Add(1);
            //list.Add(3);
            //list.Add(5);
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //Console.ReadKey();
            //list.Sort();
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //Console.ReadKey(); 
            #endregion

            #region 自定义泛型类排序
            //MyList<Student> list = new MyList<Student>();
            //list.Add(new Student { Name = "ccc", Age = 4 });
            //list.Add(new Student { Name = "eeeeeee", Age = 7 });
            //list.Add(new Student { Name = "bb", Age = 6 });
            //list.Add(new Student { Name = "a", Age = 7 });
            ////list.Add(new Student { Name = "ddddd", Age = 4 });
            //Console.WriteLine("排序前：");
            //foreach (var item in list)
            //{
            //    Console.WriteLine("姓名：" + item.Name + "======年龄:" + item.Age.ToString());
            //}
            //Console.ReadKey();
            //Console.WriteLine("==================华丽的分割线====================");
            //Console.WriteLine("使用默认比较器进行比较排序：");
            //list.Sort();
            //foreach (var item in list)
            //{
            //    Console.WriteLine("姓名：" + item.Name + "======年龄:" + item.Age.ToString());
            //}
            //Console.ReadKey();
            //Console.WriteLine("==================华丽的分割线====================");
            //Console.WriteLine("使用IComparable接口进行排序");
            //list.Sort();
            //foreach (var item in list)
            //{
            //    Console.WriteLine("姓名：" + item.Name + "======年龄:" + item.Age.ToString());
            //}
            //Console.ReadKey();
            //Console.WriteLine("==================华丽的分割线====================");
            //list.Sort(new StudentComparer());
            //Console.WriteLine("根据名字长度排序：");
            //foreach (var item in list)
            //{
            //    Console.WriteLine("姓名：" + item.Name + "======年龄:" + item.Age.ToString());
            //}
            //Console.ReadKey();
            //Console.WriteLine("==================华丽的分割线====================");
            //Console.WriteLine("根据年龄大小排序：");
            //list.Sort(new StudentComparer2());
            //foreach (var item in list)
            //{
            //    Console.WriteLine("姓名：" + item.Name + "======年龄:" + item.Age.ToString());
            //}
            //Console.ReadKey();
            #endregion

            #region 快排测试类
            //int[] _temp = new []{ 8,1,0,3,7,9,4,6,2};
            //QuickSort(_temp, 0, _temp.Length-1);
            //foreach (var item in _temp)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //Console.ReadKey(); 
            #endregion
        }
        public static void QuickSort(int[] _array, int start, int last)
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
        public static int Devide(int[] _array, int start, int last)
        {
            int left = start + 1;//左边计数
            int right = last;//右边计数
            int standard = _array[start];//排序标准值，已数组的第一个元素作为标准值
            int _temp;
            while (left < right)
            {
                //从右侧往左走，找到比基准元素小的位置
                while (left < right && _array[right] > standard)
                {
                    right--;
                }
                //从左侧往右走，找到比基准元素大的位置
                while (left < right && _array[left] <= standard)
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
            if (_temp > _array[left])
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

    }
    public class Student
    {
        public string GroupName { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public int CompareTo(Student other)
        {
            if (this.Name.Length > other.Name.Length)
            {
                return 1;
            }
            else if (this.Name.Length < other.Name.Length)
            {
                return 0;
            }
            else
                return -1;
        }
    }
    public class StudentComparer : 数据结构.系统内置接口.IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x.Name.Length > y.Name.Length)
                return 1;
            else if (x.Name.Length == y.Name.Length)
                return 0;
            else
                return -1;
        }
    }
    public class StudentComparer2 : 数据结构.系统内置接口.IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x.Age > y.Age)
                return 1;
            else if (x.Age == y.Age)
                return 0;
            else
                return -1;
        }
    }
}
