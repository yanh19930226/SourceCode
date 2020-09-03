using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 数据结构非泛型;

namespace 数据结构
{
    public interface IEnumerator<out T>:IEnumerator
    {
        T Current { get; }
        int index { get; }
    }
}
