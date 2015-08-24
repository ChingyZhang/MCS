using Chingy_SYS.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.BLL.Service
{
    public class UD_DetailViewService : IUD_DetailView
    {
        Chingy_SYS.DAL.DAO.UD_DetailViewDAO UD_DetailViewDAO = new DAL.DAO.UD_DetailViewDAO();

        public Core.Result.Result<bool, string> Create(DAL.DB.UD_DetailView model)
        {
            return UD_DetailViewDAO.Create(model);
        }

        public Core.Result.Result<bool, string> Delete(DAL.DB.UD_DetailView model)
        {
            return UD_DetailViewDAO.Delete(model);
        }

        public Core.Result.Result<bool, string> Edit(DAL.DB.UD_DetailView model)
        {
            return UD_DetailViewDAO.Edit(model);
        }

        public Core.Result.Result<IDictionary<string, int>, IList<DAL.DB.UD_DetailView>> GetList(Guid? id, int? rows, int? page)
        {
            return UD_DetailViewDAO.GetList(id, rows, page);
        }
    }
}
