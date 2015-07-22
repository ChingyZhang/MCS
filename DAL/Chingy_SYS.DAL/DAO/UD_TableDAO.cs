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
                r = new Chingy_SYSEntities().UD_TableList.Include("UD_ModelFields").OrderBy(m => m.InsertTime).Skip(iSkip).Take(rows.Value);
                //_listT=r.ToList<UD_TableList>();
            }
            else { r = new Chingy_SYSEntities().UD_TableList.Include("UD_ModelFields"); }

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

        public Result<Guid, string> CreateField(UD_ModelFields UD_ModelFields)
        {
            Result<Guid, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                if (UD_ModelFields.ID == Guid.Empty) UD_ModelFields.ID = Guid.NewGuid();
                UD_ModelFields.InsertTime = DateTime.Now;
                db.UD_ModelFields.Add(UD_ModelFields);
                try
                {
                    db.SaveChanges();
                    _r = new Result<Guid, string>(UD_ModelFields.ID);
                }
                catch (Exception ex) { _r = new Result<Guid, string>(Guid.Empty, ex.Message); }
                return _r;
            }
        }

        public Result<bool, string> EditField(UD_ModelFields UD_ModelFields)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                DB.UD_ModelFields _field = db.UD_ModelFields.Single(m => m.ID == UD_ModelFields.ID);
                if (_field == null) return new Result<bool, string>(false, "null");

                /* System.Reflection.PropertyInfo[] properties = UD_ModelFields.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var oa = property.GetValue(_field, null);//db.Entry(_field).Property(property.Name).CurrentValue;
                    var ob = property.GetValue(UD_ModelFields, null);
                    if (oa.ToString() != ob.ToString())
                    {
                        property.SetValue(_field, ob);
                        //db.Entry(_field).Property(property.Name).CurrentValue = rb;
                    }
                }
               
                 foreach (System.Reflection.PropertyInfo p in array)
            {
                object o = p.GetValue(a, null);
                p.SetValue(b, o, null);
            }
                 
                db.UD_ModelFields.Attach(UD_ModelFields);
                db.Entry(UD_ModelFields).State = System.Data.Entity.EntityState.Modified;*/

                
                _field.FieldName = UD_ModelFields.FieldName;
                _field.FieldDisplayName = UD_ModelFields.FieldDisplayName;
                _field.ColumnSortID = UD_ModelFields.ColumnSortID;
                /*_field.FlagEntity = UD_ModelFields.FlagEntity;*/
                _field.DataType = UD_ModelFields.DataType;
                _field.DataLength = UD_ModelFields.DataLength;
                _field.DefaultValue = UD_ModelFields.DefaultValue;
                _field.Description = UD_ModelFields.Description;
                _field.RelationType = UD_ModelFields.RelationType;
                _field.RelationTableName = UD_ModelFields.RelationTableName;
                _field.RelationFieldValue = UD_ModelFields.RelationFieldValue;
                _field.RelationFieldText = UD_ModelFields.RelationFieldText;
                _field.Position = UD_ModelFields.Position;
                _field.UpdateTime = UD_ModelFields.UpdateTime;
                _field.UpdateUser = UD_ModelFields.UpdateUser;
                try
                {
                    db.SaveChanges();
                    _r = new Result<bool, string>(true);
                }
                catch (Exception ex) { _r = new Result<bool, string>(false, ex.Message); }
                return _r;
            }

        }

        public Result<bool, string> RemoveField(Guid Guid)
        {
            Result<bool, string> _r;
            using (Chingy_SYSEntities db = new Chingy_SYSEntities())
            {
                DB.UD_ModelFields _table = db.UD_ModelFields.Single(m => m.ID == Guid);
                if (_table == null) return new Result<bool, string>(false, "null");
                else db.UD_ModelFields.Remove(_table);
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
