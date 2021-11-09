using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Cart
    {
        [Key]
        [Column(Order = 0)]
        public string userName { get; set; }
        [Key]
        [Column(Order = 1)]
        public string name { get; set; }
        [Key]
        [Column(Order = 2)]
        public string date { get; set; }
        [Key]
        [Column(Order = 3)]
        public string hour { get; set; }
        [Key]
        [Column(Order = 4)]
        public string seats { get; set; }
        [Key]
        [Column(Order = 5)]
        public string subtotal { get; set; }  
        public Movie movie { get; set; }

    }
}