using Chingy_SYS.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Result;
using System.Collections;

namespace Chingy_SYS.DAL.DAO
{
    public class UD_TableDAO
    {
        public Result<IDictionary<string, int>, IList<UD_TableList>> GetTableList(Guid? id, int? rows, int? page)
        {
            IDictionary<string, int> _dic = new Dictionary<string, int>();
            int iTotal = new Chingy_SYSEntities().UD_TableList.Count();
            _dic.Add("total", iTotal);
            _dic.Add("pageNumber", page.HasValue ? page.Value : 1);


            IList<UD_TableList> _listT = null; //= new Chingy_SYSEntities().UD_TableList;
            IQueryable r;
            int iSkip = 0;
            if (rows.HasValue && page.HasValue)
            {
                iSkip = rows.Value * (page.Value - 1 > 0 ? page.Value - 1 : 0);
                r = new Chingy_SYSEntities().UD_TableList.OrderBy(m => m.InsertTime).Skip(iSkip).Take(rows.Value);
                //_listT=r.ToList<UD_TableList>();
            }
            else { r = new Chingy_SYSEntities().UD_TableList; }

            _listT = r.Cast<UD_TableList>().ToList();
            if (id != null) _listT = _listT.Where(m => m.ID == id).ToList<UD_TableList>();//new Chingy_SYSEntities().UD_TableList.Where(m => m.ID == id).ToList();

            return new Result<IDictionary<string, int>, IList<UD_TableList>>(_dic, _listT);
        }

        public Result<bool, string> AddTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableModel)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                if (UD_TableModel.ID == Guid.Empty) UD_TableModel.ID = Guid.NewGuid();
                UD_TableModel.InsertTime = DateTime.Now;
                db.UD_TableList.Add(UD_TableModel);
                try
                {
                    db.SaveChanges();
                    _r = new Result<bool, string>(true);
                }
                catch (Exception ex) { _r = new Result<bool, string>(false, ex.Message); }
                return _r;
            }
        }

        public Result<bool, string> DestroyTable(Guid Guid)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                DB.UD_TableList _table = db.UD_TableList.FirstOrDefault(m => m.ID == Guid);
                if (_table == null) return new Result<bool, string>(false, "null");
                else db.UD_TableList.Remove(_table);
                try
                {
                    db.SaveChanges();
                    _r = new Result<bool, string>(true);
                }
                catch (Exception ex) { _r = new Result<bool, string>(false, ex.Message); }
                return _r;
            }
        }

        public Result<bool, string> DestroyTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableList)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                db.UD_TableList.Remove(UD_TableList);
                try
                {
                    db.SaveChanges();
                    _r = new Result<bool, string>(true);
                }
                catch (Exception ex) { _r = new Result<bool, string>(false, ex.Message); }
                return _r;
            }
        }

        public Result<bool, string> ModifyTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableList)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                DB.UD_TableList _table = db.UD_TableList.FirstOrDefault(m => m.ID == UD_TableList.ID);
                if (_table == null) return new Result<bool, string>(false, "null");
                _table.Name = UD_TableList.Name;
                _table.DisplayName = UD_TableList.DisplayName;
                _table.ExtFlag = UD_TableList.ExtFlag;
                _table.ModelName = UD_TableList.ModelName;
                _table.TreeFlag = UD_TableList.TreeFlag;
                _table.UpdateTime = DateTime.Now;
                _table.UpdateUser = UD_TableList.UpdateUser;
                try
                {
                    db.SaveChanges();
                    _r = new Result<bool, string>(true);
                }
                catch (Exception ex) { _r = new Result<bool, string>(false, ex.Message); }
                return _r;
            }
        }
    }
}
