using MediClipWebAPI.Models;
using MediClipWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediClipWebAPI.Processors
{
    public class NoteProcessor
    {
        public static bool ProcessAddNote(PostNote note)
        {
            //Processing, Validating, Formating
            return NoteRepository.AddNote(note);
        }

    }
}