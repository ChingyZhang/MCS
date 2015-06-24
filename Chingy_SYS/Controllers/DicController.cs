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

        public Chingy_SYS.BLL.Infrastructure.IDictionary_Table Dictionary_TableService;
        public Chingy_SYS.BLL.Infrastructure.IDictionary_Column Dictionary_ColumnService;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            Dictionary_TableService = new Chingy_SYS.BLL.Service.Dictionary_TableService();
            Dictionary_ColumnService = new Chingy_SYS.BLL.Service.Dictionary_ColumnService();
        }

        public ActionResult Index()
        {
            IList<Dictionary_Table> listDic = Dictionary_TableService.GetDicList();
            SelectList slDicable = new SelectList(listDic);
            ViewBag.slDicable = slDicable;
            return View();
        }

        [HttpPost]
        public JsonResult GetDicList()
        {
            IList<Dictionary_Table> listDic = Dictionary_TableService.GetDicList();
            return Json(listDic);
        }

        [HttpPost]
        public JsonResult GetDicColByTableCode(string TableCode)
        {
            Result<bool, IList<Dictionary_Column>> r = Dictionary_ColumnService.GetDicColByTableCode(TableCode);
            if (!r.Success) return null;
            IList<Dictionary_Column> _listDic = r.ErrorMsg;
            return Json(_listDic);
        }

        public PartialViewResult Detail(int id)//如果前台传来的是url如Dic/Detail/1这种样式的话此处参数名必须为id，否则url路由不到该方法
        {
            //if (TableID == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            return PartialView(id);
        }

        public JsonResult GetColList(int? id)
        {
            if (id == null) return null;
            Dictionary_Table dic = Dictionary_TableService.GetDicList().FirstOrDefault(m => m.ID == id);
            if (dic == null) return null;
            IList<Dictionary_Column> listDic = Dictionary_ColumnService.GetDicColByTableCode(dic.Code).ErrorMsg;
            return Json(listDic);
        }
    }
}
