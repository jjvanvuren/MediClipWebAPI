using MediClipWebAPI.Models;
using MediClipWebAPI.Processors;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediClipWebAPI.Controllers
{
    public class WardController : ApiController
    {
        static String DATABASE_CONNECTION = "Server=tcp:mediclip.database.windows.net,1433;Initial Catalog=MediClipDB;Persist Security Info=False;User ID=jacques;Password=gd3*#4XZ3iyFSD;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //GET all wards
        [HttpGet]
        [Route("GetAllWards")]
        public IEnumerable<Ward> Get()
        {
            string connectionString = DATABASE_CONNECTION;
            SqlDataReader reader = null;
            string query = "SELECT * FROM Ward";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                reader = command.ExecuteReader();
                List<Ward> qresults = new List<Ward>();

                while (reader.Read())
                {
                    Ward qr = new Ward();
                    qr.WardID = Convert.ToInt32(reader["WardID"].ToString());
                    qr.Name = reader["Name"].ToString();
                    qr.Description = reader["Description"].ToString();
                    qresults.Add(qr);
                }
                connection.Close();

                return qresults;
            }     
        }
        //GET ward by WardID
        [HttpGet]
        [Route("GetWard")]
        public Ward Get(int id)
        {
            string connectionString = DATABASE_CONNECTION;
            SqlDataReader reader = null;

            string query = "SELECT * FROM Ward WHERE WardID = '@WardID'";

            query = query.Replace("@WardID", Convert.ToString(id));

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                reader = command.ExecuteReader();
                Ward qresult = new Ward();

                while (reader.Read())
                {
                    qresult.WardID = Convert.ToInt32(reader["WardID"].ToString());
                    qresult.Name = reader["Name"].ToString();
                    qresult.Description = reader["Description"].ToString();
                }
                connection.Close();

                return qresult;
            }
        }

        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost]
        [Route("SaveWard")]
        public bool SaveWard(Ward ward)
        {
            if (ward == null)
            {
                return false;
            }
            else
            {
                return WardProcessor.ProcessAddWard(ward);
            }
            
        }
        //public void Post([FromBody]string value)
        //{

        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
