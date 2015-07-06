using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.BLL.Infrastructure
{
    public interface IUD_TableService
    {
        IQueryable GetTableList(Guid? id);
        Result<bool, string> AddTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableModel);

        Result<bool, string> DestroyTable(Guid Guid);
        Result<bool, string> DestroyTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableList);

        Result<bool, string> ModifyTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableList);
    }
}
