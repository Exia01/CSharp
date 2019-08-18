﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // data annotations to override methods
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //string type is nullable and there is not limit in characters numbers
        [Required]
        [StringLength(255)]
        public string Name { get; set; } 
        public bool IsSubscribedToNewsletter { get; set; }
        // navigation property --> allows navigation from customer to membership type
        public MembershipType MembershipType { get; set; }
        // we can look up as foreign key
        public byte MembershipTypeId { get; set; 
        }
        
    }

  
}