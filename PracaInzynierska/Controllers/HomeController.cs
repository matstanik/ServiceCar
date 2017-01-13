using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PracaInzynierska.Models;
using PracaInzynierska.Models.Entities;
using System.Web.Security;
using System.Net.Mail;

namespace PracaInzynierska.Controllers
{
    public class HomeController : Controller
    {
   
        private ModelContext db = new ModelContext();
        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult News()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Login()
        {
            return RedirectToAction("Index");
        }

        //GET: Home
        //[Authorize(Roles = "Admin")]
        [HttpGet]       
        public ActionResult Index([Bind(Include = "UserId,Name,Surname,Sex,PhoneNumber")] User user, [Bind(Include = "LoginId,Email,Password")] Login login)
        {
            ViewBag.Message = GetRole();
            if (ModelState.IsValid)
            {
                db.logins.Add(login);
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            //var result = db.users.FirstOrDefault(x => x.Login.Email == user.Login.Email && x.Login.Password == user.Login.Password);
            //if (result != null)
            //{                
            //    FormsAuthentication.SetAuthCookie(user.Login.Email, true);
            //    Session["LoggedUserName"] = result.Login.Email.ToString();
            //    return RedirectToAction("AfterLogin");
                
            //}
            return View(user);
        }

        //public ActionResult Login()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Login(User user, string returnUrl)
        {
            var result = db.users.Where(x => x.Login.Email == user.Login.Email && x.Login.Password == user.Login.Password).First();
            if(result != null)
            {
                FormsAuthentication.SetAuthCookie(result.Login.Email, false);
                Session["LoggedUserName"] = result.Login.Email.ToString();
                if (Url.IsLocalUrl(returnUrl)&&returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//")&&!returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("AfterLogin");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid user/password");
                return View();
            }
        }
        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public JsonResult GetRoleName()
        {
            if (Session["LoggedUserName"] != null)
            {
                string sesionName = Session["LoggedUserName"].ToString();
                var result = db.users.Where(model => model.Login.Email.Equals(sesionName)).FirstOrDefault();
                ViewBag.Message = result;
                return Json(result.NameRole, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public string GetRole()
        {
            if (Session["LoggedUserName"] != null)
            {
                string sesionName = Session["LoggedUserName"].ToString();
                var result = db.users.Where(model => model.Login.Email.Equals(sesionName)).FirstOrDefault();
                return result.NameRole;
            }
            else
            {
                return "Admin";
            }
        }

        public ActionResult AfterLogin()
        {
            return View();
        }

        public ActionResult AfterLogout()
        {
            if (Session["LoggedUserName"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
       
        
        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,NameRole,Name,Surname,Sex,PhoneNumber,StreetName,HouseNumber")] User user, [Bind(Include = "LoginId,Email,Password")] Login login, [Bind(Include = "ClientId,NIP")] Client client, [Bind(Include = "PostalCodeId,City,PostalCodeNumber")] PostalCode postalCode)
        {
            if (ModelState.IsValid)
            {
                user.NameRole = "Client";
                db.logins.Add(login);
                db.users.Add(user);
                client.JoinDate = DateTime.Now;
                db.clients.Add(client);
                db.postalCodes.Add(postalCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        

        [HttpPost]
        public bool Lista()
        {
            return true;
        }        
        
        public JsonResult FillIndex()
        {
            return Json(db.users.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
} 
