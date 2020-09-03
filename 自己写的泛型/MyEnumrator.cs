using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自己写的泛型
{
    public class MyEnumrator:MyIEnumrator
    {
        private string[] _str;
        int index=-1;
        int count;
        public MyEnumrator(string[] _str,int count){
            this._str=_str;
            this.count = count;
        }
        public bool MoveNext()
        {
            index++;
            if (index < count)
                return true;
            else
                return false;
        }

        public string Current
        {
            get{
                return this._str[index];
            }
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
