using Chingy_SYS.Model;
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

        public Chingy_SYS.BLL.Infrastructure.ITableService TableService;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            TableService = new Chingy_SYS.BLL.Service.TableService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetTableList()
        {
            IList<UD_TableModel> listTableModel = TableService.GetTableList();
            return Json(listTableModel);
        }

    }
}
