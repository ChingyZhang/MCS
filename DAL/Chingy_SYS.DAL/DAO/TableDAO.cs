using Chingy_SYS.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.DAL.DAO
{
    public class TableDAO
    {
        public IList<UD_TableList> GetTableList()
        {
            return new Chingy_SYSEntities().UD_TableList.ToList();
        }
    }
}
