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
    
    public partial class UD_Panel_ModelFields
    {
        public System.Guid ID { get; set; }
        public System.Guid PanelID { get; set; }
        public System.Guid FieldID { get; set; }
        public string LabelText { get; set; }
        public string ReadOnly { get; set; }
        public Nullable<int> ControlTupe { get; set; }
        public Nullable<int> ControlHeight { get; set; }
        public Nullable<int> ControlWidth { get; set; }
        public string ControlStyle { get; set; }
        public Nullable<int> ColSpan { get; set; }
        public string Description { get; set; }
        public string Enable { get; set; }
        public string Visible { get; set; }
        public string IsRequiredFidle { get; set; }
        public Nullable<int> SortID { get; set; }
        public Nullable<int> DisplayMode { get; set; }
        public string RegularExpression { get; set; }
        public string FormatString { get; set; }
        public Nullable<int> TreeLevel { get; set; }
        public Nullable<System.DateTime> InsertTime { get; set; }
        public Nullable<int> InsertUser { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<int> UpdateUser { get; set; }
    
        public virtual UD_ModelFields UD_ModelFields { get; set; }
        public virtual UD_Panel UD_Panel { get; set; }
    }
}
