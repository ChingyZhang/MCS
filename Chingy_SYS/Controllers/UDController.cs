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

        public Chingy_SYS.BLL.Infrastructure.IUD_Table TableService;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            TableService = new Chingy_SYS.BLL.Service.UD_TableListService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetTableList()
        {
            IList<UD_TableList> listTableModel = TableService.GetTableList();
            return Json(listTableModel);
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
            Result<bool, string> _r =TableService.DestroyTable(Guid);
            return Json(_r);
        }
    }


}
