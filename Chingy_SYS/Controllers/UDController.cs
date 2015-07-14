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

        public ActionResult GetTableList()
        {
            return View();
        }

        public ActionResult GetTableDetail(Guid id)
        {
            return View(id);
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
            //r = r.Skip(start).Take(rows.Value);
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

        public PartialViewResult GetFieldList(Guid id)
        {
            return PartialView(id);
        }

        public ActionResult GetFieldDetail(Guid? TableID, string ID)
        {
            ViewBag.TableID = TableID;
            ViewBag.ID = ID;
            return View();
        }

        [HttpPost]
        public JsonResult GetFieldList(Guid TableID,string)
        {

        }

    }


}
