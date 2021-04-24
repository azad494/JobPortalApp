using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using JobPortalApp.Models;

namespace JobPortalApp.Gateway
{
    public class AppliedJobGateway:BaseGateway
    {
        public int ApplyForTheJob(AppliedJob appliedJob,string filename)
        {
            string query = "INSERT INTO AppliedJob VALUES('" + appliedJob.Company + "','" + appliedJob.JobTitle + "','" + appliedJob.ApplicantName + "','" + appliedJob.ApplicantBd + "','" + appliedJob.ApplicantAddress + "','" + appliedJob.ApplicantEmail + "','/CV/" + filename + "')";
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        public List<AppliedJob> GetAllAppliedJobByCompany(string company)
        {
            string query = "SELECT * FROM AppliedJob WHERE Company='" + company + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<AppliedJob> appliedJobs = new List<AppliedJob>();
            while (Reader.Read())
            {
                AppliedJob appliedJob = new AppliedJob();
                appliedJob.Id = Convert.ToInt32(Reader["Id"]);
                appliedJob.Company = Reader["Company"].ToString();
                appliedJob.JobTitle = Reader["JobTitle"].ToString();
                appliedJob.ApplicantName = Reader["ApplicantName"].ToString();
                appliedJob.ApplicantBd = Reader["ApplicantBd"].ToString();

                appliedJob.ApplicantAddress = Reader["ApplicantAddress"].ToString();
                appliedJob.ApplicantEmail = Reader["ApplicantEmail"].ToString();
                appliedJob.ApplicantCv = Reader["ApplicantCv"].ToString();

                appliedJobs.Add(appliedJob);
            }
            Reader.Close();
            Connection.Close();
            return appliedJobs;
        }
    }
}