//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chingy_SYS.DAL.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dictionary_Table
    {
        public Dictionary_Table()
        {
            this.Dictionary_Column = new HashSet<Dictionary_Column>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Flag { get; set; }
        public Nullable<System.DateTime> InsertTime { get; set; }
        public Nullable<int> InsertUser { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<int> UpdateUser { get; set; }
        public string ExtPropertys { get; set; }
    
        public virtual ICollection<Dictionary_Column> Dictionary_Column { get; set; }
    }
}