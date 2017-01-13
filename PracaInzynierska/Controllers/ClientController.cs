using PracaInzynierska.Models;
using PracaInzynierska.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracaInzynierska.Controllers
{
    public class ClientController : Controller
    {
        private ModelContext db = new ModelContext();

        [Authorize(Roles = "Client")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Client")]
        public ActionResult Orders()
        {
            return View();
        }

        [Authorize(Roles = "Worker, OfficeWorker, Admin")]
        public ActionResult AddClient()
        {
            return View();
        }

        public HtmlString ClientList()
        {
            var result = db.clientsView.ToList();

            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }

        public HtmlString CarsList()
        {
            
            if (Session["LoggedUserName"].ToString() == null)
            {
                RedirectToAction("Index", "Home");
            }
            string sesionName = Session["LoggedUserName"].ToString();
            var userData = db.users.Where(model => model.Login.Email.Equals(sesionName)).FirstOrDefault();
            try
            {
                var result = db.cars.Where(x => x.ClientId == userData.Client.ClientId).ToList();
                return new HtmlString((new JsonExtensions()).ObjectToJson(result));
            }
            catch (System.NullReferenceException ex)
            {
                return new HtmlString((new JsonExtensions()).ObjectToJson(ex));
            }

            //return new HtmlString((new JsonExtensions()).ObjectToJson(result));         
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString AddClient(Client client, User user, Login login, PostalCode postalCode)
        {
            if (client.CompanyName == null)
                client.CompanyName = "Brak danych";
            if(client.NIP == null)
                client.NIP = "Brak danych";
            client.JoinDate = DateTime.Now;
            client.CorporationClient = false;
            user.NameRole = "Client";
            db.clients.Add(client);
            db.users.Add(user);
            db.logins.Add(login);
            db.postalCodes.Add(postalCode);
            var result = db.SaveChanges();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString AddCarToDb(Car car)
        {
            string sesionName = Session["LoggedUserName"].ToString();
            var userData = db.users.Where(model => model.Login.Email.Equals(sesionName)).FirstOrDefault();
            car.ClientId = userData.Client.ClientId;
            db.cars.Add(car);
            var result = db.SaveChanges();
            return new HtmlString((new JsonExtensions()).ObjectToJson(result));
        }


    }
}