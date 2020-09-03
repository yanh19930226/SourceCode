using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    class Cat
    {
        public void Miao()
        {
            Console.WriteLine("猫叫了一声");
            OnExcute();
        }
        private List<Iobserver> list = new List<Iobserver>();
        /// <summary>
        /// 发布者提供给订阅者订阅改主题的方法
        /// </summary>
        /// <param name="observer"></param>
        public void Add(Iobserver observer)
        {
            list.Add(observer);
        }
        /// <summary>
        /// 触发事件的代码
        /// </summary>
        public void OnExcute()
        {
            if (list!=null)
            {
                foreach (var item in list)
                {
                    item.Action();
                }
            }
        }
    }
}
