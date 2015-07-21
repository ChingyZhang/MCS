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
        Result<IDictionary<string, int>, IList<Chingy_SYS.DAL.DB.UD_TableList>> GetTableList(Guid? id, int? rows, int? page);
        Result<bool, string> AddTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableModel);

        Result<bool, string> DestroyTable(Guid Guid);
        Result<bool, string> DestroyTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableList);

        Result<bool, string> ModifyTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableList);

        Result<bool, string> RemoveField(Guid Guid);
        Result<bool, string> EditField(Chingy_SYS.DAL.DB.UD_ModelFields UD_ModelFields);
        Result<Guid, string> CreateField(Chingy_SYS.DAL.DB.UD_ModelFields UD_ModelFields);
    }
}
