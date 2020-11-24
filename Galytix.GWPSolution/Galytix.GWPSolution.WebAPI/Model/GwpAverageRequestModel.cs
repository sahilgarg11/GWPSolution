using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Galytix.GWPSolution.WebAPI.Model
{
    public class GwpAverageRequestModel
    {
        [Required]
        public string Country { get; set; }
        [Required]
        public List<string> LineOfBusiness { get; set; }
    }
}
