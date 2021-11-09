using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinema.Models;

namespace Cinema.viewModel
{
    public class MovieInfoViewModel
    {
        public Movie movie { get; set; }
        public List<Time> dates { get; set; }
    }
}