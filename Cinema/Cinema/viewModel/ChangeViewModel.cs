using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinema.Models;
namespace Cinema.viewModel
{
    public class ChangeViewModel
    {
        public string userName { get; set; }        public Movie movie { get; set; }        public string date { get; set; }        public string time { get; set; }        public Hall hall { get; set; }        public List<Order> orders { get; set; }        public string oldSeats { get; set; }        public string subTotal { get; set; }

    }
}