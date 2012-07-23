using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VESearchControlUX.Models;
using VESearchControlUX.Game.Mock;
using System.Threading;

namespace VESearchControlUX.Controllers
{
    public class HomeController : Controller
    {
     
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Search(SearchRequest query)
        {
            var elements = new List<IFirmDataElement>();
            if (string.IsNullOrWhiteSpace(query.q))
            {
                elements.Add(new PlaceholderFirmDataElement("No search query. Please enter a search query."));
                return Json(elements);
            }

            elements.AddRange(ElementProvider.Singleton.AllElements);

            var queryResults = elements.Where(q => (q.Title.Contains(query.q) || q.Description.Contains(query.q))).ToList();
            //Thread.Sleep(1500); -- to simulate data access
            if (!queryResults.Any())
            {
                elements.Clear();
                elements.Add(new PlaceholderFirmDataElement("No matching items found"));
                return Json(elements);
            }

            return Json(queryResults);
        }
    }
}
