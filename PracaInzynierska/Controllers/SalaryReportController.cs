using PracaInzynierska.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PracaInzynierska.Models.Entities;

namespace PracaInzynierska.Controllers
{
    public class SalaryReportController : Controller
    {
        private ModelContext db = new ModelContext();
        // GET: SalaryReport
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UserSalaryList()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString UserSalaryList(int WorkerId)
        {
            var result = db.salaryReport.Where(x => x.WorkerId == WorkerId).ToList();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }
        
        public HtmlString WorkerList()
        {
            var result = db.workersView.ToList();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString Remove(int salaryReportId)
        {
            var item = db.salaryReport.Find(salaryReportId);
            var result = db.salaryReport.Remove(item);
            db.SaveChanges();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString Add(SalaryReport salaryReport)
        {
            var item = db.salaryReport.Add(salaryReport);
            db.SaveChanges();
            return new HtmlString((new JsonExtensions()).ObjectToJson(item));
        }
    }
}