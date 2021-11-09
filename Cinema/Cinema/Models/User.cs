using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Cinema.Models
{
    public class User
    {
        [Key]  
        public string UserName { get; set; }  
        public string Password { get; set; }
        public string Email { get; set; }  
        public int Age { get; set; }
    }
}