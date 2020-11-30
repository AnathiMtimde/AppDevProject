using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DGSappSem2.Models;
using System.Net;
using System.Net.Mail;
using DGSappSem2.Models.Students;

namespace DGSappSem2.Controllers
{
    public class EmailSetupController : Controller
    {
        // GET: EmailSetup
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(gmail model, Student student)
        {

            MailMessage mm = new MailMessage("ddgss9771@gmail.com", "trevolinjason@gmail.com");
            mm.Subject = "Acceptance into Durban Girls High";
            mm.Body = "Dear student your application was successful.Please proceed to registration ";
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("ddgss9771@gmail.com", "dgss1234#");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            return RedirectToAction("Index", "Students");
        }

        public ActionResult decline()
        {
            return View();
        }

        [HttpPost]
        public ActionResult decline(gmail model, Student student)
        {

            MailMessage mm = new MailMessage("ddgss9771@gmail.com", "trevolinjason@gmail.com");
            mm.Subject = "Application Declined for Durban Girls High";
            mm.Body = "Dear student your application was unsuccessful. ";
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("ddgss9771@gmail.com", "dgss1234#");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            return RedirectToAction("Index", "Students");
        }
    }
}