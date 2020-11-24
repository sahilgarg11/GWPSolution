using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galytix.GWPSolution.WebAPI.Model
{
    public class GWPByCountry
    {
        public string Country { get; set; }
        public string VariableId { get; set; }
        public string VariableName { get; set; }
        public string LineOfBusiness { get; set; }
        public string Y2000 { get; set; }
        public string Y2001 { get; set; }
        public string Y2002 { get; set; }
        public string Y2003 { get; set; }
        public string Y2004 { get; set; }
        public string Y2005 { get; set; }
        public string Y2006 { get; set; }
        public string Y2007 { get; set; }
        public string Y2008 { get; set; }
        public string Y2009 { get; set; }
        public string Y2010 { get; set; }
        public string Y2011 { get; set; }
        public string Y2012 { get; set; }
        public string Y2013 { get; set; }
        public string Y2014 { get; set; }
        public string Y2015 { get; set; }

    }

    public class GWPByCountryMap : ClassMap<GWPByCountry>
    {
        public GWPByCountryMap()
        {
            Map(l => l.Country).Name("country");
            Map(l => l.VariableId).Name("variableId");
            Map(l => l.VariableName).Name("variableName");
            Map(l => l.LineOfBusiness).Name("lineOfBusiness");
            Map(l => l.Y2000).Name("Y2000");
            Map(l => l.Y2001).Name("Y2001");
            Map(l => l.Y2002).Name("Y2002");
            Map(l => l.Y2003).Name("Y2003");
            Map(l => l.Y2004).Name("Y2004");
            Map(l => l.Y2005).Name("Y2005");
            Map(l => l.Y2006).Name("Y2006");
            Map(l => l.Y2007).Name("Y2007");
            Map(l => l.Y2008).Name("Y2008");
            Map(l => l.Y2009).Name("Y2009");
            Map(l => l.Y2010).Name("Y2010");
            Map(l => l.Y2011).Name("Y2011");
            Map(l => l.Y2012).Name("Y2012");
            Map(l => l.Y2013).Name("Y2013");
            Map(l => l.Y2014).Name("Y2014");
            Map(l => l.Y2015).Name("Y2015");
        }
    }
}
