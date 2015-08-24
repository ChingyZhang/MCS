using Chingy_SYS.DAL.DB;
using Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.DAL.DAO
{
    public class UD_DetailViewDAO
    {

        public Result<IDictionary<string, int>, IList<UD_DetailView>> GetList(Guid? id, int? rows, int? page)
        {
            IDictionary<string, int> _dic = new Dictionary<string, int>();
            int iTotal = new Chingy_SYSEntities().UD_DetailView.Count();
            _dic.Add("total", iTotal);
            _dic.Add("pageNumber", page.HasValue ? page.Value : 1);


            IList<UD_DetailView> _listT = null;
            IQueryable r;
            int iSkip = 0;
            if (rows.HasValue && page.HasValue)
            {
                iSkip = rows.Value * (page.Value - 1 > 0 ? page.Value - 1 : 0);
                r = new Chingy_SYSEntities().UD_DetailView.OrderBy(m => m.InsertTime).Skip(iSkip).Take(rows.Value);
            }
            else { r = new Chingy_SYSEntities().UD_DetailView; }

            _listT = r.Cast<UD_DetailView>().ToList();
            if (id != null) _listT = _listT.Where(m => m.ID == id).ToList<UD_DetailView>();

            return new Result<IDictionary<string, int>, IList<UD_DetailView>>(_dic, _listT);
        }

        public Result<bool, string> Create(Chingy_SYS.DAL.DB.UD_DetailView model)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities context = new Chingy_SYSEntities())
            {
                var _m = context.UD_DetailView.Single(m => m.Code == model.Code);
                if (_m != null) return new Result<bool, string>(false, "property repeat");
                model.ID = Guid.NewGuid();
                model.InsertTime = DateTime.Now;
                try
                {
                    context.UD_DetailView.Add(model);
                    context.SaveChanges();
                    _r = new Result<bool, string>(true);
                }
                catch (Exception ex) { _r = new Result<bool, string>(false, ex.Message); }
                return _r;
            }
        }

        public Result<bool, string> Edit(Chingy_SYS.DAL.DB.UD_DetailView model)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities context = new Chingy_SYSEntities())
            {
                var _m = context.UD_DetailView.Single(m => m.Code == model.Code && m.ID != model.ID);
                if (_m != null) return new Result<bool, string>(false, "property repeat");

                _m = context.UD_DetailView.Single(m => m.ID == model.ID);
                _m.Code = model.Code;
                _m.Name = model.Name;
                _m.UpdateTime = DateTime.Now;
                try
                {
                    context.SaveChanges();
                    _r = new Result<bool, string>(true);
                }
                catch (Exception ex) { _r = new Result<bool, string>(false, ex.Message); }
                return _r;
            }
        }

        public Result<bool, string> Delete(Chingy_SYS.DAL.DB.UD_DetailView model)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities context = new Chingy_SYSEntities())
            {
                var _m = context.UD_DetailView.Single(m => m.ID == model.ID);
                if (_m == null) return new Result<bool, string>(true, "empty original");
                try
                {
                    context.UD_DetailView.Remove(_m);
                    context.SaveChanges();
                    _r = new Result<bool, string>(true);
                }
                catch (Exception ex) { _r = new Result<bool, string>(false, ex.Message); }
                return _r;
            }
        }

    }
}
