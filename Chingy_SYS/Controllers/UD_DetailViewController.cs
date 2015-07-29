using Chingy_SYS.DAL.DB;
using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chingy_SYS.Controllers
{
    public class UD_DetailViewController : Controller
    {
        Chingy_SYS.BLL.Infrastructure.IUD_DetailView IUD_DetailView;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            IUD_DetailView = new Chingy_SYS.BLL.Service.UD_DetailViewService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetList(Guid? id, int? rows, int? page)
        {
            Result<IDictionary<string, int>, IList<UD_DetailView>> Result = IUD_DetailView.GetList(id, rows, page);
            IList<UD_DetailView> listT = Result.ErrorMsg;

            int iPageNumber = Result.Success["pageNumber"];
            int iTotal = Result.Success["total"];
            var r = from m in listT
                    select new { ID = m.ID, Name = m.Name, Code = m.Code, pageNumber = iPageNumber, pageTotal = iTotal };
            return Json(r);
        }

    }
}
