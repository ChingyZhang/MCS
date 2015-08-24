using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.BLL.Service
{
    public class UD_PanelService : Chingy_SYS.BLL.Infrastructure.IUD_Panel
    {
        Chingy_SYS.DAL.DAO.UD_PanelDAO UD_PanelDAO = new DAL.DAO.UD_PanelDAO();

        public Core.Result.Result<bool, string> Create(DAL.DB.UD_Panel model)
        {
            return UD_PanelDAO.Create(model);
        }

        public Core.Result.Result<bool, string> Delete(DAL.DB.UD_Panel model)
        {
            return UD_PanelDAO.Delete(model);
        }

        public Core.Result.Result<bool, string> Edit(DAL.DB.UD_Panel model)
        {
            return UD_PanelDAO.Edit(model);
        }

        public Core.Result.Result<IDictionary<string, int>, IList<DAL.DB.UD_Panel>> GetList(Guid? id, int? rows, int? page)
        {
            return UD_PanelDAO.GetList(id, rows, page);
        }
    }
}
