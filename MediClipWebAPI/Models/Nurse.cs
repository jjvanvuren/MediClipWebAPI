using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediClipWebAPI.Models
{
    public class Nurse
    {
        public int NurseID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Password { get; set; }
    }
}