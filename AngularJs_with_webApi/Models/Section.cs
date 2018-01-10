using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace AngularJs_with_webApi.Models
{
    public class Section
    {
        [Key]
        public int Section_id { get; set; }
        public string Section_name { get; set; }
        public int Department_id { get; set; }
        public virtual Department Department { get; set; }
    }
}