using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.BLL.Infrastructure
{
    public interface ITableService
    {
        IList<Chingy_SYS.DAL.DB.UD_TableList> GetTableList();
        bool AddTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableModel);

        bool DestroyTable(Guid Guid);
        bool DestroyTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableList);

        bool ModifyTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableList);
    }
}
