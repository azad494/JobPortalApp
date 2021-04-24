using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JobPortalApp.Manager;
using JobPortalApp.Models;
using System.Net;
using System.Net.Mail;

namespace JobPortalApp.Controllers
{
    public class UserController : Controller
    {
        UserManager userManager = new UserManager();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            int a = userManager.IsUserExists(email, password);
            if (a==1)
            {
                FormsAuthentication.SetAuthCookie(email,true);
                Session["Email"] = email;
                Session["Type"] = 1;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (a==2)
                {
                    FormsAuthentication.SetAuthCookie(email, true);
                    Session["Email"] = email;
                    Session["Type"] = 2;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.message = "Email or password doesn't exist";
                    return RedirectToAction("Login");
                }
                
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult SignupAsCandidate()
        {
  
            return View();
        }

        [HttpPost]
        public ActionResult SignupAsCandidate(UserCandidate userCandidate)
        {
            int a = userManager.IsCandidateEmailExist(userCandidate.Email);
            if (a == 1)
            {
                ViewBag.message = "Email already exists";
                return View();
            }
            else
            {
                string message = userManager.SignupAsCandidate(userCandidate);
                EmailSender(userCandidate);

                ViewBag.Message = message;
                return RedirectToAction("Login");
            }
        }

        public void EmailSender(UserCandidate userCandidate)
        {
            MailMessage mm = new MailMessage("mdriad1610@gmail.com", userCandidate.Email);
            mm.Subject = "Confirmation Email";
            mm.Body = "Hello Mr. " + userCandidate.Name + ", \nThank you for regestering in JobFinder.";
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = false;

            NetworkCredential nc = new NetworkCredential("mdriad1610@gmail.com", "502806193360345");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);

        }

        public ActionResult SignupAsEmployer()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SignupAsEmployer(UserEmployer userEmployer, HttpPostedFileBase file)
        {
            int a = userManager.IsEmployerEmailExist(userEmployer.Email);
            if (a == 1)
            {
                ViewBag.message = "Email already exists";
                return View();
            }
            else
            {
                string filename = Path.GetExtension(file.FileName);
                file.SaveAs(Server.MapPath("/images/" + userEmployer.CompanyName + filename));
                string message = userManager.SignupAsEmployer(userEmployer, userEmployer.CompanyName + filename);
                EmailSender(userEmployer);

                ViewBag.Message = message;
                return RedirectToAction("Login");
            }

        }
        
        public void EmailSender(UserEmployer userEmployer)
        {
            MailMessage mm = new MailMessage("mdriad1610@gmail.com", userEmployer.Email);
            mm.Subject = "Confirmation Email";
            mm.Body = "Hello Mr. " + userEmployer.Name + ", \nThank you for regestering in JobFinder.";
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("mdriad1610@gmail.com", "502806193360345");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
        }
        
        
	}

}