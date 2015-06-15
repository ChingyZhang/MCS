using Chingy_SYS.DAL.DB;
using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.BLL.Infrastructure
{
    public interface IDicService
    {
        Result<bool, IList<Dictionary_Column>> GetDicColByTableCode(string TableCode);
    }
}
