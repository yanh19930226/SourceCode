using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 数据结构非泛型;

namespace 数据结构
{
    public class MyArray<T> : IEnumerable<T>
    {
        private int length;

        public int Length
        {
            get
            {
                return length;
            }
        }

        private T[] _array;

        public int Sort()
        {
            return 1;
        }


        #region 实现枚举器
        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
