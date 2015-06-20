using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.Model
{
    public class Dictionary_Column
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Flag { get; set; }
        public DateTime InsertTime { get; set; }
        public int InsertUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public int UpdateUser { get; set; }
        public string ExtPropertys { get; set; }
    }
}
