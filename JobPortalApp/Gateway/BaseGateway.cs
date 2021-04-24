using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace JobPortalApp.Gateway
{
    public class BaseGateway
    {
        public SqlConnection Connection;
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public BaseGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["JobDb"].ConnectionString;
            Connection = new SqlConnection(connectionString);
        }
    }
}