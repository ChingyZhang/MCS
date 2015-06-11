using Chingy_SYS.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.DAL.DAO
{
    public class TableDAO
    {
        public IList<UD_TableList> GetTableList()
        {
            return new Chingy_SYSEntities().UD_TableList.ToList();
        }

        public bool AddTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableModel)
        {
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                if (UD_TableModel.ID == Guid.Empty) UD_TableModel.ID = Guid.NewGuid();
                UD_TableModel.InsertTime = DateTime.Now;
                db.UD_TableList.AddObject(UD_TableModel);
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch { return false; }
            }
        }

        public bool DestroyTable(Guid Guid)
        {
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                DB.UD_TableList _table = db.UD_TableList.FirstOrDefault(m => m.ID == Guid);
                if (_table == null) return true;
                else db.UD_TableList.DeleteObject(_table);
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch { return false; }
            }
        }

        public bool DestroyTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableList)
        {
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                db.UD_TableList.DeleteObject(UD_TableList);
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch { return false; }
            }
        }

        public bool ModifyTable(Chingy_SYS.DAL.DB.UD_TableList UD_TableList)
        {
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                DB.UD_TableList _table = db.UD_TableList.FirstOrDefault(m => m.ID == UD_TableList.ID);
                if (_table == null) return false;
                _table = UD_TableList;
                _table.UpdateTime = DateTime.Now;
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch { return false; }
            }
        }
    }
}
