using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自己写的泛型
{
    public class MyGenericEnumerator<T>:IEnumerator
    {
        private T[] temp;
        private int count;
        private int index = -1;

        #region 构造函数初始化+MyGenericEnumerator(T[] array, int count)
        public MyGenericEnumerator(T[] array, int count)
        {
            this.temp = array;
            this.count = count;
        } 
        #endregion

        #region 获取当前的值+Current
        /// <summary>
        /// 获取当前的值
        /// </summary>
        public object Current
        {
            get { return this.temp[index]; }
        }
        #endregion

        #region 游标判断是否有下一个值+MoveNext()
        /// <summary>
        /// 游标判断是否有下一个值
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            index++;
            if (index < count)
                return true;
            else
                return false;
            
        } 
        #endregion

        #region 重置当前的下标值+Reset()
        /// <summary>
        /// 重置当前的下标值
        /// </summary>
        public void Reset()
        {
            this.index = -1;
        } 
        #endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
