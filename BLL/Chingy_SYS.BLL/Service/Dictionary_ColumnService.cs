using Chingy_SYS.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.BLL.Service
{
    public class Dictionary_ColumnService : IDictionary_Column
    {
        Chingy_SYS.DAL.DAO.Dictionary_ColumnDAO Dictionary_ColumnDAO = new DAL.DAO.Dictionary_ColumnDAO();

        public Common.Result.Result<bool, string> AddDictionary_Column(DAL.DB.Dictionary_Column Dictionary_Column)
        {
            return Dictionary_ColumnDAO.AddDictionary_Column(Dictionary_Column);
        }

        public Common.Result.Result<bool, string> DestroyDictionary_Column(int ID)
        {
            return Dictionary_ColumnDAO.DestroyDictionary_Column(ID);
        }

        public Common.Result.Result<bool, IList<Chingy_SYS.DAL.DB.Dictionary_Column>> GetDicColByTableCode(string TableCode)
        {
            return Dictionary_ColumnDAO.GetDicColByTableCode(TableCode);
        }

        public IQueryable<DAL.DB.Dictionary_Column> GetDicList()
        {
            return Dictionary_ColumnDAO.GetDicList();
        }

        public Common.Result.Result<bool, string> ModifyDictionary_Column(DAL.DB.Dictionary_Column Dictionary_Column)
        {
            return Dictionary_ColumnDAO.ModifyDictionary_Column(Dictionary_Column);
        }
    }
}
