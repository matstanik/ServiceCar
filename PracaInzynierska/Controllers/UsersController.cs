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

namespace PracaInzynierska.Controllers
{
    public class UsersController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.users.Include(u => u.Client).Include(u => u.Login).Include(u => u.PostalCode).Include(u => u.Role).Include(u => u.Worker);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.clients, "ClientId", "NIP");
            ViewBag.UserId = new SelectList(db.logins, "LoginId", "Email");
            ViewBag.UserId = new SelectList(db.postalCodes, "PostalCodeId", "PostalCodeNumber");
            ViewBag.UserId = new SelectList(db.roles, "RoleId", "RoleName");
            ViewBag.UserId = new SelectList(db.workers, "WorkerId", "PositionName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,NameRole,Name,Surname,Sex,PhoneNumber,StreetName,HouseNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.clients, "ClientId", "NIP", user.UserId);
            ViewBag.UserId = new SelectList(db.logins, "LoginId", "Email", user.UserId);
            ViewBag.UserId = new SelectList(db.postalCodes, "PostalCodeId", "PostalCodeNumber", user.UserId);
            ViewBag.UserId = new SelectList(db.roles, "RoleId", "RoleName", user.UserId);
            ViewBag.UserId = new SelectList(db.workers, "WorkerId", "PositionName", user.UserId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.clients, "ClientId", "NIP", user.UserId);
            ViewBag.UserId = new SelectList(db.logins, "LoginId", "Email", user.UserId);
            ViewBag.UserId = new SelectList(db.postalCodes, "PostalCodeId", "PostalCodeNumber", user.UserId);
            ViewBag.UserId = new SelectList(db.roles, "RoleId", "RoleName", user.UserId);
            ViewBag.UserId = new SelectList(db.workers, "WorkerId", "PositionName", user.UserId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,NameRole,Name,Surname,Sex,PhoneNumber,StreetName,HouseNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.clients, "ClientId", "NIP", user.UserId);
            ViewBag.UserId = new SelectList(db.logins, "LoginId", "Email", user.UserId);
            ViewBag.UserId = new SelectList(db.postalCodes, "PostalCodeId", "PostalCodeNumber", user.UserId);
            ViewBag.UserId = new SelectList(db.roles, "RoleId", "RoleName", user.UserId);
            ViewBag.UserId = new SelectList(db.workers, "WorkerId", "PositionName", user.UserId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
