using Chingy_SYS.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.BLL.Infrastructure
{
    public interface IDictionary_Column
    {
        Core.Result.Result<bool, string> AddDictionary_Column(Chingy_SYS.DAL.DB.Dictionary_Column Dictionary_Column);
        Core.Result.Result<bool, string> DestroyDictionary_Column(int ID);
        Core.Result.Result<bool, IList<Dictionary_Column>> GetDicColByTableCode(string TableCode);
        IQueryable<Chingy_SYS.DAL.DB.Dictionary_Column> GetDicList();
        Core.Result.Result<bool, string> ModifyDictionary_Column(Chingy_SYS.DAL.DB.Dictionary_Column Dictionary_Column);
    }
}
