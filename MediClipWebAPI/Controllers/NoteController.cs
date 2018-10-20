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
    public class NoteController : ApiController
    {
        static String DATABASE_CONNECTION = "Server=tcp:mediclip.database.windows.net,1433;Initial Catalog=MediClipDB;Persist Security Info=False;User ID=jacques;Password=gd3*#4XZ3iyFSD;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET all notes for Patient
        [HttpGet]
        [Route("GetPatientNotes")]
        public IEnumerable<Note> Get(int id)
        {
            string connectionString = DATABASE_CONNECTION;
            SqlDataReader reader = null;
            string query = "SELECT * FROM Note WHERE PatientID = '@PatientID'";

            query = query.Replace("@PatientID", Convert.ToString(id));

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                reader = command.ExecuteReader();
                List<Note> qresults = new List<Note>();

                while (reader.Read())
                {
                    Note qr = new Note();
                    qr.NoteID = Convert.ToInt32(reader["NoteID"].ToString());
                    qr.PatientID = Convert.ToInt32(reader["PatientID"].ToString());
                    qr.Title = reader["Title"].ToString();
                    qr.Text = reader["Text"].ToString();
                    qr.Picture = reader["Picture"].ToString();
                    qresults.Add(qr);
                }
                connection.Close();

                return qresults;
            }
        }

        // POST Note to notes table
        [HttpPost]
        [Route("SaveNote")]
        public bool SaveNote(Note note)
        {
            if (note == null)
            {
                return false;
            }
            else
            {
                return NoteProcessor.ProcessAddNote(note);
            }
            
        }
    }
}
