using Chingy_SYS.DAL.DB;
using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.DAL.DAO
{
    public class Dictionary_ColumnDAO
    {
        public IQueryable<Dictionary_Column> GetDicList()
        {
            var list = new Chingy_SYSEntities().Dictionary_Column;
            return list;
        }

        public Result<bool, IList<Dictionary_Column>> GetDicColByTableCode(string TableCode)
        {
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                Dictionary_Table _dicT = db.Dictionary_Table.FirstOrDefault(m => m.Code == TableCode);
                if (_dicT == null) return new Result<bool, IList<Dictionary_Column>>(false, null);
                else return new Result<bool, IList<Dictionary_Column>>(true, _dicT.Dictionary_Column.ToList());
            }
        }
        public Result<bool, string> AddDictionary_Column(Chingy_SYS.DAL.DB.Dictionary_Column Model)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                DB.Dictionary_Column _col2 = db.Dictionary_Column.FirstOrDefault(m => m.ID == Model.ID && m.Code == Model.Code);
                if (_col2 != null) return new Result<bool, string>(false, "编码已存在");

                Model.Flag = 1;
                Model.InsertTime = DateTime.Now;
                try
                {
                    db.Dictionary_Column.Add(Model);
                    db.SaveChanges();
                    _r = new Result<bool, string>(true);
                }
                catch (Exception ex) { _r = new Result<bool, string>(false, ex.Message); }
                return _r;
            }
        }

        public Result<bool, string> DestroyDictionary_Column(int ID)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                DB.Dictionary_Column _col = db.Dictionary_Column.Find(ID);
                if (_col == null) return new Result<bool, string>(true, "字典项不存在");
                else
                {
                    try
                    {
                        db.Dictionary_Column.Remove(_col);
                        db.SaveChanges();
                        _r = new Result<bool, string>(true);
                    }
                    catch (Exception ex) { _r = new Result<bool, string>(false, ex.Message); }
                    return _r;
                }
            }
        }

        public Result<bool, string> ModifyDictionary_Column(Chingy_SYS.DAL.DB.Dictionary_Column Model)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                DB.Dictionary_Column _col = db.Dictionary_Column.Find(Model.ID);
                if (_col == null) return new Result<bool, string>(false, "字典项不存在");
                _col.Name = Model.Name;
                _col.Code = Model.Code;
                _col.UpdateTime = DateTime.Now;
                _col.UpdateUser = Model.UpdateUser;
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
