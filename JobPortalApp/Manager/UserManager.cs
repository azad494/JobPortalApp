using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalApp.Gateway;
using JobPortalApp.Models;

namespace JobPortalApp.Manager
{
    public class UserManager
    {
        private UserGateway userGateway;

        public UserManager()
        {
            userGateway = new UserGateway();
        }

        public string SignupAsCandidate(UserCandidate userCandidate)
        {
            int rowAffect = userGateway.SignupAsCandidate(userCandidate);
            if (rowAffect > 0)
            {
                return "Signup successful";
            }
            else
            {
                return "Signup failed";
            }
        }

        public string SignupAsEmployer(UserEmployer userEmployer,string filepath)
        {
            int rowAffect = userGateway.SignupAsEmployer(userEmployer,filepath);
            if (rowAffect > 0)
            {
                return "Signup successful";
            }
            else
            {
                return "Signup failed";
            }
        }

        public int IsUserExists(string email,string password)
        {
            bool isCandidateExists = userGateway.IsUserCandidateExist(email,password);
            if (isCandidateExists == true)
            {
                return 1;
            }
            else
            {
                bool isEmployerExists = userGateway.IsUserEmployerExist(email, password);
                if (isEmployerExists)
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
            

        }

        public int IsCandidateEmailExist(string email)
        {
            bool isExists = userGateway.IsCandidateEmailExist(email);
            if (isExists == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int IsEmployerEmailExist(string email)
        {
            bool isExists = userGateway.IsEmployerEmailExist(email);
            if (isExists == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        
        //public List<SelectListItem> GetUserTypesForDropDown()
        //{
        //    List<SelectListItem> selectListItems = new List<SelectListItem>();
        //    selectListItems.Add(new SelectListItem() { Text = "--Select--", Value = "" });
        //    foreach (UserType userType in GetAllTypes())
        //    {
        //        SelectListItem selectList = new SelectListItem();
        //        selectList.Text = userType.Type;
        //        selectList.Value = userType.Id.ToString();
        //        selectListItems.Add(selectList);
        //    }
        //    return selectListItems;
        //} 

        public UserCandidate GetUserCandidate(string email)
        {
            return userGateway.GetUserCandidate(email);
        }

        public UserEmployer GetUserEmployer(string email)
        {
            return userGateway.GetUserEmployer(email);
        }

        public UserEmployer GetEmployerByCompany(string company)
        {
            return userGateway.GetEmployerByCompany(company);
        }

        public List<Gender> Genders()
        {
            List<Gender> genders = new List<Gender>();
            genders.Add(new Gender()
            {
                Id = 1,Name = "Male"
            });
            genders.Add(new Gender()
            {
                Id = 2,
                Name = "Female"
            });
            return genders;
        } 
    }
}