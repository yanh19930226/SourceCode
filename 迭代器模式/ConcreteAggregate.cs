using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器模式
{
    ///可以通过索引器来存取数据或者通过定义一个方法来存取数据
    /// <summary>
    /// 具体的聚合实现迭代器
    /// </summary>
    //public class ConcreteAggregate : Aggregate
    //{
    //不实现接口直接把迭代的方法写在具体聚合的内部
    public class ConcreteAggregate 
    {
        private ArrayList list=new ArrayList();
        /// <summary>
        /// 索引位置
        /// </summary>
        private int _index = 0;

        public int Count
        {
            get { return list.Count; }
        }
        public ConcreteAggregate()
        {
            list.Add("sdfdsf");
            list.Add("sdfsdfsdsf");
            list.Add("sdfddsfsf");
        }


        //public override ConcreteIterator GetIterator()
        //{
        //    return new ConcreteIterator(list);
        //}
        /// <summary>
        /// 索引器用来存取数据
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object this[int index]
        {
            get { return list[index]; }
            set { list[index]=value; }
        }
        /// <summary>
        /// 判断是否有下一个元素
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (this.list.Count - 1 > _index)
            {
                _index++;
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 获取当前元素
        /// </summary>
        public object Current
        {
            get { return list[_index]; }
        }


    }
}
