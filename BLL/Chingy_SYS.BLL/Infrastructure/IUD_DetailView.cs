using System;
namespace Chingy_SYS.BLL.Infrastructure
{
    public interface IUD_DetailView
    {
        Core.Result.Result<bool, string> Create(Chingy_SYS.DAL.DB.UD_DetailView model);
        Core.Result.Result<bool, string> Delete(Chingy_SYS.DAL.DB.UD_DetailView model);
        Core.Result.Result<bool, string> Edit(Chingy_SYS.DAL.DB.UD_DetailView model);
        Core.Result.Result<System.Collections.Generic.IDictionary<string, int>, System.Collections.Generic.IList<Chingy_SYS.DAL.DB.UD_DetailView>> GetList(Guid? id, int? rows, int? page);
    }
}
