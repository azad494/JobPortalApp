using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalApp.Manager;
using JobPortalApp.Models;

namespace JobPortalApp.Controllers
{
    public class JobController : Controller
    {
        JobManager jobManager = new JobManager();
        UserManager userManager = new UserManager();
        [Authorize]
        public ActionResult Post()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Post(Job job)
        {
            string email = Session["Email"].ToString();
            UserEmployer userEmployer = userManager.GetUserEmployer(email);
            ViewBag.title = "Post a job";
            string message = jobManager.Post(job,userEmployer);
            ViewBag.message = message;
            return View();
        }
        
        public ActionResult ViewJob(string search)
        {
            ViewBag.jobs = jobManager.SearchJob(search);
            return View();
        }
        

        [Authorize]
        public ActionResult ApplyJob(int Id)
        {
            Job job = jobManager.GetJobById(Id);
            string company = job.Company;
            ViewBag.employer = userManager.GetEmployerByCompany(company);
            ViewBag.job = job;
            return View();
        }


	}
}