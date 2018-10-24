using MediClipWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MediClipWebAPI.Repositories
{
    public class NoteRepository
    {
        static String DATABASE_CONNECTION = "Server=tcp:mediclip.database.windows.net,1433;Initial Catalog=MediClipDB;Persist Security Info=False;User ID=jacques;Password=gd3*#4XZ3iyFSD;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static bool AddNote(PostNote note)
        {
            string connectionString = DATABASE_CONNECTION;

            string query = "INSERT INTO Note (PatientID, Title, Text, Picture) VALUES ('@PatientID', '@Title', '@Text', '@Picture');";

            query = query.Replace("@PatientID", Convert.ToString(note.PatientID))
                .Replace("@Title", note.Title)
                .Replace("@Text", note.Text)
                .Replace("@Picture", note.Picture);

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                //throw;
                return false;
            }
        }

    }
}