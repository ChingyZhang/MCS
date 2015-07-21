using Chingy_SYS.DAL.DB;
using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chingy_SYS.Controllers
{
    public class UDController : Controller
    {
        //
        // GET: /UD/

        public Chingy_SYS.BLL.Infrastructure.IUD_TableService TableService;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            TableService = new Chingy_SYS.BLL.Service.UD_TableListService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Guid TableID)
        {
            return View(TableID);
        }

        [HttpPost]
        public JsonResult GetTableList(Guid? id, int? rows, int? page)
        {
            Result<IDictionary<string, int>, IList<UD_TableList>> Result = TableService.GetTableList(id, rows, page);
            IList<UD_TableList> listT = Result.ErrorMsg;

            int iPageNumber = Result.Success["pageNumber"];
            int iTotal = Result.Success["total"];
            var r = from m in listT
                    select new { ID = m.ID, Name = m.Name, DisplayName = m.DisplayName, ExtFlag = m.ExtFlag, ModelName = m.ModelName, TreeFlag = m.TreeFlag, InsertTime = m.InsertTime, pageNumber = iPageNumber, pageTotal = iTotal };
            return Json(r);
        }

        [HttpPost]
        public JsonResult SaveTable(UD_TableList UD_TableList)
        {
            Result<bool, string> _r;
            if (UD_TableList.ID == Guid.Empty) _r = TableService.AddTable(UD_TableList);
            else _r = TableService.ModifyTable(UD_TableList);
            return Json(_r);
        }

        [HttpPost]
        public JsonResult DestroyTable(Guid Guid)
        {
            Result<bool, string> _r = TableService.DestroyTable(Guid);
            return Json(_r);
        }

        public ActionResult GetFieldDetail(Guid TableID, Guid FieldID)
        {
            ViewBag.TableID = TableID;
            ViewBag.ID = FieldID;
            return View();
        }

        [HttpPost]
        public JsonResult GetFieldList(Guid TableID, Guid? FieldID)
        {
            IList<UD_ModelFields> listField = null;
            var res = TableService.GetTableList(TableID, null, null).ErrorMsg.FirstOrDefault().UD_ModelFields;
            if (FieldID.HasValue) listField = res.Where(m => m.ID == (FieldID.HasValue ? FieldID.Value : m.ID)).ToList();
            else listField = res.ToList<UD_ModelFields>();
            if (listField == null) return null;
            var r = from m in listField
                    orderby m.ColumnSortID.HasValue ? m.ColumnSortID : 99999, m.Position
                    select new { m.ID, m.TableID, m.FieldName, m.FieldDisplayName, m.ColumnSortID, m.FlagEntity, m.DataType, m.DataLength, m.Precision, m.DefaultValue, m.Description, m.RelationType, m.RelationTableName, m.RelationFieldValue, m.RelationFieldText, m.Position };
            return Json(r);
        }


        [HttpPost]
        public JsonResult SaveField(UD_ModelFields UD_ModelFields)
        {
            if (UD_ModelFields.ID == Guid.Empty)
            {
                if (UD_ModelFields.TableID == Guid.Empty) return Json(new Result<bool, string>(false, "创建失败"));
                Result<Guid, string> _r = TableService.CreateField(UD_ModelFields);
                if (_r.Success == Guid.Empty) return Json(new Result<bool, string>(false, _r.ErrorMsg));
                return Json(_r);
            }
            else { 
                Result<bool, string> _r;
                if (UD_ModelFields.ID == Guid.Empty) return Json(new Result<bool, string>(false, "更新失败"));
                _r = TableService.EditField(UD_ModelFields);
                return Json(_r);
            }
        }
        //[HttpPost]
        //public JsonResult CreateField(UD_ModelFields UD_ModelFields)
        //{
        //    if (UD_ModelFields.TableID == Guid.Empty) return Json(new Result<bool, string>(false, "创建失败"));
        //    Result<Guid, string> _r = TableService.CreateField(UD_ModelFields);
        //    if (_r.Success == Guid.Empty) return Json(new Result<bool, string>(false, _r.ErrorMsg));
        //    return Json(_r);
        //}

        //[HttpPost]
        //public JsonResult EditField(UD_ModelFields UD_ModelFields)
        //{
        //    Result<bool, string> _r;
        //    if (UD_ModelFields.ID == Guid.Empty) return Json(new Result<bool, string>(false, "更新失败"));
        //    _r = TableService.EditField(UD_ModelFields);
        //    return Json(_r);
        //}

        [HttpPost]
        public JsonResult RemoveField(Guid Guid)
        {
            Result<bool, string> _r = TableService.RemoveField(Guid);
            return Json(_r);
        }

    }


}
