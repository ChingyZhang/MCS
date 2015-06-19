using Chingy_SYS.DAL.DB;
using Chingy_SYS.Model;
using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.DAL.DAO
{
    public class Dictionary_TableDAO
    {
        public IList<Dictionary_Table> GetDicList()
        {
            IList<Dictionary_Table> listDicT = new Chingy_SYSEntities().Dictionary_Table.ToList();
            return listDicT;
        }

        public Result<bool, string> AddDictionary_Table(Chingy_SYS.DAL.DB.Dictionary_Table Dictionary_Table)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                DB.Dictionary_Table _tableCode = db.Dictionary_Table.FirstOrDefault(m => m.Code == Dictionary_Table.Code);
                if (_tableCode != null) return new Result<bool, string>(false, "编码已存在");

                Dictionary_Table.Flag = 1;
                Dictionary_Table.InsertTime = DateTime.Now;
                db.Dictionary_Table.Add(Dictionary_Table);
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
                DB.Dictionary_Table _table = db.Dictionary_Table.FirstOrDefault(m => m.ID == ID);
                if (_table == null) return new Result<bool, string>(false, "null");
                else _table.Flag = 1;
                try
                {
                    db.SaveChanges();
                    _r = new Result<bool, string>(true);
                }
                catch (Exception ex) { _r = new Result<bool, string>(false, ex.Message); }
                return _r;
            }
        }

        public Result<bool, string> ModifyDictionary_Table(Chingy_SYS.DAL.DB.Dictionary_Table Dictionary_Table)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                DB.Dictionary_Table _table = db.Dictionary_Table.FirstOrDefault(m => m.ID == Dictionary_Table.ID);
                DB.Dictionary_Table _tableCode = db.Dictionary_Table.FirstOrDefault(m => m.Code == Dictionary_Table.Code);
                if (_tableCode != null) return new Result<bool, string>(false, "编码已存在");

                if (_table == null) return new Result<bool, string>(false, "null");
                _table.Name = Dictionary_Table.Name;
                _table.Code = Dictionary_Table.Code;
                _table.Flag = Dictionary_Table.Flag;
                _table.UpdateTime = DateTime.Now;
                _table.UpdateUser = Dictionary_Table.UpdateUser;
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
