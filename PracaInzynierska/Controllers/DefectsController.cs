using PracaInzynierska.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracaInzynierska.Controllers
{
    public class DefectsController : Controller
    {
        private ModelContext db = new ModelContext();
        // GET: Defects
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString AddDefect()
        {
           
            var result = db.SaveChanges();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }
    }
}