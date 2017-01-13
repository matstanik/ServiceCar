using PracaInzynierska.Models;
using PracaInzynierska.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PracaInzynierska.Controllers
{
    public class MessageController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: Message
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HtmlString SendMail(Message message)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                    {
                        string login = Session["LoggedUserName"].ToString();
                        var userData = db.users.Where(model => model.Login.Email.Equals(login)).FirstOrDefault();
                        message.ClientId = userData.Client.ClientId;
                        db.messages.Add(message);
                        db.SaveChanges();
                    }
                try
                {
                    
                   
                        MailMessage msz = new MailMessage();
                        msz.From = new MailAddress(message.Email);
                        msz.To.Add("magdzioch3@gmail.com");// Change this where you want to receice the mail
                        msz.Subject = message.Title;
                        msz.Body = message.MessageContent;
                        SmtpClient smtp = new SmtpClient();

                        smtp.Host = "smtp.gmail.com";

                        smtp.Port = 587;
                        //Email address using which mail will send
                        smtp.Credentials = new System.Net.NetworkCredential("matstanik@gmail.com", "ZJMMS.2468");

                        smtp.EnableSsl = true;

                        smtp.Send(msz);

                        ModelState.Clear();
                        ViewBag.Message = "Dziękujemy za wysłanie wiadomości!";
                   
                    
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Soory we are facing Problem here {ex.Message}";
                }

            }
            return new HtmlString((new JsonExtensions()).ObjectToJson(ViewBag.Message));
        }
    }
}