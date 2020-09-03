using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构.系统内置接口
{
    /*
     * 分组接口定义：
     * 1.接收组内元素的泛型数组：TElement []
     * 2.泛型数组的元素的个数 count
     * 3.表示每一个组的键的标识：Key
     * 4.键Key所对应的hashcode
     * 5.具有相同的hashcode的不同的键Key的引用hashNext
     * 6.用来保存不同的组的引用next
     * 7.每一组要对所有的元素进行遍历所以要实现接口：自己实现的枚举的接口IEnumerable
     */
    public interface IGrouping<TKey, TElement>:IEnumerable<TElement>
    {
    }
}
