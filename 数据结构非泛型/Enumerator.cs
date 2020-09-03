using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构非泛型
{
    public class Enumerator:IEnumerator
    {
        /// <summary>
        /// 需要遍历的数组
        /// </summary>
        private object[] _temp;
        /// <summary>
        /// 游标的索引
        /// </summary>
        private int _index=-1;
        /// <summary>
        /// 这个数组中的实际的数据的个数
        /// </summary>
        //private int count;
        public Enumerator(object[] _temp)
        {
            this._temp = _temp;
        }
        public object Current
        {
            get { return _temp[_index]; }
        }

        public bool MoveNext()
        {
            _index++;
            if (_index <_temp.Count())
                return true;
            else
                return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
