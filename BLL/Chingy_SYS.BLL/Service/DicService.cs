using Chingy_SYS.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.BLL.Service
{
    public class DicService : IDicService
    {
        Chingy_SYS.DAL.DAO.DictionaryDAO DictionaryDAO = new DAL.DAO.DictionaryDAO();

        public Common.Result.Result<bool, IList<DAL.DB.Dictionary_Column>> GetDicColByTableCode(string TableCode)
        {
            throw new NotImplementedException();
        }

        public IList<DAL.DB.Dictionary_Table> GetDicList()
        {
            return DictionaryDAO.GetDicList();
        }

        public Common.Result.Result<bool, string> AddDictionary_Table(DAL.DB.Dictionary_Table Dictionary_Table)
        {
            throw new NotImplementedException();
        }

        public Common.Result.Result<bool, string> DestroyDictionary_Table(int ID)
        {
            throw new NotImplementedException();
        }

        public Common.Result.Result<bool, string> ModifyDictionary_Table(DAL.DB.Dictionary_Table Dictionary_Table)
        {
            throw new NotImplementedException();
        }
    }
}
