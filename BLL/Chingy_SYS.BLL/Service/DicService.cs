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
        public Common.Result.Result<bool, IList<DAL.DB.Dictionary_Column>> GetDicColByTableCode(string TableCode)
        {
            throw new NotImplementedException();
        }
    }
}
