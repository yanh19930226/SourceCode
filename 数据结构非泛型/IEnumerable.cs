using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构非泛型
{
    public interface IEnumerable
    {
        IEnumerator GetEnumerator();
    }
}
