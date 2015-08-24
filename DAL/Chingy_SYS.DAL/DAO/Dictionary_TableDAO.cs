using Chingy_SYS.DAL.DB;
using Chingy_SYS.Model;
using Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.DAL.DAO
{
    public class Dictionary_TableDAO
    {
        public IQueryable<Chingy_SYS.DAL.DB.Dictionary_Table> GetDicList()
        {
            var listDicT = new Chingy_SYSEntities().Dictionary_Table.Where(m => m.Flag == 1);
            return listDicT;
        }

        public Result<bool, string> AddDictionary_Table(DB.Dictionary_Table model)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                DB.Dictionary_Table _tableCode = db.Dictionary_Table.FirstOrDefault(m => m.Code == model.Code && m.Flag == 1);
                if (_tableCode != null) return new Result<bool, string>(false, "编码已存在");

                model.Flag = 1;
                model.InsertTime = DateTime.Now;
                db.Dictionary_Table.Add(model);
                try
                {
                    db.SaveChanges();
                    _r = new Result<bool, string>(true);
                }
                catch (Exception ex) { _r = new Result<bool, string>(false, ex.Message); }
                return _r;
            }
        }

        public Result<bool, string> DestroyDictionary_Table(int ID)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                DB.Dictionary_Table _table = db.Dictionary_Table.Find(ID);
                if (_table == null) return new Result<bool, string>(true, "null");
                else _table.Flag = 2;
                try
                {
                    db.SaveChanges();
                    _r = new Result<bool, string>(true);
                }
                catch (Exception ex) { _r = new Result<bool, string>(false, ex.Message); }
                return _r;
            }
        }

        public Result<bool, string> ModifyDictionary_Table(DB.Dictionary_Table model)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                DB.Dictionary_Table _tableCode = db.Dictionary_Table.FirstOrDefault(m => m.Code == model.Code && m.ID != model.ID);
                if (_tableCode != null) return new Result<bool, string>(false, "字典表编码重复");
                DB.Dictionary_Table _table = db.Dictionary_Table.Find(model.ID);
                if (_table == null) return new Result<bool, string>(false, "字典表不存在");
                
                _table.Name = model.Name;
                _table.Code = model.Code;
                _table.UpdateTime = DateTime.Now;
                _table.UpdateUser = model.UpdateUser;
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
