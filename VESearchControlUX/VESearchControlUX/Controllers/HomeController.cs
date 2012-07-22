using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VESearchControlUX.Models;

namespace VESearchControlUX.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = new SearchControlModel<IFirmDataElement>();
            return View(model);
        }

        public JsonResult Search(SearchRequest query)
        {

        }
    }
}
