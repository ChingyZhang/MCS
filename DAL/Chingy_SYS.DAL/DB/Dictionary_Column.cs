//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chingy_SYS.DAL.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dictionary_Column
    {
        public int ID { get; set; }
        public Nullable<int> Table { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Flag { get; set; }
        public Nullable<System.DateTime> InsertTime { get; set; }
        public Nullable<int> InsertUser { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<int> UpdateUser { get; set; }
        public string ExtPropertys { get; set; }
    
        public virtual Dictionary_Table Dictionary_Table { get; set; }
    }
}
