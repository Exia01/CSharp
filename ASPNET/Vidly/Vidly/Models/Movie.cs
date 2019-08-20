using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        //A Plain Old CLR Objects(POCO) does not have behavior or logic
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }
    }
}