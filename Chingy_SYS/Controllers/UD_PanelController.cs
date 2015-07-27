using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chingy_SYS.Controllers
{
    public class UD_PanelController : Controller
    {
        //
        // GET: /UD_Panel/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPanelList()
        {
            return null;
        }
    }
}
