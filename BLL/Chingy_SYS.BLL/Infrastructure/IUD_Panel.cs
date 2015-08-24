using System;
namespace Chingy_SYS.BLL.Infrastructure
{
    public interface IUD_Panel
    {
        Core.Result.Result<bool, string> Create(Chingy_SYS.DAL.DB.UD_Panel model);
        Core.Result.Result<bool, string> Delete(Chingy_SYS.DAL.DB.UD_Panel model);
        Core.Result.Result<bool, string> Edit(Chingy_SYS.DAL.DB.UD_Panel model);
        Core.Result.Result<System.Collections.Generic.IDictionary<string, int>, System.Collections.Generic.IList<Chingy_SYS.DAL.DB.UD_Panel>> GetList(Guid? id, int? rows, int? page);
    }
}
