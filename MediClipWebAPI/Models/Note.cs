﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediClipWebAPI.Models
{
    public class Note
    {
        public int NoteID { get; set; }
        public int PatientID { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }
        public String Picture { get; set; }
    }
}