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
    
    public partial class DB_RunLog
    {
        public int ID { get; set; }
        public int RunType { get; set; }
        public string RunContent { get; set; }
        public byte[] RunResult { get; set; }
        public Nullable<System.DateTime> InsertTime { get; set; }
        public Nullable<int> InsertUser { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<int> UpdateUser { get; set; }
        public string ExtPropertys { get; set; }
    }
}
