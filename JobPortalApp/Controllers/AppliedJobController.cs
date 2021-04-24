using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalApp.Models;
using System.IO;
using JobPortalApp.Manager;

namespace JobPortalApp.Controllers
{
    [Authorize]
    public class AppliedJobController : Controller
    {
        AppliedJobManager appliedJobManager = new AppliedJobManager();
        JobManager jobManager = new JobManager();

       
        public ActionResult AppliedJob()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult AppliedJob(AppliedJob appliedJob, HttpPostedFileBase file)
        {
            string filename = Fileupload(file);
            string message = appliedJobManager.AppliedJob(appliedJob, filename);
            ViewBag.Message = message;
            return View();
        }

        public string Fileupload(HttpPostedFileBase file)
        {
            string filename = Path.GetFileName(file.FileName);
            file.SaveAs(Server.MapPath("/CV/" + filename));
            return filename;
        }

    
        public ActionResult ViewAppliedJob(string company)
        {
            ViewBag.jobs = appliedJobManager.GetAllAppliedJobByCompany(company);
            return View();
        }

        public FileResult Download(string path)
        {

            //string path1 = Server.MapPath("~/CV");
            string filename = Path.GetFileName(path);
            var mimeType  = MimeMapping.GetMimeMapping(filename);
            //string type = Path.GetExtension(path);
            //string fullpath = Path.Combine(path1, Filename);
            return File(path,mimeType, filename);
        }
	}
}