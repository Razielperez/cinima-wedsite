using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Hall
    {
        [Key]
        public string name { get; set; }
        public int numSeat { get; set; }

    }
}