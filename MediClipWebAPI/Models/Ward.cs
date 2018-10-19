using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediClipWebAPI.Models
{
    public class Ward
    {
        public int WardID { get; set; }
        public String Location { get; set; }
        public String Description { get; set; }
    }
}