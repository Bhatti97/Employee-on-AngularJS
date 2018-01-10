using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJs_with_webApi.Models
{
    public class Experience
    {
        [Key]
        public int Experience_id { get; set; }
        public string Experience_Companyname { get; set; }
        public string Experience_Start_Year { get; set; }
        public string Experience_End_Year { get; set; }
        public int Employee_id { get; set; }
        public virtual Employee Employee { get; set; }
    }
}