using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediClipWebAPI.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        public int WardID { get; set; }
        public DateTime AssignDateFrom { get; set; }
        public DateTime AssignDateTo { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime Dob { get; set; }
        public String Sex { get; set; }
        public String Dosage { get; set; }
        public String Picture { get; set; }
    }
}