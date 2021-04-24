using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JobPortalApp.Manager;
using JobPortalApp.Models;

namespace JobPortalApp.Controllers
{
    
    public class HomeController : Controller
    {
        UserManager userManager = new UserManager();
        JobManager jobManager = new JobManager();
        
        public ActionResult Index()
        {
            if (Session["Email"]!=null)
            {
                string email = Session["Email"].ToString();
               
                return View();
            }
            else
            {
                return View();
            }
                    
        }
        
        public ActionResult About()
        {
            

            return View();
        }
        
        public ActionResult Categories()
        {
            return View();
        }
        
        public ActionResult Contact()
        {
            

            return View();
        }

       
    }
}