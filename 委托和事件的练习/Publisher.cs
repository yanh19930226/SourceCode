using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托和事件的练习
{
    /// <summary>
    /// 发布者
    /// </summary>
    public class Publisher
    {
        //定义一个事件
        public event MyEventHandler myEnvent;
        //触发事件的方法
        public void OnExcute()
        {
            if (myEnvent!=null)
            {
                //调用委托变量执行
                myEnvent.Invoke();
            }
        }
        public event ReturnEvenHandler returnEvent;

        public List<string> OnExcute1()
        {
            List<string> list = new List<string>();
            if (returnEvent!=null)
            {
                Delegate[] del = returnEvent.GetInvocationList();
                for (int i = 0; i < del.Length; i++)
                {
                    ReturnEvenHandler d = (ReturnEvenHandler)del[i];
                    list.Add(d.Invoke());
                }
            }
            return list;
        }
    }
}
