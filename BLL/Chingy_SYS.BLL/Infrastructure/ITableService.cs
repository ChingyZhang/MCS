using Chingy_SYS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.BLL.Infrastructure
{
    public interface ITableService
    {
        IList<UD_TableModel> GetTableList();
    }
}
