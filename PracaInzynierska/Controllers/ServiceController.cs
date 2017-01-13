using PracaInzynierska.Models;
using PracaInzynierska.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracaInzynierska.Controllers
{
    public class ServiceController : Controller
    {
        private ModelContext db = new ModelContext();
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString FindServiceItem(int id/*, string description, double price*/)
        {
            var serviceItem = db.services.Find(id);
            return new HtmlString((new JsonExtensions()).ObjectToJson(serviceItem));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString FindService(int id, string description, double price)
        {
            var serviceItem = db.services.Find(id);
            db.services.Remove(serviceItem);
            Service service = new Service();
            service.ServiceId = id;
            service.Description = description;
            service.Price = price;
            service.AddedDate = DateTime.Now;
            var result = db.services.Add(service);
            db.SaveChanges();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString AddService(Service service)
        {
            service.AddedDate = DateTime.Now;
            var result = db.services.Add(service);
            db.SaveChanges();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }

        public HtmlString ShowService()
        {
            var result = db.services.ToList();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString DeleteService(int id)
        {
            var serviceItem = db.services.Find(id);
            db.services.Remove(serviceItem);
            db.SaveChanges();
            return new HtmlString((new JsonExtensions()).ObjectToJson(serviceItem));
        }
    }
}