using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chingy_SYS.Model
{
    public class UD_TableModel
    {
        /// <summary>
        /// 表ID
        /// </summary>
        public int ID { get; set; }
        
        /// <summary>
        /// 表明，英文，含全称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 表用于展示的中文名
        /// </summary>
        public string DisplayName { get; set; }
        
        /// <summary>
        /// 是否有扩展字段
        /// </summary>
        public char ExtFlag { get; set; }

        /// <summary>
        /// 表实体名
        /// </summary>
        public string ModelName { get; set; }
        
        /// <summary>
        /// 是否为树形菜单
        /// </summary>
        public string TreeFlag { get; set; }
        
        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime InsertTime { get; set; }

        /// <summary>
        /// 新增人
        /// </summary>
        public int InsertUser { get; set; }
        
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 更信任
        /// </summary>
        public int UpdateUser { get; set; }
        
        /// <summary>
        /// 扩展字段
        /// </summary>
        public string ExtPropertys { get; set; }
    }
}