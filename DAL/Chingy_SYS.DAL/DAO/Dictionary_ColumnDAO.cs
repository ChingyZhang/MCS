using Chingy_SYS.DAL.DB;
using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.DAL.DAO
{
    public class Dictionary_ColumnDAO : Chingy_SYS.DAL.DAO.IDictionary_Column
    {
        public IList<Dictionary_Column> GetDicList()
        {
            IList<Dictionary_Column> list = new Chingy_SYSEntities().Dictionary_Column.ToList();
            return list;
        }

        public Result<bool, IList<Dictionary_Column>> GetDicColByTableCode(string TableCode)
        {
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                Dictionary_Table _dicT = db.Dictionary_Table.FirstOrDefault(m => m.Code == TableCode);
                if (_dicT == null) return new Result<bool, IList<Dictionary_Column>>(false, null);
                var _listCol = db.Dictionary_Column.Where(m => m.Table == _dicT.ID);//_dicT.Dictionary_Column.ToList();
                if (_listCol == null) return new Result<bool, IList<Dictionary_Column>>(true, null);
                else return new Result<bool, IList<Dictionary_Column>>(true, _listCol.ToList<Dictionary_Column>());
            }
        }
        public Result<bool, string> AddDictionary_Column(Chingy_SYS.DAL.DB.Dictionary_Column Dictionary_Column)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                DB.Dictionary_Column _col2 = db.Dictionary_Column.FirstOrDefault(m => m.Code == Dictionary_Column.Code && m.Table == Dictionary_Column.Table);
                if (_col2 != null) return new Result<bool, string>(false, "编码已存在");

                Dictionary_Column.Flag = 1;
                Dictionary_Column.InsertTime = DateTime.Now;
                db.Dictionary_Column.Add(Dictionary_Column);
                try
                {
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
                DB.Dictionary_Column _col = db.Dictionary_Column.FirstOrDefault(m => m.ID == ID);
                if (_col == null) return new Result<bool, string>(false, "null");
                else db.Dictionary_Column.Remove(_col);
                try
                {
                    db.SaveChanges();
                    _r = new Result<bool, string>(true);
                }
                catch (Exception ex) { _r = new Result<bool, string>(false, ex.Message); }
                return _r;
            }
        }

        public Result<bool, string> ModifyDictionary_Column(Chingy_SYS.DAL.DB.Dictionary_Column Dictionary_Column)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                DB.Dictionary_Column _col = db.Dictionary_Column.FirstOrDefault(m => m.ID == Dictionary_Column.ID);
                if (_col == null) return new Result<bool, string>(false, "null");
                DB.Dictionary_Column _col2 = db.Dictionary_Column.FirstOrDefault(m => m.Code == Dictionary_Column.Code);
                if (_col2 != null) return new Result<bool, string>(false, "编码已存在");

                _col.Name = Dictionary_Column.Name;
                _col.Code = Dictionary_Column.Code;
                //_col.Flag = Dictionary_Column.Flag;
                _col.UpdateTime = DateTime.Now;
                _col.UpdateUser = Dictionary_Column.UpdateUser;
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
