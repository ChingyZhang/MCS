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
        public JsonResult GetDicList(int? id)
        {
            var listDic = Dictionary_TableService.GetDicList();
            if (id != null) listDic = listDic.Where(m => m.ID == id).ToList();
            var r = from dic in listDic
                    orderby dic.ID
                    select new { ID = dic.ID, Name = dic.Name, Code = dic.Code, InsertTime = dic.InsertTime };
            return Json(r.ToList());
        }

        [HttpPost]
        public JsonResult SaveTable(Dictionary_Table table)
        {
            Result<bool, string> result;
            if (table.ID == 0) result = Dictionary_TableService.AddDictionary_Table(table);
            else result = Dictionary_TableService.ModifyDictionary_Table(table);
            return Json(result);
        }

        [HttpPost]
        public JsonResult DeleteTable(int id)
        {
            if (id == 0) return Json(false);
            var result = Dictionary_TableService.DestroyDictionary_Table(id);
            return Json(result);
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
            return PartialView(id);
        }

        [HttpPost]
        public JsonResult GetColList(int id)
        {
            if (id == 0) return null;
            Dictionary_Table dic = Dictionary_TableService.GetDicList().FirstOrDefault(m => m.ID == id);
            if (dic == null) return null;
            var listDic = Dictionary_ColumnService.GetDicColByTableCode(dic.Code).ErrorMsg;
            var r = from _dic in listDic
                    orderby _dic.ID
                    select new { ID = _dic.ID, Table = _dic.Table, Code = _dic.Code, Name = _dic.Name };
            return Json(r.ToList());
        }

        [HttpPost]
        public JsonResult SaveColumn(Dictionary_Column dictionary_column)
        {
            Result<bool, string> result;
            if (dictionary_column.ID == 0) result = Dictionary_ColumnService.AddDictionary_Column(dictionary_column);
            else result = Dictionary_ColumnService.ModifyDictionary_Column(dictionary_column);
            return Json(result);
        }

        [HttpPost]
        public JsonResult DeleteColumn(int id)
        {
            if (id == 0) return Json(false);
            var result = Dictionary_ColumnService.DestroyDictionary_Column(id);
            return Json(result);
        }
    }
}
