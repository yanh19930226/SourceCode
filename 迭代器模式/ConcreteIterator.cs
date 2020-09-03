using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器模式
{
    /// <summary>
    /// 假设现在是对ArrayList这个聚合写一个迭代器
    /// 所以返回的对象是object
    /// </summary>
    public class ConcreteIterator:Iterator
    {
        private ArrayList _list;
        private int _current = 0;

        public ConcreteIterator(ArrayList temp)
        {
            this._list = temp;
        }

        public override object First()
        {
            return this._list[0];
        }

        public override object Current()
        {
            return _list[_current];
        }

        public override bool IsDone()
        {
            return this._list.Count - 1 >= _current;
        }

        public override object Next()
        {
            object res = null;
            if (this._list.Count-1>_current)
            {
                res = _list[_current];
                _current++;
            }
            return res;
        }
    }
}
