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
    
    public partial class UserGroupInfo
    {
        public UserGroupInfo()
        {
            this.Users = new HashSet<User>();
        }
    
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public bool IsAdmin { get; set; }
        public int Max { get; set; }
    
        public virtual ICollection<User> Users { get; set; }
    }
}
