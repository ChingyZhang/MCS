using Chingy_SYS.DAL.DB;
using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chingy_SYS.Controllers
{
    public class DicController : Controller
    {
        //
        // GET: /Dic/

        public Chingy_SYS.BLL.Infrastructure.IDicService IDicService;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            IDicService = new Chingy_SYS.BLL.Service.DicService();
        }

        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public JsonResult GetDicList()
        {
            IList<Dictionary_Table> listDic = IDicService.GetDicList();
            return Json(listDic);
        }

        [HttpPost]
        public JsonResult GetDicColByTableCode(string TableCode)
        {
            Result<bool, IList<Dictionary_Column>> r = IDicService.GetDicColByTableCode(TableCode);
            if (!r.Success) return null;
            IList<Dictionary_Column> _listDic = r.ErrorMsg;
            return Json(_listDic);
        }

    }
}
