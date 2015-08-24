using Chingy_SYS.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.BLL.Service
{
    public class Dictionary_TableService : IDictionary_Table
    {
        Chingy_SYS.DAL.DAO.Dictionary_TableDAO Dictionary_TableDAO = new DAL.DAO.Dictionary_TableDAO();

        public IQueryable<DAL.DB.Dictionary_Table> GetDicList()
        {
            return Dictionary_TableDAO.GetDicList();
        }

        public Core.Result.Result<bool, string> AddDictionary_Table(DAL.DB.Dictionary_Table Dictionary_Table)
        {
            return Dictionary_TableDAO.AddDictionary_Table(Dictionary_Table);
        }

        public Core.Result.Result<bool, string> DestroyDictionary_Table(int ID)
        {
            return Dictionary_TableDAO.DestroyDictionary_Table(ID);
        }

        public Core.Result.Result<bool, string> ModifyDictionary_Table(DAL.DB.Dictionary_Table Dictionary_Table)
        {
            return Dictionary_TableDAO.ModifyDictionary_Table(Dictionary_Table);
        }
    }
}
