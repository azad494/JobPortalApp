using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobPortalApp.Gateway;
using JobPortalApp.Models;

namespace JobPortalApp.Manager
{
    public class AppliedJobManager
    {
        private AppliedJobGateway appliedJobGateway;

        public AppliedJobManager()
        {
            appliedJobGateway = new AppliedJobGateway();
        }

        public string AppliedJob(AppliedJob appliedJob,string filename)
        {
            int rowAffect = appliedJobGateway.ApplyForTheJob(appliedJob,filename);
            
            if (rowAffect > 0)
            {
                return "Posting successful";
            }
            else
            {
                return "Posting failed";
            }
        }

        public List<AppliedJob> GetAllAppliedJobByCompany(string company)
        {
            return appliedJobGateway.GetAllAppliedJobByCompany(company);
        }
    }
}