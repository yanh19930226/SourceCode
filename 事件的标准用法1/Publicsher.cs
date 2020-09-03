using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件的标准用法1
{
    public class Publicsher
    {

        public event EventHandler<MyEventArgs> myEvent;

        private decimal price;

        public decimal Preice
        {
            get
            {
                return price;
            }
            set
            {
                //如果价格变了，触发事件通知用户价格变了
                if (price == value)
                {
                    return;
                }


                decimal oldPrice = price;
                price = value;

                //激发事件
                OnRaiseEvet(new MyEventArgs(price, oldPrice));
            }
        }


        public virtual void OnRaiseEvet(MyEventArgs e)
        {

            //如果调用列表不为空，则触发
            if (myEvent != null)
            {
                myEvent(this, e);

                //event关键字定义的事件只能由事件源对象自己激发，外界无法通过访问委托变量直接激发事件。下面的代码无法编译通过：Publisher p = new Publisher(); p.MyEvent(10);
            }
        }
    }
}
