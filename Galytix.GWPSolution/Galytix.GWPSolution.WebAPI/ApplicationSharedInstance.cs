using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galytix.GWPSolution.WebAPI
{
    public static class ApplicationSharedInstance
    {
        public static List<Model.GWPByCountry> GWPCountryData { get; set; }
    }
}
