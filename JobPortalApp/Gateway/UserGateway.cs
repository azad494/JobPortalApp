using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using JobPortalApp.Models;

namespace JobPortalApp.Gateway
{
    public class UserGateway:BaseGateway
    {
        public int SignupAsCandidate(UserCandidate userCandidate)
        {
            string query = "INSERT INTO UserCandidate VALUES('" + userCandidate.Name + "','" + userCandidate.Email + "','" + userCandidate.Birthdate + "','" + userCandidate.Gender + "','" + userCandidate.Password + "')";
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        public int SignupAsEmployer(UserEmployer userEmployer,string filepath)
        {
            string query = "INSERT INTO UserEmployer VALUES('" + userEmployer.Name + "','" + userEmployer.Email + "','" + userEmployer.Birthdate + "','" + userEmployer.Gender + "','" + userEmployer.Password + "','" + userEmployer.CompanyName + "','" + userEmployer.CompanyAddress + "','" + userEmployer.CompanyTradeLicense + "','" + filepath + "','" + userEmployer.CompanyCategory + "')";
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsUserCandidateExist(string email, string password)
        {
            string query = "SELECT Email,[Password] FROM UserCandidate WHERE Email='" + email + "' AND [Password]='" + password + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }
        public bool IsUserEmployerExist(string email, string password)
        {
            string query = "SELECT Email,[Password] FROM UserEmployer WHERE Email='" + email + "' AND [Password]='" + password + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }
        public bool IsCandidateEmailExist(string email)
        {
            string query = "SELECT Email FROM UserCandidate WHERE Email='" + email + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }
        public bool IsEmployerEmailExist(string email)
        {
            string query = "SELECT Email FROM UserEmployer WHERE Email='" + email + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }
        
        public UserCandidate GetUserCandidate(string email)
        {
            string query = "SELECT * FROM UserCandidate WHERE Email= '" + email + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            Reader.Read();
            
                UserCandidate userCandidate = new UserCandidate();
                userCandidate.Id = Convert.ToInt32(Reader["Id"]);
                userCandidate.Name = Reader["Name"].ToString();
                userCandidate.Email = Reader["Email"].ToString();
                userCandidate.Birthdate = Reader["Birthdate"].ToString();
                userCandidate.Gender = Reader["Gender"].ToString();
                userCandidate.Password = Reader["Password"].ToString();
 
            Reader.Close();
            Connection.Close();
            return userCandidate;
        }
        public UserEmployer GetUserEmployer(string email)
        {
            string query = "SELECT * FROM UserEmployer WHERE Email= '" + email + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            Reader.Read();

            UserEmployer userEmployer = new UserEmployer();
            userEmployer.Id = Convert.ToInt32(Reader["Id"]);
            userEmployer.Name = Reader["Name"].ToString();
            userEmployer.Email = Reader["Email"].ToString();
            userEmployer.Birthdate = Reader["Birthdate"].ToString();
            userEmployer.Gender = Reader["Gender"].ToString();
            userEmployer.Password = Reader["Password"].ToString();
            userEmployer.CompanyName = Reader["CompanyName"].ToString();
            userEmployer.CompanyAddress = Reader["CompanyAddress"].ToString();
            userEmployer.CompanyTradeLicense = Reader["CompanyTradeLicense"].ToString();
            userEmployer.CompanyLogo = Reader["CompanyLogo"].ToString();
            userEmployer.CompanyCategory = Reader["CompanyCategory"].ToString();



            Reader.Close();
            Connection.Close();
            return userEmployer;
        }
        public UserEmployer GetEmployerByCompany(string company)
        {
            string query = "SELECT * FROM UserEmployer WHERE CompanyName = '" + company + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            Reader.Read();

            UserEmployer userEmployer = new UserEmployer();
            userEmployer.Id = Convert.ToInt32(Reader["Id"]);
            userEmployer.Name = Reader["Name"].ToString();
            userEmployer.Email = Reader["Email"].ToString();
            userEmployer.Birthdate = Reader["Birthdate"].ToString();
            userEmployer.Gender = Reader["Gender"].ToString();
            userEmployer.Password = Reader["Password"].ToString();
            userEmployer.CompanyName = Reader["CompanyName"].ToString();
            userEmployer.CompanyAddress = Reader["CompanyAddress"].ToString();
            userEmployer.CompanyTradeLicense = Reader["CompanyTradeLicense"].ToString();
            userEmployer.CompanyLogo = Reader["CompanyLogo"].ToString();
            userEmployer.CompanyCategory = Reader["CompanyCategory"].ToString();



            Reader.Close();
            Connection.Close();
            return userEmployer;
        }
        
    }
}