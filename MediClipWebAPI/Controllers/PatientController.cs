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
    public class PatientController : ApiController
    {
        static String DATABASE_CONNECTION = "Server=tcp:mediclip.database.windows.net,1433;Initial Catalog=MediClipDB;Persist Security Info=False;User ID=jacques;Password=gd3*#4XZ3iyFSD;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //GET all patients
        [HttpGet]
        [Route("GetAllPatients")]
        public IEnumerable<Patient> Get()
        {
            string connectionString = DATABASE_CONNECTION;
            SqlDataReader reader = null;
            string query = "SELECT * FROM Patient";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                reader = command.ExecuteReader();
                List<Patient> qresults = new List<Patient>();

                while (reader.Read())
                {
                    Patient qr = new Patient();
                    qr.PatientID = Convert.ToInt32(reader["PatientID"].ToString());
                    qr.WardID = Convert.ToInt32(reader["WardID"].ToString());
                    qr.AssignDateFrom = reader["AssignDateFrom"].ToString();
                    qr.AssignDateTo = reader["AssignDateTo"].ToString();
                    qr.FirstName = reader["FirstName"].ToString();
                    qr.LastName = reader["LastName"].ToString();
                    qr.Dob = reader["Dob"].ToString();
                    qr.Sex = reader["Sex"].ToString();
                    qr.Dosage = reader["Dosage"].ToString();
                    qr.Picture = reader["Picture"].ToString();
                    qresults.Add(qr);
                }
                connection.Close();

                return qresults;
            }     
        }

        //GET all patients in a ward
        [HttpGet]
        [Route("GetWardPatients")]
        public IEnumerable<Patient> Get(int id)
        {
            string connectionString = DATABASE_CONNECTION;
            SqlDataReader reader = null;
            string query = "SELECT * FROM Patient WHERE WardID = '@WardID'";

            query = query.Replace("@WardID", Convert.ToString(id));

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                reader = command.ExecuteReader();
                List<Patient> qresults = new List<Patient>();

                while (reader.Read())
                {
                    Patient qr = new Patient();
                    qr.PatientID = Convert.ToInt32(reader["PatientID"].ToString());
                    qr.WardID = Convert.ToInt32(reader["WardID"].ToString());
                    qr.AssignDateFrom = reader["AssignDateFrom"].ToString();
                    qr.AssignDateTo = reader["AssignDateTo"].ToString();
                    qr.FirstName = reader["FirstName"].ToString();
                    qr.LastName = reader["LastName"].ToString();
                    qr.Dob = reader["Dob"].ToString();
                    qr.Sex = reader["Sex"].ToString();
                    qr.Dosage = reader["Dosage"].ToString();
                    qr.Picture = reader["Picture"].ToString();
                    qresults.Add(qr);
                }
                connection.Close();

                return qresults;
            }
        }

        // GET single patient by WardID and PatientID
        [HttpGet]
        [Route("GetPatient")]
        public Patient Get(int wId, int pId)
        {
            string connectionString = DATABASE_CONNECTION;
            SqlDataReader reader = null;
            string query = "";

                query = "SELECT * FROM Patient WHERE WardID = '@WardID' AND PatientID = '@PatientID'";

                query = query.Replace("@WardID", Convert.ToString(wId))
                .Replace("@PatientID", Convert.ToString(pId));

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                reader = command.ExecuteReader();
                Patient qresult = new Patient();

                while (reader.Read())
                {
                    qresult.PatientID = Convert.ToInt32(reader["PatientID"].ToString());
                    qresult.WardID = Convert.ToInt32(reader["WardID"].ToString());
                    qresult.AssignDateFrom = reader["AssignDateFrom"].ToString();
                    qresult.AssignDateTo = reader["AssignDateTo"].ToString();
                    qresult.FirstName = reader["FirstName"].ToString();
                    qresult.LastName = reader["LastName"].ToString();
                    qresult.Dob = reader["Dob"].ToString();
                    qresult.Sex = reader["Sex"].ToString();
                    qresult.Dosage = reader["Dosage"].ToString();
                    qresult.Picture = reader["Picture"].ToString();
                }
                connection.Close();

                return qresult;
            }
        }
    }
}
