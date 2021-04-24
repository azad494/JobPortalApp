using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using JobPortalApp.Models;

namespace JobPortalApp.Gateway
{
    public class JobGateway:BaseGateway
    {
        public int Post(Job job, UserEmployer userEmployer)
        {
            string date = System.DateTime.Now.ToString();
            string query = "INSERT INTO Job VALUES('" + job.Title + "','" + userEmployer.CompanyName + "','" + job.Description + "','" + job.LastDateToApply + "','" + job.NumberOfPost + "','" + job.Qualification + "','" + job.Experience + "','" + job.Location + "','" + job.Responsibilities + "','" + job.Salary + "','" + job.JobType + "','" + job.AdditionalRequirements + "','" + job.Gender + "','" + date + "')";
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        

        public Job GetJobById(int Id)
        {
            string query = "SELECT * FROM Job WHERE Id='" + Id + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            Reader.Read();
            
                Job job = new Job();
                job.Id = Convert.ToInt32(Reader["Id"]);
                job.Title = Reader["Title"].ToString();
                job.Company = Reader["Company"].ToString();
                job.Description = Reader["Description"].ToString();
                job.LastDateToApply = Reader["LastDateToApply"].ToString();
                job.NumberOfPost = Convert.ToInt32(Reader["NumberOfPost"]);
                job.Qualification = Reader["Qualification"].ToString();
                job.Experience = Reader["Experience"].ToString();
                job.Location = Reader["Location"].ToString();
                job.Responsibilities = Reader["Responsibilities"].ToString();
                job.Salary = Reader["Salary"].ToString();
                job.JobType = Reader["JobType"].ToString();
                job.AdditionalRequirements = Reader["AdditionalRequirements"].ToString();
                job.Gender = Reader["Gender"].ToString();
                job.PostDate = Reader["PostDate"].ToString();
                
            Reader.Close();
            Connection.Close();
            return job;
        }

        public List<Job> SearchJob(string search)
        {
            string query = "SELECT * FROM Job WHERE Title='" + search + "' OR Company='" + search + "' OR Location='" + search + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Job> jobs = new List<Job>();
            while (Reader.Read())
            {
                Job job = new Job();
                job.Id = Convert.ToInt32(Reader["Id"]);
                job.Title = Reader["Title"].ToString();
                job.Company = Reader["Company"].ToString();
                job.Description = Reader["Description"].ToString();
                job.LastDateToApply = Reader["LastDateToApply"].ToString();
                job.NumberOfPost = Convert.ToInt32(Reader["NumberOfPost"]);
                job.Qualification = Reader["Qualification"].ToString();
                job.Experience = Reader["Experience"].ToString();
                job.Location = Reader["Location"].ToString();
                job.Responsibilities = Reader["Responsibilities"].ToString();
                job.Salary = Reader["Salary"].ToString();
                job.JobType = Reader["JobType"].ToString();
                job.AdditionalRequirements = Reader["AdditionalRequirements"].ToString();
                job.Gender = Reader["Gender"].ToString();
                job.PostDate = Reader["PostDate"].ToString();

                jobs.Add(job);
            }
            Reader.Close();
            Connection.Close();
            return jobs;
        }

    }
}