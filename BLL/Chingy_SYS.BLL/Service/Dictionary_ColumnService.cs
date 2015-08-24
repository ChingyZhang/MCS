using Chingy_SYS.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.BLL.Service
{
    public class Dic
    {
        public string Code { get; set; }
        public IList<Chingy_SYS.DAL.DB.Dictionary_Column> DicCol { get; set; }
        public Dic(string code, IList<Chingy_SYS.DAL.DB.Dictionary_Column> dicCol)
        {
            Code = code;
            DicCol = dicCol;
        }
    }
    public class Dictionary_ColumnService : IDictionary_Column
    {
        Chingy_SYS.DAL.DAO.Dictionary_ColumnDAO Dictionary_ColumnDAO = new DAL.DAO.Dictionary_ColumnDAO();

        public Core.Result.Result<bool, string> AddDictionary_Column(DAL.DB.Dictionary_Column Dictionary_Column)
        {
            return Dictionary_ColumnDAO.AddDictionary_Column(Dictionary_Column);
        }

        public Core.Result.Result<bool, string> DestroyDictionary_Column(int ID)
        {
            return Dictionary_ColumnDAO.DestroyDictionary_Column(ID);
        }

        public Core.Result.Result<bool, IList<Chingy_SYS.DAL.DB.Dictionary_Column>> GetDicColByTableCode(string TableCode)
        {
            Core.Cache.ICache _cache = new Core.Cache.RuntimeCache();
            Core.Result.Result<bool, IList<Chingy_SYS.DAL.DB.Dictionary_Column>> r;
            if (_cache.Exists(TableCode))
            {
                var _d = _cache.Get<Dic>(TableCode);
                r = new Core.Result.Result<bool, IList<DAL.DB.Dictionary_Column>>(true, _d.DicCol);
            }
            else
            {
                r = Dictionary_ColumnDAO.GetDicColByTableCode(TableCode);
                Dic _dic = new Dic(TableCode, r.ErrorMsg);
                _cache.Add(TableCode, _dic);
            }

            return r;
        }

        public IQueryable<DAL.DB.Dictionary_Column> GetDicList()
        {
            return Dictionary_ColumnDAO.GetDicList();
        }

        public Core.Result.Result<bool, string> ModifyDictionary_Column(DAL.DB.Dictionary_Column Dictionary_Column)
        {
            return Dictionary_ColumnDAO.ModifyDictionary_Column(Dictionary_Column);
        }
    }
}
