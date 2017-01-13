using PracaInzynierska.Models;
using PracaInzynierska.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracaInzynierska.Controllers
{
    public class OrderController : Controller
    {
        private ModelContext db = new ModelContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult WorkersOrder()
        {
            return View();
        }
        public HtmlString ShowOrders()
        {
            var result = db.ordersView.ToList();
            
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }
        public HtmlString ShowOrdersForWorker()
        {
            string sesionName = Session["LoggedUserName"].ToString();
            var worker = db.users.Where(model => model.Login.Email.Equals(sesionName)).FirstOrDefault();
            var result = db.workerOrderView.Where(x => x.WorkerId == worker.UserId).ToList();

            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }

        public HtmlString ShowOrdersForClient()
        {
            string sesionName = Session["LoggedUserName"].ToString();
            var client = db.users.Where(model => model.Login.Email.Equals(sesionName)).FirstOrDefault();
            var result = db.clientOrderView.Where(x => x.ClientId == client.UserId).ToList();
            
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString EditStatus(int id, string status)
        {
            var result = db.orders.Find(id);
            result.Status = status;
            db.SaveChanges();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString FindDefects(int id)
        {
            var result = db.defectView.Where(x => (x.OrderId == id)).ToList();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString AddWorkerToOrder(int id, int workerId)
        {
            var result = db.orders.Find(id);
            result.WorkerId = workerId;
            db.SaveChanges();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString AddStatusToOrder(int id, string status)
        {
            var result = db.orders.Find(id);
            result.Status = status;
            db.SaveChanges();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString FindOrder(int id)
        {
            var result = db.orders.Find(id);

            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString MakeOrder(int carId, Order order, int[] servicesId, string comments)
        {
            string sesionName = Session["LoggedUserName"].ToString();
            var userData = db.users.Where(model => model.Login.Email.Equals(sesionName)).FirstOrDefault();
            order.CarId = carId;
            order.ClientId = userData.Client.ClientId;
            order.OrderDate = DateTime.Now;
            order.Status = "Nowe";
            order.Comments = comments;
            db.orders.Add(order);
            try
            {
                db.SaveChanges();
            }catch(Exception ex)
            {
                return new HtmlString((new JsonExtensions()).ObjectToJson(1));
            }
            

            Defect defect = new Defect();
            for (int i = 0; i < servicesId.Length; i++)
            {
                defect.OrderId = order.OrderId;
                defect.ServiceId = servicesId[i];
                db.defects.Add(defect);
                db.SaveChanges();
            }

            var result = db.SaveChanges();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }
    }
}