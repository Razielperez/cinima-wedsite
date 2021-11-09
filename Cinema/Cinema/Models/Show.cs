using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Show
    {
        public Movie movie { get; set; }
        public Time time { get; set; }
    }
}