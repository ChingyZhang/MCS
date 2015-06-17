using Chingy_SYS.DAL.DB;
using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.BLL.Infrastructure
{
    public interface IDictionary_Table
    {
        IList<Dictionary_Table> GetDicList();
        Result<bool, string> AddDictionary_Table(Chingy_SYS.DAL.DB.Dictionary_Table Dictionary_Table);
        Result<bool, string> DestroyDictionary_Table(int ID);
        Result<bool, string> ModifyDictionary_Table(Chingy_SYS.DAL.DB.Dictionary_Table Dictionary_Table);
    }
}
