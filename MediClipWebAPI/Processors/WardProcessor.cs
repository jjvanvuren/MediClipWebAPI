using MediClipWebAPI.Models;
using MediClipWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediClipWebAPI.Processors
{
    public class WardProcessor
    {
        public static bool ProcessViewWard(Ward ward)
        {
            //Processing, Validating, Formating
            return MediClipRepository.ViewAllWards(ward);
        }

        public static bool ProcessAddWard(Ward ward)
        {
            //Processing, Validating, Formating
            return MediClipRepository.AddWard(ward);
        }

    }
}