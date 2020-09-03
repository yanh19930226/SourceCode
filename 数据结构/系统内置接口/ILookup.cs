using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构.系统内置接口
{
    /*
     * ILookup接口的作用
     * 1.实现对IGrouping(Lookup类中所有的组)的枚举所以要实现继承IEnumerable这个接口
     * 2.好像暂时就没有其他的作用了
     */
    public interface ILookup<TKey,TElement>:IEnumerable<IGrouping<TKey, TElement>>
    {

    }
}
