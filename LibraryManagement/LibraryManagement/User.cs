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
    
    public partial class User
    {
        public User()
        {
            this.Records = new HashSet<Record>();
        }
    
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPWD { get; set; }
        public int UserGroupID { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    
        public virtual ICollection<Record> Records { get; set; }
        public virtual UserGroupInfo UserGroupInfo { get; set; }
    }
}
