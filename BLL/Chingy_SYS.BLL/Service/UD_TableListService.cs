using Chingy_SYS.BLL.Infrastructure;
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

        public IQueryable GetTableList(Guid? id)
        {
            return TableDAO.GetTableList(id);
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
    }
}
