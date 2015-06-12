using Chingy_SYS.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Result;

namespace Chingy_SYS.DAL.DAO
{
    public class TableDAO
    {
        public IList<UD_TableList> GetTableList()
        {
            return new Chingy_SYSEntities().UD_TableList.ToList();
        }

        public Result<bool, string> AddTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableModel)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                if (UD_TableModel.ID == Guid.Empty) UD_TableModel.ID = Guid.NewGuid();
                UD_TableModel.InsertTime = DateTime.Now;
                db.UD_TableList.AddObject(UD_TableModel);
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
                else db.UD_TableList.DeleteObject(_table);
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
                db.UD_TableList.DeleteObject(UD_TableList);
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
