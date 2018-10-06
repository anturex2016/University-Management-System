using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVCDemoProject.Models;

namespace MVCDemoProject.Gateway
{
    public class DesignationGateway:Gateway
    {
        public List<Designation> GetAllDesignations()
        {
            Query = "SELECT * FROM Designations";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Designation> designations = new List<Designation>();
            while (Reader.Read())
            {
                Designation designation = new Designation
                {
                    DesignationID = (int)Reader["DesignationID"],
                    DesignationName = Reader["DesignationName"].ToString()
                };
                designations.Add(designation);
            }
            Reader.Close();
            Connection.Close();
            return designations;
        }
    }
}