using Chingy_SYS.BLL.Infrastructure;
using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.BLL.Service
{
    public class UD_TableListService : IUD_Table
    {
        Chingy_SYS.DAL.DAO.TableDAO TableDAO = new DAL.DAO.TableDAO();

        public IList<Chingy_SYS.DAL.DB.UD_TableList> GetTableList()
        {
            return TableDAO.GetTableList();
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
