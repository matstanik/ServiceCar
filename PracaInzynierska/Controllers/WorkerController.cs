using PracaInzynierska.Models;
using PracaInzynierska.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace PracaInzynierska.Controllers
{
    public class WorkerController : Controller
    {
        private ModelContext db = new ModelContext();
        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Salary()
        {
            return View();
        }
        public HtmlString showWorker()
        {
            //var result = db.users.Include(x => x.Worker).ToList();
            var result = db.workersView.ToList();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }

        
        
        public HtmlString SalaryList()
        {
            if (Session["LoggedUserName"].ToString() == null)
            {
                RedirectToAction("Index", "Home");
            }
            string sesionName = Session["LoggedUserName"].ToString();
            var userData = db.users.Where(model => model.Login.Email.Equals(sesionName)).FirstOrDefault();
            var result = db.salaryReport.Where(x=>x.WorkerId == userData.UserId).ToList();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }
    [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString addWorker(Worker worker, User user, PostalCode postalCode, Login login)
        {
            db.logins.Add(login);
            db.users.Add(user);
            db.workers.Add(worker);
            db.postalCodes.Add(postalCode);
            db.SaveChanges();

            return new HtmlString((new JsonExtensions()).ObjectToJson("add worker"));
        }
    }
}