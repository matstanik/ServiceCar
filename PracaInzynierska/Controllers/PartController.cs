using PracaInzynierska.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracaInzynierska.Controllers
{
    public class PartController : Controller
    {
        private ModelContext db = new ModelContext();
        // GET: Part
        public ActionResult Index()
        {
            return View();
        }

        public HtmlString PartsList()
        {
            var result = db.services.ToList();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }
    }
}