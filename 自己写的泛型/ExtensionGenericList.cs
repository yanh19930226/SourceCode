using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自己写的泛型
{
    public static class ExtensionGenericList
    {
        #region 将一个集合转化为目标集合+MyCast<Tsource, Tout>()
        /// <summary>
        /// 扩展方法----将一个集合转化为目标集合
        /// </summary>
        /// <typeparam name="Tsource">源集合</typeparam>
        /// <typeparam name="Tout">目标集合</typeparam>
        /// <returns></returns>
        /// 方法约束：目标集合的类型必须是源集合类型的子类
        public static GenericList<Tout> MyCast<Tsource,Tout>(this GenericList<Tsource> sourceList) where Tout:Tsource
        {
            GenericList<Tout> resultlist = new GenericList<Tout>();
            foreach (Tsource item in sourceList)
            {
                Tout temp = (Tout)item;
                resultlist.Add(temp);
            }
            return resultlist;
        } 
        #endregion

        public static GenericList<T> Where<T>()
        {
            return null;
        }
    }
}
