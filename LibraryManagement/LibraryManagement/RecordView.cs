//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class RecordView
    {
        public int 订单编号 { get; set; }
        public int 藏书号 { get; set; }
        public string 账户 { get; set; }
        public string 标题 { get; set; }
        public string 作者 { get; set; }
        public string 用户姓名 { get; set; }
        public System.DateTime 借出日期 { get; set; }
        public Nullable<System.DateTime> 归还日期 { get; set; }
        public string 类别 { get; set; }
        public int 最大天数 { get; set; }
        public Nullable<int> 借阅天数 { get; set; }
    }
}