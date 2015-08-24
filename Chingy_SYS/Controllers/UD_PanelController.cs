using Chingy_SYS.DAL.DB;
using Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chingy_SYS.Controllers
{
    public class UD_PanelController : Controller
    {
        Chingy_SYS.BLL.Infrastructure.IUD_Panel IUD_Panel;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            IUD_Panel = new Chingy_SYS.BLL.Service.UD_PanelService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetList(Guid? id, int? rows, int? page)
        {
            Result<IDictionary<string, int>, IList<UD_Panel>> Result = IUD_Panel.GetList(id, rows, page);
            IList<UD_Panel> listT = Result.ErrorMsg;

            int iPageNumber = Result.Success["pageNumber"];
            int iTotal = Result.Success["total"];
            var r = from m in listT
                    select new { ID = m.ID, Name = m.Name, Code = m.Code, SortID = m.SortID, Enabled = m.Enabled, Description = m.Description, DisplayType = m.DisplayType, FieldCount = m.FieldCount, AdvanceFind = m.AdvanceFind, DefaultSortFields = m.DefaultSortFields, DetailView = m.DetailView, pageNumber = iPageNumber, pageTotal = iTotal };
            return Json(r);
        }
    }
}
