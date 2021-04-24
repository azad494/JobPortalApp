using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobPortalApp.Gateway;
using JobPortalApp.Models;

namespace JobPortalApp.Manager
{
    public class JobManager
    {
        private JobGateway jobGateway;

        public JobManager()
        {
            jobGateway = new JobGateway();
        }

        public string Post(Job job, UserEmployer userEmployer)
        {
            int rowAffect = jobGateway.Post(job,userEmployer);
            if (rowAffect > 0)
            {
                return "Posting successful";
            }
            else
            {
                return "Posting failed";
            }
        }

        

        public Job GetJobById(int Id)
        {
            return jobGateway.GetJobById(Id);
        }

        public List<Job> SearchJob(string search)
        {
            return jobGateway.SearchJob(search);
        }
    }
}