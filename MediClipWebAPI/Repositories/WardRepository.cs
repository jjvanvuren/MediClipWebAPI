using MediClipWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MediClipWebAPI.Repositories
{
    public class WardRepository
    {
        static String DATABASE_CONNECTION = "Server=tcp:mediclip.database.windows.net,1433;Initial Catalog=MediClipDB;Persist Security Info=False;User ID=jacques;Password=gd3*#4XZ3iyFSD;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static bool AddWard(Ward ward)
        {
            string connectionString = DATABASE_CONNECTION;

            string query = "INSERT INTO Ward VALUES ('@WardID', '@Location', '@Description');";

            query = query.Replace("@WardID", Convert.ToString(ward.WardID))
                .Replace("@Location", ward.Location)
                .Replace("@Description", ward.Description);

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