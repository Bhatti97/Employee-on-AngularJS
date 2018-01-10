using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJs_with_webApi.Models
{
    public class Employee
    {
        [Key]
        public int Employee_id { get; set; }
        public string Employee_Name { get; set; }
        public decimal Employee_salary { get; set; }
        public string Employee_Password { get; set; }
        public int Section_id { get; set; }
        public virtual Section Section { get; set; }
        public int Department_id { get; set; }
        public virtual Department Department { get; set; }
    }
}