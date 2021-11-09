using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinema.Models;

namespace Cinema.viewModel
{
    public class OrderViewModel
    {
        public User user { get; set; }
        public Movie movie { get; set; }
        public string date { get; set; }
        public string hour { get; set; }
        public Hall hall { get; set; }
        public List<Order> orders { get; set; }

    }
}