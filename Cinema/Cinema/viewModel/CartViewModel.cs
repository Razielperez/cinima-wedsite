using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinema.Models;

namespace Cinema.viewModel
{
    public class CartViewModel
    {

        public Cart cart { get; set; }
        public List<Cart> carts { get; set; }
    }
}