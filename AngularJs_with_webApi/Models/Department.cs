using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJs_with_webApi.Models
{
    public class Department
    {
        [Key]
        public int Department_id { get; set; }
        public string Department_name { get; set; }
    }
}