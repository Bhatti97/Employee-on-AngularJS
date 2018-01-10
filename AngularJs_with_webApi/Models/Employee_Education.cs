using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJs_with_webApi.Models
{
    public class Employee_Education
    {
        [Key]
        public int Employee_Education_id { get; set; }
        public string Employee_Education_DegreeName { get; set; }
        public string Employee_Education_DegreeYear { get; set; }
        public string Employee_Education_University { get; set; }
        public decimal Employee_Education_TotalMarks { get; set; }
        public decimal Employee_Education_ObtainedMarks { get; set; }
        public decimal Employee_Education_Percentage { get; set; }
        public int Employee_id { get; set; }
        public virtual Employee Employee { get; set; }
    }
}