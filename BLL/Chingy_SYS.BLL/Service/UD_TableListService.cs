using Chingy_SYS.BLL.Infrastructure;
using Chingy_SYS.DAL.DB;
using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.BLL.Service
{
    public class UD_TableListService : IUD_TableService
    {
        Chingy_SYS.DAL.DAO.UD_TableDAO TableDAO = new DAL.DAO.UD_TableDAO();

        public Result<IDictionary<string, int>, IList<UD_TableList>> GetTableList(Guid? id, int? rows, int? page)
        {
            return TableDAO.GetTableList(id, rows, page);
        }


        public Result<bool, string> AddTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableModel)
        {
            return TableDAO.AddTable(UD_TableModel);
        }

        public Result<bool, string> DestroyTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableList)
        {
            return TableDAO.DestroyTable(UD_TableList);
        }


        public Result<bool, string> DestroyTable(Guid Guid)
        {
            return TableDAO.DestroyTable(Guid);
        }

        public Result<bool, string> ModifyTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableList)
        {
            return TableDAO.ModifyTable(UD_TableList);
        }


        public Result<bool, string> RemoveField(Guid Guid)
        {
            return TableDAO.RemoveField(Guid);
        }

        public Result<bool, string> EditField(UD_ModelFields UD_ModelFields)
        {
            return TableDAO.EditField(UD_ModelFields);
        }

        public Result<Guid, string> CreateField(UD_ModelFields UD_ModelFields)
        {
            return TableDAO.CreateField(UD_ModelFields);
        }
    }
}
