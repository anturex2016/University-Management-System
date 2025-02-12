﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MVCDemoProject.Gateway
{
    public class Gateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString;
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public string Query { get; set; }

        public Gateway()
        {
            Connection = new SqlConnection(connectionString);
        }
    }
}