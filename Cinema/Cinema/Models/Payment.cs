using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Payment
    {
        
        public string name { get; set; }
        [Key]
        public string numCard { get; set; }
        
    }
}