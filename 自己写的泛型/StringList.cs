using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自己写的泛型
{
    public class StringList : MyIEnumrable
    {
        /// <summary>
        /// 私有字符串数组
        /// </summary>
        private string[] _str=new string[4];

        #region 数组中实际存储的个数+count
        int count=0;
        /// <summary>
        /// 数组中实际存储的个数
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        } 
        #endregion

        #region 新增+Add(string str)
        /// <summary>
        /// 新增
        /// </summary>
        public void Add(string str)
        {
            //如果当前的数组存储的个数等于数组的长度那么数组就扩容
            if (count == _str.Length)
            {
                //新建一个数组
                string[] _newStr = new string[_str.Length * 2];
                //把旧数组中的所有的数据复制到新的数组中
                _str.CopyTo(_newStr, 0);
                //重新指定数组的引用
                _str = _newStr;
            }
            _str[count] = str;
            count++;
        }
        //public void add(string str)
        //{
        //    //往数组中添加元素，判断是否为空，为空就放入这个位置，跳出循环
        //    //for (int i = 0; i < _str.Length; i++)
        //    //{
        //    //    if (_str[i]!=null)
        //    //    {
        //    //        _str[i] = str;
        //    //        break;
        //    //    }
        //    //}
        //    if (count==_str.Length)
        //    {
        //        string[] temp=new string[_str.Length*2];
        //        _str.CopyTo(temp, 0);
        //        _str = temp;
        //    }
        //    _str[count]=str;
        //    count++;

        //}
        #endregion

        #region 根据指定的下标删除数组中的数据+RemoveAt(int index)
        /// <summary>
        /// 根据索引删除数组中的元素
        /// </summary>
        /// <param name="index">数组索引</param>
        public void RemoveAt(int index)
        {
            if (index<0||index>_str.Length)
            {
                throw new Exception("数组越界了"); 
            }
            Array.Copy(_str, index + 1, _str, index, _str.Length - index - 1);

        } 
        #endregion

        #region 索引器，编辑获取指定下标数据+string this[int index]
        /// <summary>
        /// 通过索引器来获取数组中的值和修改数组中的值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string this[int index]
        {
            get
            {
                if (index < 0 || index > _str.Length)
                {
                    throw new Exception("数组越界了");
                }
                return _str[index];
            }
            set
            {
                if (index < 0 || index > _str.Length)
                {
                    throw new Exception("数组越界了");
                }
                else
                {
                    _str[index] = value;
                }
            }
        } 
        #endregion\

        #region 枚举器实现foreach+GetIEnumrator()
        /// <summary>
        /// 枚举器
        /// </summary>
        /// <returns></returns>
        public MyIEnumrator GetIEnumrator()
        {
            return new MyEnumrator(this._str,this.count);
        } 
        #endregion
    }
}
