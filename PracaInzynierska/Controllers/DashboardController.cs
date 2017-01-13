using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracaInzynierska.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Client()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Worker()
        {
            return View();
        }

        public ActionResult OfficeWorker()
        {
            return View();
        }
    }
}