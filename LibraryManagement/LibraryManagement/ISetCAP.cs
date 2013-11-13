using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManagement
{
    /// <summary>
    /// 窗体用于设置类别、作者和出版社的接口
    /// </summary>
    internal interface ISetCAP
    {
        ////<summary>
        ////设置类别
        ////</summary>
        ////<param name="c">类别对象</param>
        void SetCategory(Category c);

        /// <summary>
        /// 设置作者
        /// </summary>
        /// <param name="a">作者对象</param>
        void SetAuthor(Author a);

        /// <summary>
        /// 设置出版社
        /// </summary>
        /// <param name="p">出版社对象</param>
        void SetPress(Press p);
    }
}
