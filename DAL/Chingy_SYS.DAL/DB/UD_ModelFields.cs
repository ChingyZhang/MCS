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
    
    public partial class UD_ModelFields
    {
        public UD_ModelFields()
        {
            this.UD_Panel_ModelFields = new HashSet<UD_Panel_ModelFields>();
            this.UD_Panel_TableRelation = new HashSet<UD_Panel_TableRelation>();
            this.UD_Panel_TableRelation1 = new HashSet<UD_Panel_TableRelation>();
        }
    
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> TableID { get; set; }
        public string FieldName { get; set; }
        public string FieldDisplayName { get; set; }
        public Nullable<int> ColumnSortID { get; set; }
        public string FlagEntity { get; set; }
        public Nullable<int> DataType { get; set; }
        public Nullable<int> DataLength { get; set; }
        public Nullable<int> Precision { get; set; }
        public string DefaultValue { get; set; }
        public string Description { get; set; }
        public Nullable<int> RelationType { get; set; }
        public string RelationTableName { get; set; }
        public string RelationFieldValue { get; set; }
        public string RelationFieldText { get; set; }
        public Nullable<int> Position { get; set; }
        public Nullable<System.DateTime> InsertTime { get; set; }
        public Nullable<int> InsertUser { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<int> UpdateUser { get; set; }
        public string ExtPropertys { get; set; }
    
        public virtual UD_TableList UD_TableList { get; set; }
        public virtual ICollection<UD_Panel_ModelFields> UD_Panel_ModelFields { get; set; }
        public virtual ICollection<UD_Panel_TableRelation> UD_Panel_TableRelation { get; set; }
        public virtual ICollection<UD_Panel_TableRelation> UD_Panel_TableRelation1 { get; set; }
    }
}
