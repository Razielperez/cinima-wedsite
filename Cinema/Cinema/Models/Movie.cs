using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Movie
    {
        [Key]
        public string name { get; set; }
        public string img { get; set; }
        public int price { get; set; }
        public int salePrice { get; set; }
        public string category { get; set; }
        public string summry { get; set; }
        public int age { get; set; }
      
    }
}