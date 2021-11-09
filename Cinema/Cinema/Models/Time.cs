using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Time
    {
        
        public string name { get; set; }
        [Key]
        [Column(Order = 0)]
        public string date { get; set; }
        [Key]
        [Column(Order = 1)]
        public string hour { get; set; }
        [Key]
        [Column(Order = 2)]
        public string hall { get; set; }
    }
}